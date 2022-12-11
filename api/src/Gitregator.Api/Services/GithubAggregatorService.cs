using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ClosedXML.Excel;
using Gitregator.Github.Client;
using Gitregator.Api.Dtos;
using Gitregator.StackExchange.Client.HttpServices;
using Octokit;

namespace Gitregator.Api.Services;

public sealed class GithubAggregatorService : IGithubAggregatorService
{
    private readonly GithubClientProvider _provider;

    public GithubAggregatorService(GithubClientProvider provider)
        => _provider = provider;

    public async Task<GetRepositoryAggregationResponse> GetRepositoryAggregationAsync(
        string owner,
        string name,
        CancellationToken cancellationToken)
    {
        var client = _provider.GetClient();
        var repository = await client.Repository.Get(owner, name);
        var contributors = await client.Repository.GetAllContributors(owner, name);
        var issues = await client.Issue.GetAllForRepository(owner, name);
        var issuers = issues.Select(x => x.User).Distinct().ToList();
        var contids = contributors.Select(x => x.Login);
        var users = new List<Collaborator>();
        var usersTasks = contids.Select(con => client.User.Get(con)).ToList();
        var openRepositoryCommits = await client.Repository.Commit.GetAll(owner, name);
        var openRepositoryIssues = await client.Issue.GetAllForRepository(owner, name);
        var repositoryPullRequests = await client.PullRequest.GetAllForRepository(owner, name);
        var repositoryLanguages = await client.Repository.GetAllLanguages(owner, name);

        var usersGit = await Task.WhenAll(usersTasks);

        // TODO: Fix for all pages
        var tasks22 = usersGit.Where(x => !x.Login.Contains("-")).Select(
            x => client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/commits?q=committer:{x.Login}&per_page=100"),
                new Dictionary<string, string>()));

        var tasks22Result = await Task.WhenAll(tasks22);

        users.AddRange(usersGit.Select(x =>
        {
            var author = tasks22Result.FirstOrDefault(z =>
                    z.Body.Items.FirstOrDefault()?.Author?.Login == x.Login)?.Body;
            decimal commitsCountPerMonth = (decimal)author?.Items
                .Where(t => t!.Commit!.Author!.Date > DateTime.Now.AddMonths(-1)).ToList().Count!;
            decimal commitsCountPerYear = (decimal)author.Items
                .Where(t => t!.Commit!.Author!.Date > DateTime.Now.AddYears(-1)).ToList().Count! + 1;
            return new Collaborator()
            {
                Id = x.Id,
                Username = x.Login,
                DisplayName = x.Name,
                ProfilePicUrl = x.AvatarUrl,
                Description = x.Bio,
                Location = x.Location,
                PersonalWebsite = x.Blog,
                Email = x.Email,
                Company = x.Company,
                FollowersCount = x.Followers,
                FollowingCount = x.Following,
                CommitsTotal = author?.TotalCount ?? 0,
                ActivityIndex = Math.Round(commitsCountPerMonth / commitsCountPerYear, 1)
            };
        }));

        var issuersTasks = new List<Task<Octokit.User>>();
        var issuersDto = new List<Collaborator>();
        foreach (var iss in issuers)
        {
            var issuerDto = new Collaborator
            {
                Id = iss.Id,
                Username = iss.Login,
                DisplayName = iss.Name,
                ProfilePicUrl = iss.AvatarUrl,
                Description = iss.Bio,
                Location = iss.Location,
                PersonalWebsite = iss.Blog,
                Email = iss.Email,
                Company = iss.Company,
                FollowersCount = iss.Followers,
                FollowingCount = iss.Following,
            };
            issuersDto.Add(issuerDto);
        }

