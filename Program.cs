namespace IDF.model
{
    class program()
    {
        static void Main(string[] args)
        {
            // יצירת אובייקטים של כלי תקיפה והכנסה לרשימה של כלי תקיפה בצהל
            F16 f16 = new F16("f16", 10, 5000, "building, house");
            ZIK zik = new ZIK("zik", 3, 2400, "open space, car");
            M109 m109 = new M109("m109", 40, 450, "open space");
            Idf idf = new Idf([f16, zik, m109]);

            List<string> weaponst1 = new List<string> { "guns", "M16" };
            Terrorist t1 = new Terrorist("Abu-Yair", 4, true, weaponst1);

            List<string> weaponst2 = new List<string> { "Knife", "M16" };
            Terrorist t2 = new Terrorist("chagai segal", 2, true, weaponst2);

            List<string> weaponst3 = new List<string> { "M16" };
            Terrorist t3 = new Terrorist("Abu-x", 5, true, weaponst3);

            Hamas hamas = new Hamas("1987", "Unknown these days", new List<Terrorist>());
            hamas.AddTerrorist(t1);
            hamas.AddTerrorist(t2);
            hamas.AddTerrorist(t3);

            //foreach (Terrorist t in hamas.Terrorists)
            //{
            //    Console.WriteLine(t.Details());
            //    Console.WriteLine("-------------");
            //}

            IntelligenceMessage intel1 = new IntelligenceMessage(t1, "house", DateTime.Now);
            IntelligenceMessage intel2 = new IntelligenceMessage(t2, "open space", DateTime.Now);
            IntelligenceMessage intel3 = new IntelligenceMessage(t3, "house", DateTime.Now);

            AMAN Aman = new AMAN();
            Aman.AddReport(intel1);
            Aman.AddReport(intel2);
            Aman.AddReport(intel3);
            Menue();

            void Menue()
            {

                bool exis = true;
                while (exis)
                {

                    Console.WriteLine("To get the terrorist with the most alerts, press 1.\n" +
                    "For information about the status of the attack tool, press 2.\n" +
                    "For the most dangerous terrorist, press 3.\n" +
                   "To attack the most dangerous terrorist, press 4.\n" +
                    "To exit press 5");

                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            MaximumNotifications();
                            break;
                        case 2:
                            AvailabilityOfTools();
                            break;
                        case 3:
                            PreferredTarget();
                            break;
                        case 4:
                            makingAnAttack(PreferredTarget());
                            break;
                        case 5:
                            exis = false;
                            break;
                    }
                }
            }
            void MaximumNotifications()
            {
                Console.WriteLine(Aman.GetMostReportedTerrorist());
            }

            void AvailabilityOfTools()
            {
                foreach (var tool in idf.AttackTool)
                {
                    if (tool.refueling > DateTime.Now)
                    {
                        Console.WriteLine($"The {tool.Name} at the refueling station will be ready in {tool.refueling - DateTime.Now} minutes.");
                    }
                    if (tool.armament > DateTime.Now)
                    {
                        Console.WriteLine($" The {tool.Name} with its armament will be ready in {tool.armament - DateTime.Now} minutes.");
                    }
                    else
                    {
                        Console.WriteLine($"The {tool.Name} has {tool.FuelInTheTank} liters of fuel and {tool.NumberOfAttacks} shots.");
                    }
                }
            }

            IntelligenceMessage PreferredTarget()
            {
                int TheMostDangerous = 0;
                IntelligenceMessage x = null;
                foreach (var terrorist in Aman.IntelligenceReports)
                {
                    if (terrorist.Target.TargetPrioritization() > TheMostDangerous)
                    {
                        x = terrorist;
                    }
                }
                Console.WriteLine(x.Target.Name);
                return x;
            }

            void makingAnAttack(IntelligenceMessage perperredTarget)
            {
                List<AttackOptions> newList = new List<AttackOptions>();
                Console.WriteLine("enter the amount of atteck time");
                int attackTime = int.Parse(Console.ReadLine());
                Console.WriteLine("enter the amoount of ammunition for the  attack");
                int shots = int.Parse(Console.ReadLine());
                foreach (var tool in idf.AttackTool)
                {
                    if (tool.Efficiency.Contains(perperredTarget.LastKnownLocation))
                    {// להכניס פה שיפור למקרה שאין מספיק דלק או תחמושת שיחומש אוטומטית ושליחת הודעה למשתמש שהכלי בתדלוק ונשאר לו זמן מסויים
                        
                        if (tool.fuelCheck(attackTime) && tool.AmmunitionInspection(shots))
                        {
                            newList.Add(tool);
                        }
                    }
                }
                if (newList.Count == 0)
                {
                    Console.WriteLine("no atteck option available");

                }
                else
                {
                    for (int i = 0; i <= newList.Count - 1; i++)
                    {
                        Console.WriteLine($"to attack with a {newList[i].Name} press {i}");
                    }
                    int x = int.Parse(Console.ReadLine());
                    newList[x].Attack(attackTime, shots);
                    perperredTarget.Target.IsAlive = false;
                    Aman.IntelligenceReports.Remove(perperredTarget);
                    Console.WriteLine($"{perperredTarget.Target.Name} is Eliminated");
                    newList = null;
                }

            }

        }


    }

}
