using Microsoft.AspNetCore.Mvc;

namespace dentsu.Controller;

[Route("api/solution")]
[ApiController]
public class SolutionController : ControllerBase
{

    private ISolutionService _solutionService;

    public SolutionController(ISolutionService solutionService)
    {
        _solutionService = solutionService;
    }
    [HttpGet("getbudget")]
    public IActionResult getTotalBudget(double totalBudget)
    {
        return Ok(_solutionService.GetSolution().TotalBudget = totalBudget);
    }
    [HttpGet("get0")]
    public IActionResult getzero()
    {
        return Ok(1);
    }
}