        return
            new GetRepositoryAggregationResponse
            {
                RepositoryName = repository.Name,
                RepositoryHttpUrl = repository.HtmlUrl,
                RepositoryOwner = repository.Owner.Login,
                RepositoryDescription = repository.Description,
                Collaborators = users,
                Issuers = issuersDto,
                OpenCommitsTotal = openRepositoryCommits.Count,
                OpenIssuesTotal = openRepositoryIssues.Count,
                PullRequestsTotal = repositoryPullRequests.Count,
                Languages = repositoryLanguages.ToDictionary(x => x.Name, x => x.NumberOfBytes),
                MostUsedLanguage = repositoryLanguages.MaxBy(x => x.NumberOfBytes)!.Name,
            };
    }

    public async Task<byte[]> GetRepositoryAggregationExcelAsync(
        string owner,
        string name,
        CancellationToken cancellationToken)
    {
        var client = _provider.GetClient();
        var repository = await client.Repository.Get(owner, name);
        var contributors = await client.Repository.GetAllContributors(owner, name);
        var issues = await client.Issue.GetAllForRepository(owner, name);
        var issuers = issues.Select(x => x.User).Distinct().ToList();
        var contids = contributors.Select(x => x.Login);
        var users = new List<Collaborator>();
        var usersTasks = contids.Select(con => client.User.Get(con)).ToList();
        var openRepositoryCommits = await client.Repository.Commit.GetAll(owner, name);
        var openRepositoryIssues = await client.Issue.GetAllForRepository(owner, name);
        var repositoryPullRequests = await client.PullRequest.GetAllForRepository(owner, name);
        var repositoryLanguages = await client.Repository.GetAllLanguages(owner, name);

        var usersGit = await Task.WhenAll(usersTasks);

        // TODO: Fix for all pages
        var tasks22 = usersGit.Where(x => !x.Login.Contains("-")).Select(
            x => client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/commits?q=committer:{x.Login}&per_page=100"),
                new Dictionary<string, string>()));

        var tasks22Result = await Task.WhenAll(tasks22);

        users.AddRange(
            usersGit.Select(
                x =>
                {
                    var author = tasks22Result.FirstOrDefault(
                        z =>
                            z.Body.Items.FirstOrDefault()?.Author?.Login == x.Login)?.Body;
                    decimal commitsCountPerMonth = (decimal) author?.Items
                        .Where(t => t!.Commit!.Author!.Date > DateTime.Now.AddMonths(-1)).ToList().Count!;
                    decimal commitsCountPerYear = (decimal) author.Items
                        .Where(t => t!.Commit!.Author!.Date > DateTime.Now.AddYears(-1)).ToList().Count! + 1;
                    return new Collaborator()
                    {
                        Id = x.Id,
                        Username = x.Login,
                        DisplayName = x.Name,
                        ProfilePicUrl = x.AvatarUrl,
                        Description = x.Bio,
                        Location = x.Location,
                        PersonalWebsite = x.Blog,
                        Email = x.Email,
                        Company = x.Company,
                        FollowersCount = x.Followers,
                        FollowingCount = x.Following,
                        CommitsTotal = author?.TotalCount ?? 0,
                        ActivityIndex = Math.Round(commitsCountPerMonth / commitsCountPerYear, 1)
                    };
                }));

        var issuersTasks = new List<Task<Octokit.User>>();
        var issuersDto = new List<Collaborator>();
        foreach (var iss in issuers)
        {
            var issuerDto = new Collaborator
            {
                Id = iss.Id,
                Username = iss.Login,
                DisplayName = iss.Name,
                ProfilePicUrl = iss.AvatarUrl,
                Description = iss.Bio,
                Location = iss.Location,
                PersonalWebsite = iss.Blog,
                Email = iss.Email,
                Company = iss.Company,
                FollowersCount = iss.Followers,
                FollowingCount = iss.Following,
            };
            issuersDto.Add(issuerDto);
        }

        var rowCount = 0;
        using var memor = new MemoryStream();
        using (var workbook = new XLWorkbook())
        {
            var worksheet = workbook.Worksheets.Add("stat");
            rowCount = 1;
            worksheet.Cell(rowCount, 1).Value = "Репозиторий:";
            worksheet.Cell(rowCount, 2).Value = $" {repository.Owner}/{repository.Name}";
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Ссылка:";
            worksheet.Cell(rowCount, 2).Value = repository.HtmlUrl;
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Всего коммитов:";
            worksheet.Cell(rowCount, 2).Value = openRepositoryCommits.Count;
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Всего пулл реквестов:";
            worksheet.Cell(rowCount, 2).Value = repositoryPullRequests.Count;
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Всего проблем:";
            worksheet.Cell(rowCount, 2).Value = openRepositoryIssues.Count;
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Самый используемый язык:";
            worksheet.Cell(rowCount, 2).Value = repositoryLanguages.MaxBy(x => x.NumberOfBytes)?.Name;
            rowCount += 2;
            worksheet.Cell(rowCount, 1).Value = "Коллабораторы:";
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Имя пользователя";
            worksheet.Cell(rowCount, 2).Value = "Отоброжаемое имя";
            worksheet.Cell(rowCount, 3).Value = "Описание";
            worksheet.Cell(rowCount, 4).Value = "Email";
            worksheet.Cell(rowCount, 5).Value = "Подписчики";
            worksheet.Cell(rowCount, 6).Value = "Подписки";
            worksheet.Cell(rowCount, 7).Value = "Кол-во комитов";
            worksheet.Cell(rowCount, 8).Value = "Кол-во открытых проблем";
            worksheet.Cell(rowCount, 9).Value = "Кол-во пулл реквестов";
            worksheet.Cell(rowCount, 10).Value = "Личный сайт";
            worksheet.Cell(rowCount, 11).Value = "Индекс активности";
            rowCount++;
            foreach (var user in users)
            {
                    worksheet.Cell(rowCount, 1).Value = user.Username;
                    worksheet.Cell(rowCount, 2).Value = user.DisplayName;
                    worksheet.Cell(rowCount, 3).Value = user.Description;
                    worksheet.Cell(rowCount, 4).Value = user.Email;
                    worksheet.Cell(rowCount, 5).Value = user.FollowersCount;
                    worksheet.Cell(rowCount, 6).Value = user.FollowingCount;
                    worksheet.Cell(rowCount, 7).Value = user.CommitsTotal;
                    worksheet.Cell(rowCount, 8).Value = user.IssuesTotal;
                    worksheet.Cell(rowCount, 9).Value = user.PullRequestsTotal;
                    worksheet.Cell(rowCount, 10).Value = user.PersonalWebsite;
                    worksheet.Cell(rowCount, 11).Value = user.ActivityIndex;
                    rowCount++;
            }

            rowCount += 2;
            worksheet.Cell(rowCount, 1).Value = "Репортеры:";
            rowCount++;
            worksheet.Cell(rowCount, 1).Value = "Имя пользователя";
            worksheet.Cell(rowCount, 2).Value = "Отоброжаемое имя";
            worksheet.Cell(rowCount, 3).Value = "Описание";
            worksheet.Cell(rowCount, 4).Value = "Email";
            worksheet.Cell(rowCount, 5).Value = "Подписчики";
            worksheet.Cell(rowCount, 6).Value = "Подписки";
            worksheet.Cell(rowCount, 7).Value = "Кол-во комитов";
            worksheet.Cell(rowCount, 8).Value = "Кол-во открытых проблем";
            worksheet.Cell(rowCount, 9).Value = "Кол-во пулл реквестов";
            worksheet.Cell(rowCount, 10).Value = "Личный сайт";
            worksheet.Cell(rowCount, 11).Value = "Индекс активности";
            rowCount++;
            foreach (var user in issuersDto)
            {
                worksheet.Cell(rowCount, 1).Value = user.Username;
                worksheet.Cell(rowCount, 2).Value = user.DisplayName;
                worksheet.Cell(rowCount, 3).Value = user.Description;
                worksheet.Cell(rowCount, 4).Value = user.Email;
                worksheet.Cell(rowCount, 5).Value = user.FollowersCount;
                worksheet.Cell(rowCount, 6).Value = user.FollowingCount;
                worksheet.Cell(rowCount, 7).Value = user.CommitsTotal;
                worksheet.Cell(rowCount, 8).Value = user.IssuesTotal;
                worksheet.Cell(rowCount, 9).Value = user.PullRequestsTotal;
                worksheet.Cell(rowCount, 10).Value = user.PersonalWebsite;
                worksheet.Cell(rowCount, 11).Value = user.ActivityIndex;
                rowCount++;
            }
            rowCount++;
            workbook.SaveAs(memor);

            return memor.ToArray();
        }
    }

    public async Task<GetMemberAggregationResponse> GetMemberAggregationAsync(string userLogin,
        CancellationToken cancellationToken)
    {
        var client = _provider.GetClient();
        var userSource = await client.User.Get(userLogin);

        var starsCount = (await client.Activity.Starring.GetAllForUser(userLogin)).Count;

        // Get count of commit pages
        var commitsPageNum = Math.Ceiling((double)(await client.Connection.Get<Wrapper>(
            new Uri(
                $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=1"),
            new Dictionary<string, string>())).Body.TotalCount / 100);

        var tasks = new List<Task<IApiResponse<Wrapper>>>();

        // Get count of commits
        for (var i = 1; i <= commitsPageNum; i++)
        {
            tasks.Add(client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=100&page={i}"),
                new Dictionary<string, string>()));
        }

        var commits = (await Task.WhenAll(tasks)).SelectMany(x => x.Body.Items).ToList();

        tasks = new List<Task<IApiResponse<Wrapper>>>
        {
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:pull-request&per_page=1"),
                new Dictionary<string, string>()),
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:issue&per_page=1"),
                new Dictionary<string, string>())
        };

        var taskRes = (await Task.WhenAll(tasks)).ToList();

        var pullRequestsCount = taskRes[0].Body.TotalCount;
        var issuesCount = taskRes[1].Body.TotalCount;

        var repos = commits.Select(x => x.Repository).DistinctBy(x => x!.Id).ToList();
        var reposCount = repos.Count;

        var languageTasks = repos.Select(repo => client.Repository.GetAllLanguages(repo!.Owner!.Login, repo.Name))
            .ToList();

        var languagesList = await Task.WhenAll(languageTasks);

        var groupedLanguages = languagesList.SelectMany(x => x).GroupBy(x => x.Name).ToList();

        var languages = groupedLanguages.ToDictionary(t => t.Key, t => t.Sum(x => x.NumberOfBytes));

        var activity = Math.Round(
            (decimal)commits.Where(x => x!.Commit!.Author!.Date > DateTime.Now.AddMonths(-1)).ToList().Count
            / commits.Where(x => x!.Commit!.Author!.Date > DateTime.Now.AddYears(-1)).ToList().Count * 10, 1);

        var stackExchangeUser = await ConnectToStackExchange.GetUserByNameAsync(userLogin, cancellationToken);

        var user = new ExtendedUser()
        {
            Id = userSource.Id,
            Username = userSource.Login,
            DisplayName = userSource.Name,
            ProfilePicUrl = userSource.AvatarUrl,
            Description = userSource.Bio,
            Location = userSource.Location,
            PersonalWebsite = userSource.Blog,
            Email = userSource.Email,
            Company = userSource.Company,
            FollowersCount = userSource.Followers,
            FollowingCount = userSource.Following,
            StarsCount = starsCount,
            CommitsCount = commits.Count,
            ReposCount = reposCount,
            Languages = languages,
            TopLanguage = languages.OrderByDescending(x => x.Value).FirstOrDefault().Key,
            StackOverflowUrl = stackExchangeUser?.Link,
            ActivityIndex = activity,
            PullRequestsCount = pullRequestsCount,
            IssuesCount = issuesCount
        };

        return new GetMemberAggregationResponse { User = user };
    }

        public async Task<byte[]> GetMemberAggregationExcelAsync(string userLogin,
        CancellationToken cancellationToken)
    {
        var client = _provider.GetClient();
        var userSource = await client.User.Get(userLogin);

        var starsCount = (await client.Activity.Starring.GetAllForUser(userLogin)).Count;

        // Get count of commit pages
        var commitsPageNum = Math.Ceiling((double)(await client.Connection.Get<Wrapper>(
            new Uri(
                $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=1"),
            new Dictionary<string, string>())).Body.TotalCount / 100);

        var tasks = new List<Task<IApiResponse<Wrapper>>>();

        // Get count of commits
        for (var i = 1; i <= commitsPageNum; i++)
        {
            tasks.Add(client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/commits?q=committer:{userLogin}&per_page=100&page={i}"),
                new Dictionary<string, string>()));
        }

        var commits = (await Task.WhenAll(tasks)).SelectMany(x => x.Body.Items).ToList();

        tasks = new List<Task<IApiResponse<Wrapper>>>
        {
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:pull-request&per_page=1"),
                new Dictionary<string, string>()),
            client.Connection.Get<Wrapper>(
                new Uri(
                    $"{client.Connection.BaseAddress}search/issues?q=user:{userLogin} is:issue&per_page=1"),
                new Dictionary<string, string>())
        };

        var taskRes = (await Task.WhenAll(tasks)).ToList();

        var pullRequestsCount = taskRes[0].Body.TotalCount;
        var issuesCount = taskRes[1].Body.TotalCount;

        var repos = commits.Select(x => x.Repository).DistinctBy(x => x!.Id).ToList();
        var reposCount = repos.Count;

        var languageTasks = repos.Select(repo => client.Repository.GetAllLanguages(repo!.Owner!.Login, repo.Name))
            .ToList();

        var languagesList = await Task.WhenAll(languageTasks);

        var groupedLanguages = languagesList.SelectMany(x => x).GroupBy(x => x.Name).ToList();

        var languages = groupedLanguages.ToDictionary(t => t.Key, t => t.Sum(x => x.NumberOfBytes));

        var activity = Math.Round(
            (decimal)commits.Where(x => x!.Commit!.Author!.Date > DateTime.Now.AddMonths(-1)).ToList().Count
            / commits.Where(x => x!.Commit!.Author!.Date > DateTime.Now.AddYears(-1)).ToList().Count * 10, 1);

        var stackExchangeUser = await ConnectToStackExchange.GetUserByNameAsync(userLogin, cancellationToken);

        var user = new ExtendedUser()
        {
            Id = userSource.Id,
            Username = userSource.Login,
            DisplayName = userSource.Name,
            ProfilePicUrl = userSource.AvatarUrl,
            Description = userSource.Bio,
            Location = userSource.Location,
            PersonalWebsite = userSource.Blog,
            Email = userSource.Email,
            Company = userSource.Company,
            FollowersCount = userSource.Followers,
            FollowingCount = userSource.Following,
            StarsCount = starsCount,
            CommitsCount = commits.Count,
            ReposCount = reposCount,
            Languages = languages,
            TopLanguage = languages.OrderByDescending(x => x.Value).FirstOrDefault().Key,
            StackOverflowUrl = stackExchangeUser?.Link,
            ActivityIndex = activity,
            PullRequestsCount = pullRequestsCount,
            IssuesCount = issuesCount
        };

        return new byte[64];
    }
}
