using System.Threading;
using System.Threading.Tasks;

namespace Gitregator.Api.Services;

public interface IGithubAggregatorService
{
    Task<string> GetRepositoryAggregationAsync(string githubUrl, CancellationToken cancellationToken);

    Task<string> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken);
}
