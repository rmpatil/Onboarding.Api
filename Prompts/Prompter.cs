using System.Reflection;
using Onboarding.Api.MockService;

namespace Onboarding.Api.Prompts
{
    public class Prompter
    {
        private const string SIZE = "<SIZE>";
        private const string TURN_OVER = "<TURN_OVER>";
        private const string CATEGORY = "<CATEGORY>";
        private const string LOCATIONS = "<LOCATIONS>";
        private const string AVERAGE = "<AVERAGE>";
        private const string HOW = "<HOW>";
        private const string PLAN = "<PLAN>";
        private const string NATWEST = "<NATWEST>";
        private const string JoinerWithSpace = ", ";

        public string GetRefinedPrompt(string category, string[] options, string plans, bool isNatWest)
        {
            var promptText = GetPromptText();

            // Replace
            var businessInfo = Mocks.LastYearTurnoverFromCompanyHouse();

            promptText = promptText
                .Replace(SIZE, businessInfo.Item1)
                .Replace(TURN_OVER, businessInfo.Item2.ToString("c"))
                .Replace(CATEGORY, category)
                .Replace(LOCATIONS, Mocks.GetLocationsText())
                .Replace(AVERAGE, Mocks.GetAverageTransactionValue().ToString("c"))
                .Replace(HOW, string.Join(JoinerWithSpace, options))
                .Replace(NATWEST, isNatWest ? "I am a NatWest customer" : "I am not a NatWest customer");

            if (!string.IsNullOrWhiteSpace(plans)) {
                promptText = promptText.Replace(PLAN, plans);
            }


            return promptText;
        }
        private static string GetPromptText()
        {
            FileInfo _file = new FileInfo(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "//Prompts//MainPrompt.txt");

            if (_file.Exists)
            {
                using var reader = _file.OpenText();
                return reader.ReadToEnd();
            }

            return "Bla";
        }
    }
}
