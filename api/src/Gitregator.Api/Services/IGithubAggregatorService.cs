using System.Threading;
using System.Threading.Tasks;
using Gitregator.Api.Dtos;
using Octokit;
using User = Octokit.User;

namespace Gitregator.Api.Services;

public interface IGithubAggregatorService
{
    Task<GetRepositoryAggregationResponse> GetRepositoryAggregationAsync(string githubUrl, CancellationToken cancellationToken);

    Task<User> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken);
}
