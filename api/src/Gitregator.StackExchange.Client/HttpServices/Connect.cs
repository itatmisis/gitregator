using System.Net;
using System.Net.Http.Json;

using Gitregator.StackExchange.Client.Models;

namespace Gitregator.StackExchange.Client.HttpServices;

public static class ConnectToStackExchange
{
    public static async Task<StackExchangeUser?> GetUserByNameAsync(string name, CancellationToken cancellationToken)
    {
        var url = $"https://api.stackexchange.com/2.2/users?order=desc&sort=reputation&inname={name}&site=stackoverflow";
        var users = await GetUserAsync(url, cancellationToken);
        return users.Item2 != 1 ? null : users.Item1;
    }
    public static async Task<(StackExchangeUser?, int)> GetUserAsync(string url, CancellationToken cancellationToken)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        using var client = new HttpClient(handler);
        var users = await client.GetFromJsonAsync<StackExchangeUsersResponse>(url, cancellationToken: cancellationToken);
        var countOfUsers = users?.Items.Count() ?? 0;
        if (users == null || countOfUsers == 0)
        {
            return (null, 0);
        }
        return (users.Items.FirstOrDefault(), countOfUsers);
    }
}
