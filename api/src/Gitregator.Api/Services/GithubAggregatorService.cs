using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Gitregator.Github.Client;
using Octokit;

namespace Gitregator.Api.Services;

public sealed class GithubAggregatorService : IGithubAggregatorService
{
    private readonly GithubClientProvider _provider;

    public GithubAggregatorService(GithubClientProvider provider) => _provider = provider;

    public Task<List<User>> GetRepositoryAggregationAsync(string githubUrl, CancellationToken cancellationToken)
    {
        var t = Task.FromResult(new List<User>());
        return t;
    }

    public Task<User> GetMemberAggregationAsync(string userLogin, CancellationToken cancellationToken)
        => _provider.GetClient().User.Get(userLogin).WaitAsync(cancellationToken);
}
