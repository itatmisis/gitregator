using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Gitregator.Github.Client;
using AutoFixture;
using Gitregator.Api.Dtos;
using Gitregator.StackExchange.Client.HttpServices;
using Octokit;

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
        var userSource = await client.User.Get(userLogin);

        var starsCount = (await client.Activity.Starring.GetAllForUser(userLogin)).Count;

        // Get count of commit pages
        var commitsPageNum = Math.Ceiling((double)(await client.Connection.Get<Wrapper>(
            new Uri(
                $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=1"),
            new Dictionary<string, string>())).Body.TotalCount / 100);

        var tasks = new List<Task<IApiResponse<Wrapper>>>();

        // Get count of commits
        for (var i = 1; i <= commitsPageNum; i++)
        {
            tasks.Add(client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=100&page={i}"),
                new Dictionary<string, string>()));
        }

        var commits = (await Task.WhenAll(tasks)).SelectMany(x => x.Body.Items).ToList();

        tasks = new List<Task<IApiResponse<Wrapper>>>
        {
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:pull-request&per_page=1"),
                new Dictionary<string, string>()),
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:issue&per_page=1"),
                new Dictionary<string, string>())
        };

        var taskRes = (await Task.WhenAll(tasks)).ToList();

        var pullRequestsCount = taskRes[0].Body.TotalCount;
        var issuesCount = taskRes[1].Body.TotalCount;

        var repos = commits.Select(x => x.Repository).DistinctBy(x => x!.Id).ToList();
        var reposCount = repos.Count;

        var languageTasks = repos.Select(repo => client.Repository.GetAllLanguages(repo!.Owner!.Login, repo.Name))
            .ToList();

        var languagesList = await Task.WhenAll(languageTasks);

        var groupedLanguages = languagesList.SelectMany(x => x).GroupBy(x => x.Name).ToList();

        var languages = groupedLanguages.ToDictionary(t => t.Key, t => t.Sum(x => x.NumberOfBytes));

        var activity = Math.Round(
            (decimal)commits.Where(x => x!.Commit!.Committer!.Date > DateTime.Now.AddMonths(-1)).ToList().Count
            / commits.Where(x => x!.Commit!.Author!.Date > DateTime.Now.AddYears(-1)).ToList().Count * 10, 1);

        var stackExchangeUser = await ConnectToStackExchange.GetUserByNameAsync(userLogin, cancellationToken);

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
            Languages = languages,
            TopLanguage = languages.OrderByDescending(x => x.Value).FirstOrDefault().Key,
            StackOverflowUrl = stackExchangeUser?.Link,
            ActivityIndex = activity,
            PullRequestsCount = pullRequestsCount,
            IssuesCount = issuesCount
        };

        return new GetMemberAggregationResponse { User = user };
    }
}
