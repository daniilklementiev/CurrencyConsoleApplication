using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace MyLibrary
{
	[JsonObject(MemberSerialization = MemberSerialization.OptIn)]
	public class CurrencyRate : ICloneable
	{

        // Currency code
        [JsonProperty(PropertyName = "r030")]
		public int code { get; set; }

        // Currency name
        [JsonProperty(PropertyName = "txt")]
		public string txt { get; set; }

        // Currency rate
        [JsonProperty(PropertyName = "rate")]
		public float rate { get; set; }

        // Currency code-name (example: USD, AUD)
        [JsonProperty(PropertyName = "cc")]
		public string cc { get; set; }

        // Date of exchange
        [JsonProperty(PropertyName = "exchangedate")]
		public string exchangedate { get; set; }

        // processing all data to one array
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
