namespace Gitregator.StackExchange.Client.Models;

public class StackExchangeUsersResponse
{
    public IEnumerable<StackExchangeUser> Items { get; set; } = Array.Empty<StackExchangeUser>();
}
