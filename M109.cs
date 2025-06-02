using System;
using System.Threading.Tasks;
namespace IDF.model
{
    public class M109 : AttackOptions
    {

        public M109(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {
            MaximumContainer = 500;
            MaximumShots = 40;
        }
        //חישוב דלק לפי שעה
        public override int HourlyFuelCalculation(int FlightHours)
        {
            return FlightHours * 500;
        }


        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 16));
        }
        //תדלוק
        public override void RefuelingTheTool()
        {
            refueling = DateTime.Now.AddMinutes(15);
            FuelInTheTank += (500 - FuelInTheTank);
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
            NumberOfAttacks += (40 - NumberOfAttacks);
        }
        //התקפה
        public override void Attack(int FlightHours, int AttacksNumber)
        {
             FuelInTheTank -= (FlightHours * 16);
             NumberOfAttacks -= AttacksNumber;
        }
    }
}

