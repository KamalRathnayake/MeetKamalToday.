using HtmlAgilityPack;
using System;
using System.Linq;

namespace CSharpHTMLReader
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument document = web.Load("https://en.wikipedia.org/wiki/HTML");

            var title = document.DocumentNode.SelectNodes("//*[@id=\"firstHeading\"]").First().InnerText;
            var paragraphs = document.DocumentNode.SelectNodes("//*[@id=\"mw-content-text\"]/div[1]/p");

            Console.WriteLine(title);
            Console.WriteLine();
            paragraphs.ToList().ForEach(i => Console.WriteLine(i.InnerText));
        }
    }
}
