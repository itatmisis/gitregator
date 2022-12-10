using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public class User
{
    public int Id { get; init; }

    public decimal ActivityIndex { get; init; }

    public string? TopLanguage { get; init; }

    public Dictionary<string, int>? Languages { get; init; }

    public string Username { get; init; } = null!;

    public string ProfilePicUrl { get; init; } = null!;

    public string Description { get; init; } = null!;

    public string DisplayName { get; init; } = null!;

    public string Location { get; init; } = null!;

    public string? PersonalWebsite { get; init; }

    public string? Company { get; set; }

    public string? Email { get; set; }

    public int StarsCount { get; init; }

    public int FollowersCount { get; set; }

    public int FollowingCount { get; set; }
}
