using System.Threading;
using System.Threading.Tasks;

namespace Gitregator.Api.Services;

public sealed class GithubAggregatorService : IGithubAggregatorService
{
    public Task<string> GetRepositoryAggregationAsync(string githubUrl, CancellationToken cancellationToken)
        => Task.FromResult("Rep");

    public Task<string> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken)
        => Task.FromResult("Mem");
}
