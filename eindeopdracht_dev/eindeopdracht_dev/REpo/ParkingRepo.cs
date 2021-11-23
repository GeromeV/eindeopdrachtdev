using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using eindopdracht.Models;
using Newtonsoft;
using Newtonsoft.Json;

namespace eindopdracht.REpo
{
    public class ParkingRepo
    {

        private static HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("accept", "appliction/json");
            return client;
        }

        public static async Task<ParkingGent.Rootobject> GetRecords()
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string url = "https://data.stad.gent/api/records/1.0/search/?dataset=bezetting-parkeergarages-real-time&q=&sort=-occupation&?apikey=a5989a455e12f736762d9f865b1d3ea0e796f46e7de09989263c2283";

                    string json = await client.GetStringAsync(url);

                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<ParkingGent.Rootobject>(json);
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        

    }
}
