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
        [FunctionName("Postid")]
        public async Task<IActionResult> Postid(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "v1/postparkingid")] HttpRequest req,
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
                    cmd.CommandText = "INSERT INTO tblparkign VALUES(@parkingid)";
                    cmd.Parameters.AddWithValue("@parkingid", registration.parkingid);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
            return new OkObjectResult(registration);
        }

        [FunctionName("Getid")]
        public async Task<IActionResult> Getid(
           [HttpTrigger(AuthorizationLevel.Anonymous,"get", Route = "v1/getparkingid")] HttpRequest req,
           ILogger log)
        {
            try
            {
                string connectionstring = Environment.GetEnvironmentVariable("SQLSERVER");
                List<parking> park = new List<parking>();


                using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
                {
                    
                    await sqlConnection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sqlConnection;
                        cmd.CommandText = "SELECT * from tblparkign group by parkingid";
                        var reader = await cmd.ExecuteReaderAsync();
                        
                        while(await reader.ReadAsync())
                        {
                            park.Add(new parking()
                            {
                                
                                parkingid = reader["parkingid"].ToString()

                            });

                        }
                    }


                }

                return new OkObjectResult(park);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new StatusCodeResult(500);
                
            }

           
        }

        [FunctionName("Deleteid")]
        public async Task<IActionResult> Deleteid(
          [HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "v1/deleteparkingid/{id}")] HttpRequest req,
          ILogger log,string id)
        {
            try
            {
                string connectionstring = Environment.GetEnvironmentVariable("SQLSERVER");
                List<parking> park = new List<parking>();


                using (SqlConnection sqlConnection = new SqlConnection(connectionstring))
                {

                    await sqlConnection.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = sqlConnection;
                        cmd.Parameters.AddWithValue("@id",id);
                        cmd.CommandText = @"DELETE FROM tblParkign WHERE parkingid = @id;";
                        var reader = await cmd.ExecuteReaderAsync();

                        while (await reader.ReadAsync())
                        {
                            park.Add(new parking()
                            {

                                parkingid = reader["parkingid"].ToString()

                            });

                        }
                    }


                }

                return new OkObjectResult(park);

            }
            catch (Exception ex)
            {
                log.LogError(ex.Message);
                return new StatusCodeResult(500);

            }


        }






    }
}
