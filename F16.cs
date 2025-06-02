using System;
namespace IDF.model
{
    public class F16 : AttackOptions
    {

        public F16(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {
            MaximumContainer = 5000;
            MaximumShots = 10;

        }

        // חישוב דלק לפי שעה
        public override int HourlyFuelCalculation(int FlightHours)
        {
            return FlightHours * 1300;
        }

        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 1300));
        }
        //תדלוק
        public override void RefuelingTheTool()
        {
            refueling = DateTime.Now.AddMinutes(15);
            FuelInTheTank += (5000 - FuelInTheTank);
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
            NumberOfAttacks += (10 - NumberOfAttacks);
        }
        //התקפה
        public override void Attack(int FlightHours, int AttacksNumber)
        {
            FuelInTheTank -= (FlightHours * 1300);
            NumberOfAttacks -= AttacksNumber;
        }
    }
}
