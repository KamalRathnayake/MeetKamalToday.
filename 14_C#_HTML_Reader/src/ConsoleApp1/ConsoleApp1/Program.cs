using System;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://en.wikipedia.org/wiki/HTML");

            var title = document.DocumentNode.SelectNodes("//*[@id=\"firstHeading\"]").First().InnerText;
            var paragraphs = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div[1]/p");

            paragraphs.ToList().ForEach(i => Console.WriteLine(i.InnerText));

            SimpleExtraction();
        }

        private static void SimpleExtraction()
        {
            HtmlWeb web = new HtmlWeb();
            //HtmlDocument document = new HtmlDocument();
            //document.Load("C:\index.html");
            HtmlDocument document = web.Load("https://example.com/");

            var title = document.DocumentNode.SelectNodes("//div/h1").First().InnerText;
            var description = document.DocumentNode.SelectNodes("//div/p").First().InnerText;

            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine(description);
        }
    }
}
