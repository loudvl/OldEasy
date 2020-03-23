using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestMobileApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public List<Match> matchs;
        public MainPage()
        {
            InitializeComponent();
        }

        public Task<string> GetAllMatchs()
        {
            try
            {
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(new Uri("http://10.0.2.2/projects/TestMobileApp/PHP/getMatchs.php"));
                myRequest.Method = "GET";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                HttpWebResponse response = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                return reader.ReadToEndAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var result = GetAllMatchs().Result;
            matchs = JsonConvert.DeserializeObject<List<Match>>(GetAllMatchs().Result);
        }
    }
}
