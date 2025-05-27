using System;
namespace IDF.model
{
    public abstract class AttackOptions
    {
        public string Name;
        public int NumberOfAttacks;
        public int FuelInTheTank;
        public string Efficiency;
        public DateTime? refueling;
        public DateTime? armament;
        public int MaximumContainer;
        public int MaximumShots;

        public AttackOptions(string name, int numberOfAttacks,int fuelInTheTank,string efficiency, DateTime? Refueling = null,DateTime? Armament = null)
        {
            Name = name;
            NumberOfAttacks = numberOfAttacks;
            FuelInTheTank = fuelInTheTank;
            Efficiency = efficiency;
            refueling = Refueling;
            armament = Armament;
            MaximumContainer = 0;
            MaximumShots = 0;
        }
        public abstract bool Attack(int FlightHours,int AttacksNumber);
        public abstract bool fuelCheck(int FlightHours);
        public abstract bool AmmunitionInspection(int AttacksNumber);
        public abstract void RefuelingTheTool();
        public abstract void armingTheTool();
        public abstract int HourlyFuelCalculation(int FlightHours);

    }

}


