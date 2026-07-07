using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using ContractManagementSystem_CMS_.Models;

namespace ContractManagementSystem_CMS_.Services
{
    public class SearchService
    {
        public List<SearchResult> SearchByKeyphrase(string text, string keyword)
        {
            var results = new List<SearchResult>();
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(keyword))
                return results;

            CompareInfo trCompare = CultureInfo.GetCultureInfo("tr-TR").CompareInfo;
            string[] lines = text.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
            int searchIndex = 0;
            int resultIndex = 1;

            while (searchIndex < text.Length)
            {
                int foundIndex = trCompare.IndexOf(text, keyword, searchIndex, CompareOptions.IgnoreCase);
                if (foundIndex == -1) break;

                int lineNumber = GetLineNumber(text, foundIndex);
                string context = GetContext(text, foundIndex, keyword.Length);

                results.Add(new SearchResult
                {
                    Index = resultIndex++,
                    MatchedText = keyword,
                    Context = context,
                    Position = foundIndex,
                    LineNumber = lineNumber,
                    SearchType = "Anahtar Kelime"
                });

                searchIndex = foundIndex + keyword.Length;
            }

            return results;
        }

        public List<SearchResult> SearchByRegex(string text, string pattern)
        {
            var results = new List<SearchResult>();
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(pattern))
                return results;

            try
            {
                var matches = Regex.Matches(text, pattern, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                int resultIndex = 1;

                foreach (Match match in matches)
                {
                    int lineNumber = GetLineNumber(text, match.Index);
                    string context = GetContext(text, match.Index, match.Length);

                    results.Add(new SearchResult
                    {
                        Index = resultIndex++,
                        MatchedText = match.Value,
                        Context = context,
                        Position = match.Index,
                        LineNumber = lineNumber,
                        SearchType = "Regex"
                    });
                }
            }
            catch (RegexParseException)
            {
            }

            return results;
        }

        public List<SearchResult> SearchMultipleKeywords(string text, string[] keywords)
        {
            var results = new List<SearchResult>();
            if (string.IsNullOrWhiteSpace(text) || keywords == null || keywords.Length == 0)
                return results;

            int resultIndex = 1;
            foreach (var keyword in keywords)
            {
                var keywordResults = SearchByKeyphrase(text, keyword.Trim());
                foreach (var r in keywordResults)
                {
                    r.Index = resultIndex++;
                    results.Add(r);
                }
            }

            return results;
        }

        private int GetLineNumber(string text, int position)
        {
            int lineNumber = 1;
            for (int i = 0; i < position && i < text.Length; i++)
            {
                if (text[i] == '\n') lineNumber++;
            }
            return lineNumber;
        }

        private string GetContext(string text, int position, int matchLength)
        {
            int contextStart = Math.Max(0, position - 50);
            int contextEnd = Math.Min(text.Length, position + matchLength + 50);

            string before = text.Substring(contextStart, position - contextStart);
            string match = text.Substring(position, matchLength);
            string after = text.Substring(position + matchLength, contextEnd - position - matchLength);

            if (contextStart > 0) before = "..." + before;
            if (contextEnd < text.Length) after = after + "...";

            return before + "[" + match + "]" + after;
        }
    }
}