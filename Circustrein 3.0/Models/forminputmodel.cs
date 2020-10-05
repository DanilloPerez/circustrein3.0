using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Circustrein_3._0.Models
{
    public class forminputmodel 
    {
        public string output { get; set; }
        public int smallCarnivore { get; set; }
        public int mediumCarnivore { get; set; }
        public int bigCarnivore { get; set; }
        public int smallHerbivore { get; set; }
        public int mediumHerbivore { get; set; }
        public int bigHerbivore { get; set; }
    }
}
