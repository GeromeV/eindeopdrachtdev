using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace fa_parkinggent
{
    public  class Function1
    {
        [FunctionName("Getid")]
        public async Task<IActionResult> Getid(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post","get", Route = "v1/parkingid")] HttpRequest req,
            ILogger log)
        {
            
          var json = await new StreamReader(req.Body).ReadToEndAsync();
            var registration = JsonConvert.DeserializeObject<parking>(json);
            string connectionstring = Environment.GetEnvironmentVariable("SQLSERVER");

            using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
            {
                await sqlConnection.OpenAsync();
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = sqlConnection;
                    cmd.CommandText = "INSERT INTO tblparkign VALUES(@id,@parkingid)";
                    cmd.Parameters.AddWithValue("@id", registration.id);
                    cmd.Parameters.AddWithValue("@parkingid", registration.parkingid);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return new OkObjectResult(registration);
        }


       

        

    }
}
