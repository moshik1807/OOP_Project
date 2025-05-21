using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDFProject.Models
{
    public class Terrorist
    {
        public string Name { get; set; }
        public  int Rank { get; set; }
        public bool IsAlive { get; set; }
        public List<string> Weapons { get; set; } = new List<string>();
    }
}
