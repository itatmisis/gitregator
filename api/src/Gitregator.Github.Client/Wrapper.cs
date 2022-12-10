namespace Gitregator.Github.Client;

//
// var pageNum = 1;
// var commits = await client.Connection.Get<Wrapper>(
//     new Uri($"{client.Connection.BaseAddress}search/commits?q=committer:{name}&per_page=100&page={pageNum}"),
//     new Dictionary<string, string>());
public class Wrapper
{
    public IEnumerable<Commit> Items { get; init; } = Array.Empty<Commit>();
}
