using System.Threading.Tasks;
using Gitregator.Api.Dtos;
using Gitregator.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Gitregator.Api.HttpControllers;

[ApiController]
[Route("api/v1/github")]
public sealed class GithubController : ControllerBase
{
    private readonly IGithubAggregatorService _service;

    public GithubController(IGithubAggregatorService service)
        => _service = service;

    [HttpGet("repository/{owner}/{name}")]
    public async Task<ActionResult<GetRepositoryAggregationResponse>> GetRepositoryAggregation(string owner, string name)
    {
        var result = await _service.GetRepositoryAggregationAsync(owner, name, HttpContext.RequestAborted);
        return Ok(result);
    }

    [HttpGet("member/{username}")]
    public async Task<IActionResult> GetMemberAggregation(string username)
    {
        var result = await _service.GetMemberAggregationAsync(username, HttpContext.RequestAborted);
        return Ok(result);
    }
}
