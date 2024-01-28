using System.Text.RegularExpressions;

namespace Warehouse.Application.Extensions
{
    public static class StringExtension
    {
        public static string AddTags(this string inputText, string[] wordsToTag, string openingTag, string closingTag)
        {
            foreach (var word in wordsToTag)
            {
                inputText = inputText.Replace(word, $"{openingTag}{word}{closingTag}", StringComparison.Ordinal);
            }

            return inputText;
        }

        public static string[] GetHighlightsArray(this string? inputText)
        {
            if (inputText is not null)
            {
                return inputText.Split(",");
            }

            return new string[0];
        }

        public static List<string> GetWords(this string input)
        {
            MatchCollection matches = Regex.Matches(input.ToLower(), @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToList();
        }

        static string TrimSuffix(this string word)
        {
            int apostropheLocation = word.IndexOf('\'');
            if (apostropheLocation != -1)
            {
                word = word.Substring(0, apostropheLocation);
            }

            return word;
        }
    }
}

