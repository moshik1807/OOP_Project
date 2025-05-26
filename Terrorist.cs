using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDF.model
{
    public class Terrorist
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool IsAlive { get; set; }
        public List<string> Weapons { get; set; } = new List<string>();

        public Terrorist(string name, int rank, bool isAlive, List<string> weapons)
        {
            Name = name;
            Rank = rank;
            IsAlive = isAlive;
            Weapons = weapons;
        }

        public int TargetPrioritization()
        {
            int points = 0;

            foreach (var weapon in Weapons)
            {

                switch (weapon)
                {
                    case "Knife":
                        points += 1;
                        break;

                    case "Gun":
                        points += 2;
                        break;

                    case "M16":
                    case "AK47":
                        points += 3;
                        break;

                    default:
                        points = 0;
                        break;
                }

            }
            return points * Rank;
        }

        public string conversion(List<string> function)
        {
            return string.Join(", ", function);
        }

        public string Details()
        {
            string WeaponsRead = conversion(Weapons);
            string status = IsAlive ? "Alive" : "Dead";
            int RiskLevel = TargetPrioritization();
            return ($"Terrorist Card:\r\n" +
                $"Name:{Name}\r\n" +
                $"Rank:{Rank}\r\n" +
                $"Status:{status}\r\n" +
                $"Armament:{WeaponsRead}\r\n" +
                $"Danger Level:{RiskLevel}");

        }

        public override string ToString()
        {
            return Details();
        }

    }
}
