using System;
namespace IDF.model
{
    public class F16 : AttackOptions
    {

        public F16(string name, int numberOfAttacks, int fuelInTheTank, string efficiency  ) : base(name, numberOfAttacks, fuelInTheTank, efficiency )
        {

        }


        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 2400));
        }
        //תדלוק
        public override void RefuelingTheTool()
        {
            refueling = DateTime.Now.AddMinutes(15);
            FuelInTheTank += (3900 - FuelInTheTank);
        }
        //בדיקת תחמושת
        public override bool AmmunitionInspection(int AttacksNumber)
        {
            return (NumberOfAttacks >= AttacksNumber);
        }
        //חימוש
        public override void armingTheTool()
        {
            armament = DateTime.Now.AddMinutes(10);
            NumberOfAttacks += (8 - NumberOfAttacks);
        }
        //התקפה
        public override bool Attack(int FlightHours, int AttacksNumber)
        {
            bool resulte = true;
            if (!fuelCheck(FlightHours))
            {
                Console.WriteLine("44");
                RefuelingTheTool();
                Console.WriteLine(FuelInTheTank);
            }
            if (!AmmunitionInspection(AttacksNumber))
            {
                armingTheTool();
            }
            if (DateTime.Now < refueling)
            {
                resulte = false;
                Console.WriteLine($"The plane remains in refueling for {refueling - DateTime.Now} minutes.");
            }
            if (DateTime.Now < armament)
            {
                resulte = false;
                Console.WriteLine($"The plane is arming and remains {armament - DateTime.Now} minutes.");
            }
            if (resulte)
            {
                FuelInTheTank -= (FlightHours * 2400);
                NumberOfAttacks -= AttacksNumber;
            }
            return resulte;


        }

    }
}
