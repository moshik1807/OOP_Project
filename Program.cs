namespace IDF.model
{
    class program()
    {
        static void Main(string[] args)
        {
            // יצירת אובייקטים של כלי תקיפה והכנסה לרשימה של כלי תקיפה בצהל
            F16 f16 = new F16("f16", 10, 5000, "building, house");
            ZIK zik = new ZIK("zik", 3, 2400, "Open space, car");
            M109 m109 = new M109("m109", 40, 450, "Open space");
            Idf idf = new Idf([f16,zik,m109]);

            Menue();

            void Menue()
            {

                Console.WriteLine("To get the terrorist with the most alerts, press 1.\n" +
                "For information about the status of the attack tool, press 2.\n" +
                "For the most dangerous terrorist, press 3.\n" +
               "To attack the most dangerous terrorist, press 4.\n" +
                "To exit press 5");

                bool exis = true;
                while (exis)
                {
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
                            makingAnAttack();
                            break;
                        case 5:
                            exis = false;
                            break;
                    }
                }
            }
            void MaximumNotifications()
            {
                Console.WriteLine(f16);
            }

            void AvailabilityOfTools()
            {
                foreach(var tool in idf.AttackTool)
                {
                    if (tool.refueling > DateTime.Now)
                    {
                        Console.WriteLine($"The {tool.Name} at the refueling station will be ready in {tool.refueling - DateTime.Now} minutes.");
                    }
                    else if(tool.armament > DateTime.Now)
                    {
                        Console.WriteLine($" The {tool.Name} with its armament will be ready in {tool.refueling - DateTime.Now} minutes.");
                    }
                    else
                    {
                        Console.WriteLine($"The {tool.Name} has {tool.FuelInTheTank} liters of fuel and {tool.NumberOfAttacks} shots.");
                    }
                }
            }

            void PreferredTarget()
            {

            }

            void makingAnAttack()
            {


            }

        }
        
        
    }

}
