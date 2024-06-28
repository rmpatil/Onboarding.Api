namespace Onboarding.Api.MockService
{
    public static class Mocks
    {
        private const string JoinerWithSpace = ", ";
        private static readonly Random _rad = new Random();

        private static readonly string[] _locations = { 
            "Luton",
            "London",
            "Cambridge",
            "Watford",
            "Manchester"
        };

        public static string GetLocationsText()
        {
            return  string.Join(JoinerWithSpace, _locations.Take(_rad.Next(0, _locations.Length)).ToArray());
        }

        public static Tuple<string, decimal> LastYearTurnoverFromCompanyHouse()
        {
            var business = "Small";
            var turnOver = (decimal)_rad.Next(1, 5) * 10_000;

            switch (turnOver)
            {
                case decimal n when n > 40_000:
                    business = "Large";
                    break;
                case decimal n when n > 10_000 && n <= 40_000:
                    business = "Medium";
                    break;
            }

            return new Tuple<string, decimal>(business, turnOver);
        }

        public static decimal GetAverageTransactionValue()
        {
            return _rad.Next(30, 100);
        }
    }
}
