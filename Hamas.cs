using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDF.model
{
    public class Hamas
    {
        public string DateOfFormation { get; set; }
        public string CurrentCommander { get; set; }
        public List<Terrorist> Terrorists { get; set; } = new List<Terrorist>();

        public Hamas(string dateofformation, string currentcommander, List<Terrorist> terrorists)
        {
            DateOfFormation = dateofformation;
            CurrentCommander = currentcommander;
            Terrorists = terrorists;
        }

        public void AddTerrorist(Terrorist terrorist)
        {
            Terrorists.Add(terrorist);
        }

        public string GetInfo()
        {
            return $"Hamas Organization:\n" +
                   $"Founded: {DateOfFormation}\n" +
                   $"Commander: {CurrentCommander}\n" +
                   $"Total Terrorists: {Terrorists.Count}";
        }

    }
}
