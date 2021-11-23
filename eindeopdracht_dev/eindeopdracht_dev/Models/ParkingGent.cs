using System;
using System.Collections.Generic;
using System.Text;

namespace eindopdracht.Models
{
    public class ParkingGent
    {
        public class Rootobject
        {
            public Record[] records { get; set; }
        }

        public class Record
        {
            public string datasetid { get; set; }
            public string recordid { get; set; }
            public Fields fields { get; set; }
            public Geometry geometry { get; set; }
            public DateTime record_timestamp { get; set; }
        }

        public class Fields
        {
            public DateTime lastupdate { get; set; }
            public string description { get; set; }
            public int occupation { get; set; }
            public string operatorinformation { get; set; }
            public float[] location { get; set; }
            public string occupancytrend { get; set; }
            public string urllinkaddress { get; set; }
            public int isopennow { get; set; }
            public double availablecapacity { get; set; }
            public int freeparking { get; set; }
            public int temporaryclosed { get; set; }
            public string openingtimesdescription { get; set; }
            public double totalcapacity { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
            public string kleur
            {
                get
                {

                    double procent;
                    procent = availablecapacity / totalcapacity * 100;
                    if (procent > 50)
                    {
                        return "green";
                    }
                    else if (procent > 10)
                    {
                        return "orange";
                    }
                    else if (procent <= 10)
                    {
                        return "red";
                    }
                    return "blue";
                }
            }
        }

        public class Geometry
        {
            public string type { get; set; }
            public float[] coordinates { get; set; }
        }

       
    }
}
