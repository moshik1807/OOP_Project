using System;
using System.Threading.Tasks;
namespace IDF.model
{
    public class M109 : AttackOptions
    {

        public M109(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {

        }

        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 100));
        }
        //תדלוק
        public void RefuelingTheTank()
        {
            refueling = DateTime.Now.AddMinutes(15);
            FuelInTheTank += (450 - FuelInTheTank);
        }
        //בדיקת תחמושת
        public override bool AmmunitionInspection(int AttacksNumber)
        {
            return (NumberOfAttacks >= AttacksNumber);
        }
        //חימוש
        public void TankArmament()
        {
            armament = DateTime.Now.AddMinutes(10);
            NumberOfAttacks += (40 - NumberOfAttacks);
        }
        //התקפה
        public override bool Attack(int FlightHours, int AttacksNumber)
        {
            bool resulte = true;
            if (!fuelCheck(FlightHours))
            {
                RefuelingTheTank();
            }
            if (!AmmunitionInspection(AttacksNumber))
            {
                TankArmament();
            }
            if (DateTime.Now < refueling)
            {
                resulte = false;
                Console.WriteLine($"The tank remains in refueling for {refueling - DateTime.Now} minutes.");
            }
            if (DateTime.Now < armament)
            {
                resulte = false;
                Console.WriteLine($"The tank is arming and remains {armament - DateTime.Now} minutes.");
            }
            if (resulte)
            {
                FuelInTheTank -= (FlightHours * 100);
                NumberOfAttacks -= AttacksNumber;
            }
            return resulte;


        }

    }
}

