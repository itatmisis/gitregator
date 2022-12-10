using System;
using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public sealed class ExtendedUser : User
{
    public Dictionary<string, long>? Languages { get; init; }

    public decimal ActivityIndex { get; init; }

    public string? TopLanguage { get; init; }

    public int StarsCount { get; init; }

    public int CommitsCount { get; init; }

    public int ReposCount { get; init; }

    public string? StackOverflowUrl { get; init; }

    public int PullRequestsCount { get; init; }

    public int IssuesCount { get; init; }
}
