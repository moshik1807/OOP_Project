using System;
using System.Text;
namespace IDF.model
{
    public class ZIK : AttackOptions
    {

        public ZIK(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {

        }

        //בדיקת דלק 
        public override bool fuelCheck(int FlightHours)
        {
            return (FuelInTheTank >= (FlightHours * 200));
        }
        //תדלוק
        public void RefuelingTheDrone()
        {
            refueling = DateTime.Now.AddMinutes(10);
            FuelInTheTank += (2400 - FuelInTheTank);
        }
        //בדיקת תחמושת
        public override bool AmmunitionInspection(int AttacksNumber)
        {
            return (NumberOfAttacks >= AttacksNumber);
        }
        //חימוש
        public void DroneArmament()
        {
            armament = DateTime.Now.AddMinutes(5);
            NumberOfAttacks += (3 - NumberOfAttacks);
        }
        //התקפה
        public override bool Attack(int FlightHours, int AttacksNumber)
        {
            bool resulte = true;
            if (!fuelCheck(FlightHours))
            {
                RefuelingTheDrone();
            }
            if (!AmmunitionInspection(AttacksNumber))
            {
                DroneArmament();
            }
            if (DateTime.Now < refueling)
            {
                resulte = false;
                Console.WriteLine($"The zik remains in refueling for {refueling - DateTime.Now} minutes.");
            }
            if (DateTime.Now < armament)
            {
                resulte = false;
                Console.WriteLine($"The zik is arming and remains {armament - DateTime.Now} minutes.");
            }
            if (resulte)
            {
                FuelInTheTank -= (FlightHours * 200);
                NumberOfAttacks -= AttacksNumber;
            }
            return resulte;





        }
    }
}