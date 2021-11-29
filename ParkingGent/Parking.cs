using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ParkingGent
{
    public class Parking
    {
        [JsonProperty("recordid")]
        public string recordid { get; set; }
    }
}
