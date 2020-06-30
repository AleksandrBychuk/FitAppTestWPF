using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FitApp.Models
{
    public class Person
    {
        [JsonProperty("Rank")]
        public int Rank { get; set; }
        [JsonProperty("User")]
        public string User { get; set; }
        [JsonProperty("Status")]
        public string Status { get; set; }
        [JsonProperty("Steps")]
        public int Steps { get; set; }
    }
}
