using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gitregator.Github.Client;
using AutoFixture;
using Gitregator.Api.Dtos;

namespace Gitregator.Api.Services;

public sealed class GithubAggregatorService : IGithubAggregatorService
{
    private readonly GithubClientProvider _provider;
    private readonly IFixture _fixture;

    public GithubAggregatorService(GithubClientProvider provider)
    {
        _provider = provider;
        _fixture = new Fixture();
    }

    public Task<GetRepositoryAggregationResponse> GetRepositoryAggregationAsync(string owner, string name,
        CancellationToken cancellationToken)
        => Task.FromResult(
            new GetRepositoryAggregationResponse
            {
                RepositoryName = "HelloWorld",
                RepositoryHttpUrl = "https://github.com/itatmisis/gitregator",
                RepositoryOwner = "SomeOrganization",
                RepositoryDescription = "Some description of repository",
                Collaborators = _fixture.CreateMany<Collaborator>(),
                Issuers = _fixture.CreateMany<Collaborator>()
            });

    public async Task<GetMemberAggregationResponse> GetMemberAggregationAsync(string userLogin,
        CancellationToken cancellationToken)
    {
        var client = _provider.GetClient();
        var userSource = client.User.Get(userLogin).WaitAsync(cancellationToken).Result;

        var starsCount = client.Activity.Starring.GetAllForUser(userLogin).WaitAsync(cancellationToken)
            .Result.Count;

        // Get count of commit pages
        var pageNum = Math.Ceiling((double)(await client.Connection.Get<Wrapper>(
            new Uri(
                $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=1"),
            new Dictionary<string, string>())).Body.TotalCount / 100);

        // Get count of commits
        var commits = (await client.Connection.Get<Wrapper>(
            new Uri(
                $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=100&page={pageNum}"),
            new Dictionary<string, string>())).Body.Items.ToList();

        var repos = commits.Select(x => x.Repository).Distinct().ToList();
        var reposCount = repos.Count();

        var languages = new Dictionary<string, long>();
        foreach (var repo in repos)
        {
            var currentLanguages = (await client.Repository.GetAllLanguages(repo!.Owner!.Login, repo.Name))
                .ToDictionary(x => x.Name, x => x.NumberOfBytes);
            foreach (var t in currentLanguages)
            {
                if (languages.ContainsKey(t.Key))
                {
                    languages[t.Key] += t.Value;
                }
                else
                {
                    languages.Add(t.Key, t.Value);
                }
            }
        }

        var user = new ExtendedUser()
        {
            Id = userSource.Id,
            Username = userSource.Login,
            DisplayName = userSource.Name,
            ProfilePicUrl = userSource.AvatarUrl,
            Description = userSource.Bio,
            Location = userSource.Location,
            PersonalWebsite = userSource.Blog,
            Email = userSource.Email,
            Company = userSource.Company,
            FollowersCount = userSource.Followers,
            FollowingCount = userSource.Following,
            StarsCount = starsCount,
            CommitsCount = commits.Count,
            ReposCount = reposCount,
            Languages = languages
        };

        return new GetMemberAggregationResponse { User = user };
    }
}
