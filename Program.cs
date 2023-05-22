using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace SmtpClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            // Send get request to weather.com (Baku)
            String url = "https://weather.com/en-AG/weather/today/l/a5b52e8973df57e8f3cd77476dd1e3a87fcfec9a4a63fa432cad50ae55f4092e";
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            // Get the temperature
            var temperatureElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='CurrentConditions--tempValue--MHmYY']");
            var temperature = temperatureElement.InnerText.Trim();
            Console.WriteLine("Temperature: " + temperature);

            // Get the conditions
            var conditionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='CurrentConditions--phraseValue--mZC_p']");
            var conditions = conditionElement.InnerText.Trim();
            Console.WriteLine("Conditions: " + conditions);

            // Get the location
            var cityElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='CurrentConditions--location--1YWj_']");
            var city = cityElement.InnerText.Trim();
            Console.WriteLine("City: " + city);
        }
    }
}