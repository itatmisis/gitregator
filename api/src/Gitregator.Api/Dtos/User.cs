namespace Gitregator.Api.Dtos;

public class User
{
    public long Id { get; init; }

    public decimal ActivityIndex { get; init; }

    public string TopLanguage { get; init; } = null!;

    public string Username { get; init; } = null!;

    public string ProfilePicUrl { get; init; } = null!;

    public string Description { get; init; } = null!;

    public string DisplayName { get; init; } = null!;

    public string Location { get; init; } = null!;

    public string PersonalWebsite { get; init; } = null!;

    public string Twitter { get; init; } = null!;

    public int StarsCount { get; init; }
}
