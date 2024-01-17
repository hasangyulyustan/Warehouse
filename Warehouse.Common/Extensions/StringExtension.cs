using System;
using System.Text.RegularExpressions;

namespace Warehouse.Common.Extensions
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
    }
}

