namespace Gitregator.Api.Dtos;

public class CollaboratedRepos
{
    public string RepositoryHttpUrl { get; init; } = null!;

    public string RepositoryOwner { get; init; } = null!;

    public string RepositoryName { get; init; } = null!;

    public string RepositoryDescription { get; init; } = null!;

    public int CommitsTotal { get; init; }

    public int IssuesTotal { get; init; }

    public int PullRequestTotal { get; init; }

    public string MostUsedLanguage { get; init; } = null!;
}
