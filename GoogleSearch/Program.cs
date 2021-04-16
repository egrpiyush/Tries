using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoogleSearch
{
    public class SearchResultViewModel
    {
        public bool IsInfotrack { get; set; }
    }

    class Program
    {
        private static Dictionary<int, SearchResultViewModel> searchDictionary = new Dictionary<int, SearchResultViewModel>();
        static void Main(string[] args)
        {
            WebClient webClient = new WebClient();
            webClient.Headers.Add("user-agent", "Testing");
            var htmlPage = webClient.DownloadString(@"https://infotrack-tests.infotrack.com.au/Google/Page01.html");
            var keyCount = 0;
            for (int i = 1; i <= 10; i++)
            {
                var pageNumber = (i < 10) ? "0" + i : i.ToString();
                var html = webClient.DownloadString(string.Format(@"https://infotrack-tests.infotrack.com.au/Google/Page{0}.html", pageNumber));
                ParseHtml(html, "", ref keyCount);
                keyCount++;
            }

            Console.ReadLine();
        }

        private static void ParseHtml(string html, string searchQuery, ref int keyCount)
        {
            var matches = Regex.Matches(html, @"<!--m-->(.+?)<!--n-->");
            var pattern = @"https://www.infotrack.com.au";
            foreach (var match in matches)
            {
                searchDictionary.Add(keyCount, new SearchResultViewModel
                {
                    IsInfotrack = Regex.IsMatch(match.ToString(), pattern)
                });
                keyCount++;
            }
            //return searchDictionary;
        }

    }
}
