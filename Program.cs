namespace IDF.model
{
    class program()
    {
        static void Main(string[] args)
        {
            int travelTime = 0;

            // יצירת אובייקטים של כלי תקיפה והכנסה לרשימה של כלי תקיפה בצהל
            toolsFactory.CreatAttackTools();
            Idf idf = new Idf(toolsFactory.toolsList);


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

            IntelligenceMessage intel1 = new IntelligenceMessage(t1, "house", DateTime.Now);
            IntelligenceMessage intel2 = new IntelligenceMessage(t2, "open space", DateTime.Now);
            IntelligenceMessage intel3 = new IntelligenceMessage(t3, "house", DateTime.Now);

            AMAN Aman = new AMAN();
            Aman.AddReport(intel1);
            Aman.AddReport(intel2);
            Aman.AddReport(intel3);

            Menu x = new Menu(idf, Aman);
            x.ShowMenu();
        }
    }
}
