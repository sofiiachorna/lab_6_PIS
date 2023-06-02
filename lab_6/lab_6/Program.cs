using System;
using RestSharp;
using System.Net;
using System.Text.Json.Nodes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CountryInfoAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Default;
            Console.OutputEncoding = Encoding.UTF8;

            Console.Write("Введіть назву країни (наприклад, 'USA' для Сполучених Штатів Америки): ");
            string name = Console.ReadLine();

            string link = $"https://restcountries.com/v3.1/name/{name}";

            // Виклик API та отримання даних
            var client = new RestClient(link);
            var request = new RestRequest(link, Method.Get);
            var response = client.Execute(request);

            string jsonResult = response.Content;

            jsonResult = jsonResult.TrimStart(new char[] { '[' }).TrimEnd(new char[] { ']' });

            JObject obj = JObject.Parse(jsonResult);

            Console.WriteLine($"Name: {obj["name"]["common"]}\n" +
                $"Capital: {obj["capital"]}\n" +
                $"Region: {obj["region"]}\n" +
                $"Currency: {obj["currencies"]}\n" +
                $"Languages: {obj["languages"]}\n" +
                $"Population: {obj["population"]}");

            Console.ReadLine();
        }
    }
}
