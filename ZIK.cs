using System;
using System.Text;
namespace IDF.model
{
    public class ZIK : AttackOptions
    {

        public ZIK(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {
            MaximumContainer = 150;
            MaximumShots = 3;
        }

        // חישוב דלק לפי שעה
        public override int HourlyFuelCalculation(int FlightHours)
        {
            return FlightHours * 150;
        }

        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 7));
        }
        //תדלוק
        public override void RefuelingTheTool()
        {
            refueling = DateTime.Now.AddMinutes(10);
            FuelInTheTank += (150 - FuelInTheTank);
        }
        //בדיקת תחמושת
        public override bool AmmunitionInspection(int AttacksNumber)
        {
            return (NumberOfAttacks >= AttacksNumber);
        }
        //חימוש
        public override void armingTheTool()
        {
            armament = DateTime.Now.AddMinutes(5);
            NumberOfAttacks += (3 - NumberOfAttacks);
        }
        //התקפה
        public override void Attack(int FlightHours, int AttacksNumber)
        {
             FuelInTheTank -= (FlightHours * 7);
             NumberOfAttacks -= AttacksNumber;
        }
    }
}