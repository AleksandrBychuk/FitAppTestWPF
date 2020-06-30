using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitApp.Models
{
    class PersonResult
    {
        public string Name { get; set; }
        public int AvgSteps { get; set; }
        public int MaxSteps { get; set; }
        public int MinSteps { get; set; }
        public int[] AllSteps { get; set; }
        public int[] AllRanks { get; set; }
        public string[] AllStatus { get; set; }
    }
}
