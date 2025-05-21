using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace IDFProject.Models
{
    public class Hamas
    {
        public string DateOfFormation { get; set; }
        public string CurrentCommander { get; set; }
        public List<Terrorist> terrorists { get; set; } = new List<Terrorist>();

    }
}
