using System.Net;
using System.Net.Http.Json;
using System.Text;
using Gitregator.StackExchange.Client.Models;
using Newtonsoft.Json;

namespace Gitregator.StackExchange.Client.HttpServices;

public static class Connect
{
    public static async Task<StackExchangeUser?> GetUserByNameAsync(string name)
    {
        var url = $"https://api.stackexchange.com/2.2/users?order=desc&sort=reputation&inname={name}&site=stackoverflow";
        return (await GetUserAsync(url)).Item1;
    }
    public static async Task<(StackExchangeUser?, int)> GetUserAsync(string url)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        };

        using var client = new HttpClient(handler);
        var users = await client.GetFromJsonAsync<StackExchangeUsersResponse>(url);
        var countOfUsers = users?.Items.Count() ?? 0;
        var user = users!.Items.FirstOrDefault();
        return (user, countOfUsers);
    }
}
