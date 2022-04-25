using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using MyLibrary;
using System.Text;



namespace CurrencyApp
{
    class Program
    {
        private static String URL;
        private static String jsonContent;
        public Program()
        {
            
        }
        
        static Program()
        {
            URL = "https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json";
            jsonContent = String.Empty;
        }

        public static List<CurrencyRate> GetRates()
        {
            jsonContent = Web.GetWebContent(URL);
            return JsonConvert.DeserializeObject<List<CurrencyRate>>(jsonContent);
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo keyPressed;
            List<CurrencyRate> currRates = GetRates();
            
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Bank NBU");
            Console.WriteLine("1. Перевiрити курс валюти");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("2. Калькулятор валюти");
            keyPressed = Console.ReadKey(true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            if (keyPressed.KeyChar == '1')
            {
                Console.WriteLine("Введiть назву валюти для пошуку. Зразок: USD");
                String thisCode = Console.ReadLine();
                foreach (var item in currRates)
                {
                    if (item.code.Equals(thisCode))
                    {
                        Console.WriteLine($"{item.rate} UAH за 1{item.cc}. \nIнформацiя валiдна станом на {item.exchangedate}.");
                    }
                }                
            }
            else if (keyPressed.KeyChar == '2')
            {
                String thisCode = String.Empty;
                String amount = String.Empty;
                Console.WriteLine("Введiть назву валюти. Зразок: USD");
                thisCode = Console.ReadLine();
                Console.WriteLine("Введiть кiлькiсть валюти. Зразок: 100");
                amount = Console.ReadLine();
                
                CurrencyRate validItem = null;
                foreach (var item in currRates)
                {
                    if (item.cc.Equals(thisCode))
                    {
                        validItem = (CurrencyRate)item.Clone();
                        break;
                    }
                }

                if (validItem != null)
                {
                    Console.WriteLine(
                            $"Курс валюти: {validItem.rate}UAH за 1{validItem.cc} \n"
                          + $"\nВаша валюта буде конвертована в "
                          + $"{validItem.rate * Convert.ToDouble(amount)}UAH за {amount}{thisCode}"
                          + $"\nIнформацiя валiдна станом на {validItem.exchangedate}."
                          );
                }
                else
                {
                    Console.WriteLine("Введена невiрна валюта.");
                }
            }
            
            
            


            _ = Console.ReadLine();



        }

    }
}
