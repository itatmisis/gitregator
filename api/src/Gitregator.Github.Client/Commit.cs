using System.Text.Json.Serialization;

namespace Gitregator.Github.Client;

    public class Author
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [JsonPropertyName("login")]
        public string? Login { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string? GravatarId { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonPropertyName("followers_url")]
        public string? FollowersUrl { get; set; }

        [JsonPropertyName("following_url")]
        public string? FollowingUrl { get; set; }

        [JsonPropertyName("gists_url")]
        public string? GistsUrl { get; set; }

        [JsonPropertyName("starred_url")]
        public string? StarredUrl { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string? SubscriptionsUrl { get; set; }

        [JsonPropertyName("organizations_url")]
        public string? OrganizationsUrl { get; set; }

        [JsonPropertyName("repos_url")]
        public string? ReposUrl { get; set; }

        [JsonPropertyName("events_url")]
        public string? EventsUrl { get; set; }

        [JsonPropertyName("received_events_url")]
        public string? ReceivedEventsUrl { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public class Commit
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("author")]
        public Author? Author { get; set; }

        [JsonPropertyName("committer")]
        public Committer? Committer { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("tree")]
        public Tree? Tree { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }
    }

    public class Committer
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("email")]
        public string? Email { get; set; }
    }

    public class Owner
    {
        [JsonPropertyName("login")]
        public string? Login { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }

        [JsonPropertyName("avatar_url")]
        public string? AvatarUrl { get; set; }

        [JsonPropertyName("gravatar_id")]
        public string? GravatarId { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonPropertyName("followers_url")]
        public string? FollowersUrl { get; set; }

        [JsonPropertyName("following_url")]
        public string? FollowingUrl { get; set; }

        [JsonPropertyName("gists_url")]
        public string? GistsUrl { get; set; }

        [JsonPropertyName("starred_url")]
        public string? StarredUrl { get; set; }

        [JsonPropertyName("subscriptions_url")]
        public string? SubscriptionsUrl { get; set; }

        [JsonPropertyName("organizations_url")]
        public string? OrganizationsUrl { get; set; }

        [JsonPropertyName("repos_url")]
        public string? ReposUrl { get; set; }

        [JsonPropertyName("events_url")]
        public string? EventsUrl { get; set; }

        [JsonPropertyName("received_events_url")]
        public string? ReceivedEventsUrl { get; set; }

        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("site_admin")]
        public bool SiteAdmin { get; set; }
    }

    public class Parent
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonPropertyName("sha")]
        public string? Sha { get; set; }
    }

    public class Repository
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("full_name")]
        public string? FullName { get; set; }

        [JsonPropertyName("owner")]
        public Owner? Owner { get; set; }

        [JsonPropertyName("private")]
        public bool Private { get; set; }

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("fork")]
        public bool Fork { get; set; }

        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("forks_url")]
        public string? ForksUrl { get; set; }

        [JsonPropertyName("keys_url")]
        public string? KeysUrl { get; set; }

        [JsonPropertyName("collaborators_url")]
        public string? CollaboratorsUrl { get; set; }

        [JsonPropertyName("teams_url")]
        public string? TeamsUrl { get; set; }

        [JsonPropertyName("hooks_url")]
        public string? HooksUrl { get; set; }

        [JsonPropertyName("issue_events_url")]
        public string? IssueEventsUrl { get; set; }

        [JsonPropertyName("events_url")]
        public string? EventsUrl { get; set; }

        [JsonPropertyName("assignees_url")]
        public string? AssigneesUrl { get; set; }

        [JsonPropertyName("branches_url")]
        public string? BranchesUrl { get; set; }

        [JsonPropertyName("tags_url")]
        public string? TagsUrl { get; set; }

        [JsonPropertyName("blobs_url")]
        public string? BlobsUrl { get; set; }

        [JsonPropertyName("git_tags_url")]
        public string? GitTagsUrl { get; set; }

        [JsonPropertyName("git_refs_url")]
        public string? GitRefsUrl { get; set; }

        [JsonPropertyName("trees_url")]
        public string? TreesUrl { get; set; }

        [JsonPropertyName("statuses_url")]
        public string? StatusesUrl { get; set; }

        [JsonPropertyName("languages_url")]
        public string? LanguagesUrl { get; set; }

        [JsonPropertyName("stargazers_url")]
        public string? StargazersUrl { get; set; }

        [JsonPropertyName("contributors_url")]
        public string? ContributorsUrl { get; set; }

        [JsonPropertyName("subscribers_url")]
        public string? SubscribersUrl { get; set; }

        [JsonPropertyName("subscription_url")]
        public string? SubscriptionUrl { get; set; }

        [JsonPropertyName("commits_url")]
        public string? CommitsUrl { get; set; }

        [JsonPropertyName("git_commits_url")]
        public string? GitCommitsUrl { get; set; }

        [JsonPropertyName("comments_url")]
        public string? CommentsUrl { get; set; }

        [JsonPropertyName("issue_comment_url")]
        public string? IssueCommentUrl { get; set; }

        [JsonPropertyName("contents_url")]
        public string? ContentsUrl { get; set; }

        [JsonPropertyName("compare_url")]
        public string? CompareUrl { get; set; }

        [JsonPropertyName("merges_url")]
        public string? MergesUrl { get; set; }

        [JsonPropertyName("archive_url")]
        public string? ArchiveUrl { get; set; }

        [JsonPropertyName("downloads_url")]
        public string? DownloadsUrl { get; set; }

        [JsonPropertyName("issues_url")]
        public string? IssuesUrl { get; set; }

        [JsonPropertyName("pulls_url")]
        public string? PullsUrl { get; set; }

        [JsonPropertyName("milestones_url")]
        public string? MilestonesUrl { get; set; }

        [JsonPropertyName("notifications_url")]
        public string? NotificationsUrl { get; set; }

        [JsonPropertyName("labels_url")]
        public string? LabelsUrl { get; set; }

        [JsonPropertyName("releases_url")]
        public string? ReleasesUrl { get; set; }

        [JsonPropertyName("deployments_url")]
        public string? DeploymentsUrl { get; set; }
    }

    public class Root
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("sha")]
        public string? Sha { get; set; }

        [JsonPropertyName("html_url")]
        public string? HtmlUrl { get; set; }

        [JsonPropertyName("comments_url")]
        public string? CommentsUrl { get; set; }

        [JsonPropertyName("commit")]
        public Commit? Commit { get; set; }

        [JsonPropertyName("author")]
        public Author? Author { get; set; }

        [JsonPropertyName("committer")]
        public Committer? Committer { get; set; }

        [JsonPropertyName("parents")]
        public List<Parent>? Parents { get; set; }

        [JsonPropertyName("repository")]
        public Repository? Repository { get; set; }

        [JsonPropertyName("score")]
        public int Score { get; set; }

        [JsonPropertyName("node_id")]
        public string? NodeId { get; set; }
    }

    public class Tree
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        [JsonPropertyName("sha")]
        public string? Sha { get; set; }
    }


