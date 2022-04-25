using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Newtonsoft.Json;
using MyLib;

namespace CurrencyFormApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            string date = dateTimePickerCurrencyDate.Value.ToString("yyyyMMdd");
            string URI = $"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?date={date}&json";
            
            // 
            string webResponseString = MyLib.Web.GetWebContent(URI);

            // Список объектов типа CurrencyRate
            List<CurrencyRate> currRates = JsonConvert.DeserializeObject<List<CurrencyRate>>(webResponseString);

            // 
            FillCurrencyList(currRates);
        }

        string GetWebContent(string UriString)
        {
            string webResponseString;

            // Create a request for the URL.
            WebRequest request = WebRequest.Create(UriString);
            request.Method = WebRequestMethods.Http.Get;
            //request.Credentials = CredentialCache.DefaultCredentials;

            using (WebResponse response = request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    StreamReader streamRdr = new StreamReader(dataStream);
                    webResponseString = streamRdr.ReadToEnd();
                }
            };

            return webResponseString;
        }

        void FillCurrencyList(List<CurrencyRate> currRates)
        {
            // Очищаем listViewCurrates от ранее загруженных элементов
            listViewCurrates.Items.Clear();

            foreach (var item in currRates)
            {
                if (item.txt.Contains(textBoxFilter.Text))
                {
                    listViewCurrates.Items.Add(new ListViewItem(item.ToStringArray()));
                }
            }
        }

    }
}
