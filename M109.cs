using System;
namespace IDF.model
{
    public class M109 : AttackOptions
    {

        public M109(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {

        }



        // שולח לבדיקת דלק ותחמושת ומחזיר הודעה מתאימה
        public override void Attack(int FlightHours, int AttacksNumber)
        {
            bool resulte = true;
            fuel(FlightHours);
            munitions(AttacksNumber);
            if (DateTime.Now < refueling)
            {
                resulte = false;
                Console.WriteLine($"The M109 remains in refueling for {refueling - DateTime.Now} minutes.");
            }
            if (DateTime.Now < armament)
            {
                resulte = false;
                Console.WriteLine($"The M109 is arming and remains {armament - DateTime.Now} minutes.");
            }
            if (resulte)
            {
                Console.WriteLine("The M109 goes on the attack.");
                FuelInTheTank -= (FlightHours * 100);
                NumberOfAttacks -= AttacksNumber;
            }
        }

        // מקבלת שעות טיסה נצרכות למשימה,בודקת אם יש מספיק דלק,במידה ולא שולחת לתדלוק
        public bool fuel(int FlightHours)
        {
            if (FuelInTheTank >= (FlightHours * 100))
            {
                return true;
            }
            else
            {
                refueling = DateTime.Now.AddMinutes(30);
                FuelInTheTank += (450 - FuelInTheTank);
                return false;
            }

        }

        // מקבלת מספר התקפות שנצרכות למשימה,בודקת אם יש מספיק תחמושת,במידה ולא שולחת לחימוש

        public bool munitions(int AttacksNumber)
        {
            if (NumberOfAttacks >= AttacksNumber)
            {
                return true;
            }
            else
            {
                armament = DateTime.Now.AddMinutes(40);
                NumberOfAttacks += (40 - NumberOfAttacks);
                return false;
            }
        }


    }
}

