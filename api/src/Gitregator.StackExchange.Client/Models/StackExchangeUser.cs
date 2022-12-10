using System.Text.Json.Serialization;
using Newtonsoft.Json;


namespace Gitregator.StackExchange.Client.Models;

public class StackExchangeUser
{
    [JsonProperty("badage_counts")]
    public BadgeCount? BadageCounts { get; set; }
    [JsonProperty("view_count")]
    public int ViewCount { get; set; }
    [JsonProperty("down_vote_count")]
    public int DownVoteCount { get; set; }
    [JsonProperty("up_vote_count")]
    public int UpVoteCount { get; set; }
    [JsonProperty("answer_count")]
    public int AnswerCount { get; set; }
    [JsonProperty("question_count")]
    public int QuestionCount { get; set; }
    [JsonProperty("account_id")]
    public int AccountId { get; set; }
    [JsonProperty("reputation")]
    public int Reputation { get; set; }
    [JsonProperty("reputation_change_day")]
    public int ReputationChangeDay { get; set; }
    [JsonProperty("reputation_change_week")]
    public int ReputationChangeWeek { get; set; }
    [JsonProperty("reputation_change_month")]
    public int ReputationChangeMonth { get; set; }
    [JsonProperty("reputation_change_quarter")]
    public int ReputationChangeQuarter { get; set; }
    [JsonProperty("reputation_change_year")]
    public int ReputationChangeYear { get; set; }
    [JsonProperty("user_id")]
    public int UserId { get; set; }
    [JsonProperty("accept_rate")]
    public int AcceptRate { get; set; }
    [JsonProperty("website_url")]
    public string? WebsiteUrl { get; set; }
    [JsonProperty("link")]
    public string? Link { get; set; }
    [JsonProperty("display_name")]
    public string? DisplayName { get; set; }
}
