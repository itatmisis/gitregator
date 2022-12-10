using Octokit;

namespace Gitregator.Github.Client;

public class GithubClientProvider
{
    private readonly GitHubClient _gitClient;

    public GithubClientProvider(string token) =>
        _gitClient = new GitHubClient(new ProductHeaderValue("Gitregator"))
        {
            Credentials = new Credentials(token)
        };

    public GitHubClient GetClient() => _gitClient;
}
