using System.Threading.Tasks;
using Gitregator.Api.Dtos;
using Gitregator.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Octokit;

namespace Gitregator.Api.HttpControllers;

[ApiController]
[Route("api/v1/github")]
public sealed class GithubController : ControllerBase
{
    private readonly IGithubAggregatorService _service;

    public GithubController(IGithubAggregatorService service)
        => _service = service;

    /// <summary>
    /// Gets the collaborators of repository and some info about it.
    /// </summary>
    /// <param name="owner">Owner of repository</param>
    /// <param name="name">Name of repository</param>
    /// <remarks>
    /// <p><b>activityIndex from 0 to 10</b></p>
    /// <p><b>email, company, location, repositoryDescription can be null</b></p>
    /// </remarks>
    /// <response code="200">Returns Json representation of repository like GetRepositoryAggregationResponse</response>
    /// <response code="404">If the Repository is not found</response>
    [HttpGet("repository/{owner}/{name}")]
    [ProducesResponseType(typeof(GetRepositoryAggregationResponse), 200)]
    public async Task<ActionResult<GetRepositoryAggregationResponse>> GetRepositoryAggregation(string owner, string name)
    {
        try
        {
            var result = await _service.GetRepositoryAggregationAsync(owner, name, HttpContext.RequestAborted);
            return Ok(result);
        }
        catch (Octokit.NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Gets the collaborators of repository and some info about it in Excel format.
    /// </summary>
    /// <param name="owner">Owner of repository</param>
    /// <param name="name">Name of repository</param>
    /// <remarks>
    /// <p><b>activityIndex from 0 to 10</b></p>
    /// <p><b>email, company, location, repositoryDescription can be null</b></p>
    /// </remarks>
    /// <response code="200">Returns Excel representation of repository like GetRepositoryAggregationResponse</response>
    /// <response code="404">If the Repository is not found</response>
    [HttpGet("repository/excel/{owner}/{name}")]
    public async Task<IActionResult> GetRepositoryAggregationExcel(string owner, string name)
    {
        try
        {
            var result = await _service.GetRepositoryAggregationExcelAsync(owner, name, HttpContext.RequestAborted);
            return File(result, "xlsx/application", "report.xlsx");
        }
        catch (Octokit.NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Gets the aggregated data for a user.
    /// </summary>
    /// <param name="username">User name from github</param>
    /// <remarks>
    /// <p><b>activityIndex from 0 to 10</b></p>
    /// <p><b>email, company, location can be null</b></p>
    /// </remarks>
    /// <response code="200">Returns Json representation of one User like GetMemberAggregationResponse</response>
    /// <response code="404">If the User is not found</response>
    [HttpGet("member/{username}")]
    [ProducesResponseType(typeof(GetMemberAggregationResponse), 200)]
    public async Task<IActionResult> GetMemberAggregation(string username)
    {
        try
        {
            var result = await _service.GetMemberAggregationAsync(username, HttpContext.RequestAborted);
            return Ok(result);
        }
        catch (NotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
