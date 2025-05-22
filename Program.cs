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

            
        }
        
        static void Menue()
        {

            Console.WriteLine("To get the terrorist with the most alerts, press 1.\n" +
            "For information about the status of the attack tool, press 2.\n" +
            "For the most dangerous terrorist, press 3.\n" +
           "To attack the most dangerous terrorist, press 4.\n" +
            "To exit press 5");
            int choice = int.Parse(Console.ReadLine());

            bool exis = false;
            while (!exis)
            {
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
                        exis = true;
                        break;
                }
            }
        }
        static void MaximumNotifications()
        {

        }

        static void AvailabilityOfTools()
        {
            Console.WriteLine();

        }

        static void PreferredTarget()
        {

        }

        static void makingAnAttack()
        {
            

        }
    }

}
