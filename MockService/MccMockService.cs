namespace Onboarding.Api.MockService
{
    using System;
    using System.Collections.Generic;
    public class MccMockService
    {
        public int GetMockMccCode()
        {
            var random = new Random();
            var mockData = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                mockData.Add(random.Next(1000, 10000)); // Generates a random 4-digit number
            }
            return mockData.FirstOrDefault();
        }
    }
}
