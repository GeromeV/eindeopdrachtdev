using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;
using eindopdracht.Models;
using Newtonsoft.Json;
using Microsoft.Azure.Cosmos;
using eindeopdracht_dev.Models;

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

        public static async Task<List<favoriet>> Getfavoriet()
        {
            using (HttpClient client = GetClient())
            {
                try
                {
                    string url = "https://faparkinggent.azurewebsites.net/api/v1/getparkingid";

                    string json = await client.GetStringAsync(url);

                    if (json != null)
                    {
                        return JsonConvert.DeserializeObject<List<favoriet>>(json);
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

        

        public async static Task UpdateFavo(favoriet favo)
        {
            try
            {
                using (HttpClient client = GetClient())
                {
                    string url = "https://faparkinggent.azurewebsites.net/api/v1/postparkingid";

                    string json = JsonConvert.SerializeObject(favo);

                    HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(url, content); ;
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new Exception("Tis nie gulukt, programeer wa beter e de volgende keer");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }





    }
}
