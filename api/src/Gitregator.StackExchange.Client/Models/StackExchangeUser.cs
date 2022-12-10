using System.Text.Json.Serialization;


namespace Gitregator.StackExchange.Client.Models;

public abstract class StackExchangeUser
{
    [JsonPropertyName("badage_counts")]
    public BadgeCount? BadageCounts { get; set; }
    [JsonPropertyName("view_count")]
    public int ViewCount { get; set; }
    [JsonPropertyName("down_vote_count")]
    public int DownVoteCount { get; set; }
    [JsonPropertyName("up_vote_count")]
    public int UpVoteCount { get; set; }
    [JsonPropertyName("answer_count")]
    public int AnswerCount { get; set; }
    [JsonPropertyName("question_count")]
    public int QuestionCount { get; set; }
    [JsonPropertyName("account_id")]
    public int AccountId { get; set; }
    [JsonPropertyName("reputation")]
    public int Reputation { get; set; }
    [JsonPropertyName("reputation_change_day")]
    public int ReputationChangeDay { get; set; }
    [JsonPropertyName("reputation_change_week")]
    public int ReputationChangeWeek { get; set; }
    [JsonPropertyName("reputation_change_month")]
    public int ReputationChangeMonth { get; set; }
    [JsonPropertyName("reputation_change_quarter")]
    public int ReputationChangeQuarter { get; set; }
    [JsonPropertyName("reputation_change_year")]
    public int ReputationChangeYear { get; set; }
    [JsonPropertyName("user_id")]
    public int UserId { get; set; }
    [JsonPropertyName("accept_rate")]
    public int AcceptRate { get; set; }
    [JsonPropertyName("website_url")]
    public string? WebsiteUrl { get; set; }
    [JsonPropertyName("link")]
    public string? Link { get; set; }
    [JsonPropertyName("display_name")]
    public string? DisplayName { get; set; }
}
