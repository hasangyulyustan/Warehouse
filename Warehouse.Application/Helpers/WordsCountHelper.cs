using System;
using System.Text.RegularExpressions;

namespace Warehouse.Application.Helpers
{
	public static class WordsCountHelper
	{
        public static List<string> GetWords(string input)
        {
            MatchCollection matches = Regex.Matches(input.ToLower(), @"\b[\w']*\b");

            var words = from m in matches.Cast<Match>()
                        where !string.IsNullOrEmpty(m.Value)
                        select TrimSuffix(m.Value);

            return words.ToList();
        }

        static string TrimSuffix(string word)
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

