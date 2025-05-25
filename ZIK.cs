using System;
using System.Text;
namespace IDF.model
{
    public class ZIK : AttackOptions
    {

        public ZIK(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {

        }



        //// שולח לבדיקת דלק ותחמושת ומחזיר הודעה מתאימה
        //public override bool Attack(int FlightHours, int AttacksNumber)
        //{
        //    bool resulte = true;
        //    fuel(FlightHours);
        //    munitions(AttacksNumber);
        //    if (DateTime.Now < refueling)
        //    {
        //        resulte = false;
        //        Console.WriteLine($"The zik remains in refueling for {refueling - DateTime.Now} minutes.");
        //    }
        //    if (DateTime.Now < armament)
        //    {
        //        resulte = false;
        //        Console.WriteLine($"The zik is arming and remains {armament - DateTime.Now} minutes.");
        //    }
        //    if (resulte)
        //    {
        //        Console.WriteLine("The zik goes on the attack.");
        //        FuelInTheTank -= (FlightHours * 200);
        //        NumberOfAttacks -= AttacksNumber;
        //    }
        //    return resulte;
        //}

        //// מקבלת שעות טיסה נצרכות למשימה,בודקת אם יש מספיק דלק,במידה ולא שולחת לתדלוק
        //public bool fuel(int FlightHours)
        //{
        //    if (FuelInTheTank >= (FlightHours * 200))
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        refueling = DateTime.Now.AddMinutes(30);
        //        FuelInTheTank += (2400 - FuelInTheTank);
        //        return false;
        //    }

        //}

        //// מקבלת מספר התקפות שנצרכות למשימה,בודקת אם יש מספיק תחמושת,במידה ולא שולחת לחימוש

        //public bool munitions(int AttacksNumber)
        //{
        //    if (NumberOfAttacks >= AttacksNumber)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        armament = DateTime.Now.AddMinutes(45);
        //        NumberOfAttacks += (3 - NumberOfAttacks);
        //        return false;
        //    }
        //}

        //בדיקת דלק 
        public bool fuelCheck(int FlightHours)
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
        public bool AmmunitionInspection(int AttacksNumber)
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
                Console.WriteLine("The zik goes on the attack.");
                FuelInTheTank -= (FlightHours * 200);
                NumberOfAttacks -= AttacksNumber;
            }
            return resulte;





        }
    }
}