using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MyLibrary
{
    public class CurrencyRateNbu : ICloneable
    {

        // Currency code (36 - AUD)
        public int code { get; set; }
        // Currency name
        public string txt { get; set; }
        // Currency rate in UAH
        public float rate { get; set; }
        // Currency code (ex: USD)
        public string cc { get; set; }
        // Date
        public string exchangedate { get; set; }

        public string[] ToStringArray()
        {
            string[] arr = new String[] { code.ToString(), txt, rate.ToString(), cc };
            return arr;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
