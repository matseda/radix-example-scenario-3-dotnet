using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace radix_dotnet_v3.Pages
{
    public class IndexModel : PageModel
    {
        public string Name { get; set; }
        public string Price { get; set; }

        //URL's used to access the API
        private const string baseURL = "https://api.coinmarketcap.com/v2/ticker/";
        private const string listURL = "https://api.coinmarketcap.com/v2/listings/";
        int[] idList;

        public void OnGet()
        {
            DownloadIdList();
            DownloadCryptoInfo();
        }

        //Downloads a list of all crypto currencies and saves the id's  
        public void DownloadIdList()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync(listURL).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content; 
                //This section takes the string made from the response and converts it to a
                //dynamic object so that we can easily access the different values
                string responseString = responseContent.ReadAsStringAsync().Result;
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(responseString);
                int objLenght = obj.data.Count;

                //Save the id's of the currencies in an array.
                idList = new int[objLenght];
                for(int i=0; i<objLenght; i++){
                    idList[i] = obj.data[i].id;
                }
            }
        }

        //Downloads data for a currency based on an random id from the list of id's 
        public void DownloadCryptoInfo()
        {
            HttpClient client = new HttpClient();
            Random r = new Random();

            //Get a random id from the list and uses this in the URL which retrieves data about the currency with that id
            int id = idList[r.Next(0, idList.Length-1)]; 
            string URL = baseURL + id + "/";
            var response = client.GetAsync(URL).Result;


            //Not all of the ID's are valid 
            if (response.IsSuccessStatusCode)
            {
                var responseContent = response.Content; 

                //This section takes the string made from the response and converts it to a
                //dynamic object so that we can easily access the different values
                string responseString = responseContent.ReadAsStringAsync().Result;
                dynamic obj = JsonConvert.DeserializeObject<dynamic>(responseString);

                //Set the name and price which will be displayed in the cshtml
                Name = obj.data.name;
                Price = obj.data.quotes.USD.price;
            }
        }
    }
}
