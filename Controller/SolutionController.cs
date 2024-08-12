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
    [HttpGet("getagencyfee")]
    public IActionResult getAgencyFee(double agencyFee)
    {
        return Ok(_solutionService.GetSolution().AgencyFee = agencyFee);
    }
    [HttpGet("getthirdpartyfee")]
    public IActionResult getThirdPartyFee(double thirdPartyFee)
    {
        return Ok(_solutionService.GetSolution().ThirdPartyFee = thirdPartyFee);
    }
    [HttpGet("getworkinghoursfee")]
    public IActionResult getWorkingHoursFee(double workingHoursFee)
    {
        return Ok(_solutionService.GetSolution().WorkingHoursFee = workingHoursFee);
    }

    // [HttpGet("gettargetad")]
    // public IActionResult getTargetAd(string name, bool enhanced)
    // {
    //     
    // }
    //
    //
    //
    // [HttpGet("getnewad/{id}")]
    // public IActionResult getNewAd(string name, double fee, bool enhanced)
    // {
    //     
    // }
    //
    // [HttpDelete("deletead/{id}")]
    // public IActionResult deleteAd(int index)
    // {
    //     
    // }
    [HttpPost("runalgorithm")]
    public IActionResult showResult()
    {
        _solutionService.GetSolution().GoalSeekSolution();
        return Ok(_solutionService.GetSolution().GetTargetAdFee());
    }
}