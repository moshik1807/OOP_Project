using System;
namespace IDF.model
{
    public class F16 : AttackOptions
    {

        public F16(string name, int numberOfAttacks, int fuelInTheTank, string efficiency) : base(name, numberOfAttacks, fuelInTheTank, efficiency)
        {
            MaximumContainer = 3900;
            //MaximumShots = 10;

        }

        //// חישוב דלק לפי שעה
        //public override int HourlyFuelCalculation(int FlightHours)
        //{
        //    return FlightHours * 1300;
        //}

        ////בדיקת דלק 
        //public override bool fuelCheck(int FlightHours)
        //{
        //    return (FuelInTheTank >= (FlightHours * 1300));
        //}
        ////תדלוק
        //public override void RefuelingTheTool()
        //{
        //    refueling = DateTime.Now.AddMinutes(15);
        //    FuelInTheTank += (3900 - FuelInTheTank);
        //}
        ////בדיקת תחמושת
        //public override bool AmmunitionInspection(int AttacksNumber)
        //{
        //    return (NumberOfAttacks >= AttacksNumber);
        //}
        ////חימוש
        //public override void armingTheTool()
        //{
        //    armament = DateTime.Now.AddMinutes(10);
        //    NumberOfAttacks += (8 - NumberOfAttacks);
        //}
        //התקפה
        //public override bool Attack(int FlightHours, int AttacksNumber)
        //{
        //    bool resulte = true;
        //    if (!fuelCheck(FlightHours))
        //    {
        //        RefuelingTheTool();
        //        Console.WriteLine(FuelInTheTank);
        //    }
        //    if (!AmmunitionInspection(AttacksNumber))
        //    {
        //        armingTheTool();
        //    }
        //    if (DateTime.Now < refueling)
        //    {
        //        resulte = false;
        //        Console.WriteLine($"The plane remains in refueling for {refueling - DateTime.Now} minutes.");
        //    }
        //    if (DateTime.Now < armament)
        //    {
        //        resulte = false;
        //        Console.WriteLine($"The plane is arming and remains {armament - DateTime.Now} minutes.");
        //    }
        //    if (resulte)
        //    {
        //        FuelInTheTank -= (FlightHours * 1300);
        //        NumberOfAttacks -= AttacksNumber;
        //    }
        //    return resulte;
        //}

        //חישוב הדלק לפי שעה
        public override bool A(int TravelTime)
        {
            int full = TravelTime * 1300;
            return B(full);
            
        }
        //בדיקה שהמטוס יכול להכיל את הדלק הנצרך
        public bool B(int TravelTime)
        {
            if (MaximumContainer < TravelTime)
            {
                Console.WriteLine("The plane is not durable for this length of travel.");
                return false;
            }
            else
            {
                return C(TravelTime);


            } 
        }
        //בדיקה שהכלי לא בתדלוק
        public bool C(int TravelTime)
        {
            if (refueling > DateTime.Now)
            {
                Console.WriteLine("The plane is refueling.");
                return false;
            }
            else
            {
                return D(TravelTime);

            }
        }
        //בדיקה אם יש כרגע מספיק דלק ושליחה לתדלוק במידה ולא
        public bool D(int TravelTime)
        {
            if(FuelInTheTank < TravelTime)
            {
                Console.WriteLine("There is not enough fuel on the plane, it is sent for refueling.");
                E();
                return false;
            }
            else
            {
                return true;
            }
        }
        //פונקציית תדלוק
        public void E()
        {
            FuelInTheTank = 3900;
            refueling = DateTime.Now.AddMinutes(5);
        }
        // התקפה
        public override void F(int TravelTime)
        {
            FuelInTheTank -= TravelTime * 1300;
            NumberOfAttacks -= 1;
        }

    }
}
