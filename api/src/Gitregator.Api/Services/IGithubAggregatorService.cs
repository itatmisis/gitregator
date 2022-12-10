using System.Threading;
using System.Threading.Tasks;
using Gitregator.Api.Dtos;
using User = Octokit.User;

namespace Gitregator.Api.Services;

public interface IGithubAggregatorService
{
    Task<GetRepositoryAggregationResponse> GetRepositoryAggregationAsync(string owner, string name, CancellationToken cancellationToken);

    Task<GetMemberAggregationResponse> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken);
}
