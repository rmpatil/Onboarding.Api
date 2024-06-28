namespace Onboarding.Api.Requests
{
    public class OnboardingRequest
    {
        public string CompanyName { get; set; }
        public string Category { get; set; } // "Dentist, "Plumber", "Bakery
        public string[] HowToTakePayments { get; set; } // Face to face or Online
        public string PlansForNext6Months { get; set; } // May be online in the future
    }
}
