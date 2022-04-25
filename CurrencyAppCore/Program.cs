using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using MyLib;

namespace CurrencyAppCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string URI = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";

            string jsonFromServer = Web.GetWebContent(URI);
            //JsonTextReader reader = new JsonTextReader(new StringReader(jsonFromServer));

            //List<CurrencyRate> currRates = JsonConvert.DeserializeObject<List<CurrencyRate>>(jsonFromServer);
            List<CurrencyRateNbu> currRates = JsonSerializer.Deserialize<List<CurrencyRateNbu>>(jsonFromServer,new JsonSerializerOptions { IncludeFields = true});


            foreach (var item in currRates)
            {
                Console.WriteLine($" { item.cc } { item.rate } { item.exchangedate } ");
            }


            _ = Console.ReadLine();
        }
    }
}
