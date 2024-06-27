namespace Onboarding.Api.MockService
{
    public class BusinessRevenueService
    {

        public string GetCompanySize(decimal annualTurnover)
        {
            if (annualTurnover < 50000)
            {
                return "Small";
            }
            else if (annualTurnover >= 50001 && annualTurnover <= 150000)
            {
                return "Medium";
            }
            else if (annualTurnover >= 150001 && annualTurnover <= 950000)
            {
                return "Large";
            }
            else
            {
                // Handle cases where annual turnover is outside the defined ranges
                return "Unknown"; // or any other appropriate handling
            }
        }
    }
}
