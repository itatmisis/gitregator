using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Octokit;

namespace Gitregator.Api.Services;

public interface IGithubAggregatorService
{
    Task<List<User>> GetRepositoryAggregationAsync(string githubUrl, CancellationToken cancellationToken);

    Task<User> GetMemberAggregationAsync(string userId, CancellationToken cancellationToken);
}
