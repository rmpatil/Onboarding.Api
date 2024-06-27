using Microsoft.AspNetCore.Mvc;
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
}