using System;
using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public class GetRepositoryAggregationResponse
{
    public string RepositoryHttpUrl { get; init; } = null!;

    public string RepositoryOwner { get; init; } = null!;

    public string RepositoryName { get; init; } = null!;

    public string? RepositoryDescription { get; init; }

    public int OpenCommitsTotal { get; init; }

    public int OpenIssuesTotal { get; init; }

    public int PullRequestsTotal { get; init; }

    public string MostUsedLanguage { get; init; } = null!;

    public Dictionary<string, long> Languages { get; init; } = null!;

    public IEnumerable<Collaborator> Collaborators { get; init; } = Array.Empty<Collaborator>();

    public IEnumerable<Collaborator> Issuers { get; init; } = Array.Empty<Collaborator>();
}
