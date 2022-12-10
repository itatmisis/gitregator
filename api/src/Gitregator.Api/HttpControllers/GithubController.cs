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

    [HttpGet("repository/{url}")]
    public async Task<ActionResult<GetRepositoryAggregationResponse>> GetRepositoryAggregation(string url)
    {
        var result = await _service.GetRepositoryAggregationAsync(url, HttpContext.RequestAborted);
        return Ok(result);
    }

    [HttpGet("member/{id}")]
    public async Task<IActionResult> GetMemberAggregation(string id)
    {
        var result = await _service.GetMemberAggregationAsync(id, HttpContext.RequestAborted);
        return Ok(result);
    }
}
