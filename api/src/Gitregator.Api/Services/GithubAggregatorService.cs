using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Gitregator.Api.Dtos;

namespace Gitregator.Api.Services;

public sealed class GithubAggregatorService : IGithubAggregatorService
{
    private readonly IFixture _fixture;

    public GithubAggregatorService()
        => _fixture = new Fixture();

    public Task<GetRepositoryAggregationResponse> GetRepositoryAggregationAsync(
        string githubUrl,
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

    public Task<GetMemberAggregationResponse> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken)
        => Task.FromResult(_fixture.Create<GetMemberAggregationResponse>());
}
