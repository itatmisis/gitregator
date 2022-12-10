namespace Gitregator.Api.Dtos;

public class Collaborator : User
{
    public int CommitsTotal { get; init; }

    public int PullRequestsTotal { get; init; }

    public decimal ActivityIndex { get; init; }

    public int IssuesTotal { get; init; }
}
