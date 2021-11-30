using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace eindeopdracht_dev.Models
{
    public class favoriet
    {
        [JsonProperty(propertyName: "parkingid")]
       public string parkingid { get; set; }
    }
}
