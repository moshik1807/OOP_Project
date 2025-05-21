namespace IDF.model
{
    class program()
    {
        static void Main(string[] args)
        {
            F16 s = new F16("a", 10, 3000, "d");
            //Console.WriteLine(s.Name);
            //s.Attack(1);
            //Console.WriteLine(s.refueling.ToString());
            //s.fuel(2);
            //Console.WriteLine(s.refueling.ToString());
            //Console.WriteLine(s.FuelInTheTank);
            //Console.WriteLine(DateTime.Now.ToString());
            //Console.WriteLine(s.munitions(10));
            //Console.WriteLine(s.armament.ToString());

            s.Attack(1, 3);
            s.refueling.ToString();
            Console.WriteLine(s.refueling.ToString());
            s.Attack(1, 4);
        }
    }

}
