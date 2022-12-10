using System.Collections.Generic;

namespace Gitregator.Api.Dtos;

public class User
{
    public int Id { get; init; }

    public string Username { get; init; } = null!;

    public string Description { get; init; } = null!;

    public string ProfilePicUrl { get; init; } = null!;

    public string DisplayName { get; init; } = null!;

    public string PersonalWebsite { get; init; } = null!;

    public int FollowersCount { get; init; }

    public int FollowingCount { get; init; }

    public string? Location { get; init; }

    public string? Company { get; init; }

    public string? Email { get; init; }
}
