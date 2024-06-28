using Microsoft.AspNetCore.Mvc;
using Onboarding.Api.MockService;
using Onboarding.Api.Prompts;
using Onboarding.Api.Requests;
using Onboarding.Api.Services;
[ApiController]
[Route("api/[controller]")]
public class OnboardingController : ControllerBase
{
    private readonly OnboardingService _onboardingService;
    public OnboardingController(OnboardingService onboardingService)
    {
        _onboardingService = onboardingService;
    }
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OnboardingRequest request)
    {
        if (request == null)
        {
            return BadRequest("Request body is null");
        }
        try
        {
            var result = await _onboardingService.GetOnBoardingSummary(request);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }

    [HttpGet]
    public async Task<JsonResult> Get() // List of companies from Company House
    {
        return new JsonResult(new List<Company>()
        {
            new Company { CompanyName = "Prime Bakery", Category = "Bakery" },
            new Company { CompanyName = "Pimlico Plumbers", Category = "Plumber" },
            new Company { CompanyName = "Garston Dental Practice", Category = "Dentist"}
        });
    }
}