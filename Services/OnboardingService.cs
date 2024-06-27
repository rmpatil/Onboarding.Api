using Onboarding.Api.MockService;
using Onboarding.Api.Requests;
using Onboarding.Api.Response;

namespace Onboarding.Api.Services
{
    public class OnboardingService
    {
        private readonly OpenAIService1 _openAIService1;
        private readonly BusinessRevenueService _businessRevenueService;
        private readonly MccMockService _mccMockService;
        private List<ChatMessage> _messages;
        public OnboardingService(OpenAIService1 openAIService, BusinessRevenueService businessRevenueService, MccMockService mccMockService)
        {
            _openAIService1 = openAIService;
            _businessRevenueService = businessRevenueService;
            _mccMockService = mccMockService;
            _messages = new List<ChatMessage>();
        }
        public async Task<OnBoardingSummary> GetOnBoardingSummary(OnboardingRequest request)
        {
            // Construct the Prompt using request fields

            string companySize = _businessRevenueService.GetCompanySize(request.AnnualTurnOver);
            int mccCode= _mccMockService.GetMockMccCode();




            _messages.Add(new ChatMessage()
            {
                Role= "user",
                Content = request.FieldOne.ToString()
            });

            try
            {
                var result = await _openAIService1.GenerateChatCompletion(_messages);
                return new OnBoardingSummary()
                {
                    Summary = result,
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
    }
}
