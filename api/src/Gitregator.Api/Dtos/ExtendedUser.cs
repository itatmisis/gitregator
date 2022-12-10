using System;
using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public sealed class ExtendedUser : User
{
    // public IEnumerable<CollaboratedRepos> CollaboratedRepos { get; init; } = Array.Empty<CollaboratedRepos>();

    public Dictionary<string, long>? Languages { get; init; }

    public decimal ActivityIndex { get; init; }

    public string? TopLanguage { get; init; }

    public int StarsCount { get; init; }

    public int CommitsCount { get; init; }

    public int ReposCount { get; init; }
}
