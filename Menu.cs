using System;
namespace IDF.model
{
    public class Menu
    {
        private Idf idf;
        private AMAN aman;
        public Menu(Idf idfInstance, AMAN amanInstance)
        {
            idf = idfInstance;
            aman = amanInstance;
        }

        public void ShowMenu()
        {

            bool exis = true;
            while (exis)
            {

                Console.WriteLine("To get the terrorist with the most alerts, press 1.\n" +
                "For information about the status of the attack tool, press 2.\n" +
                "For the most dangerous terrorist, press 3.\n" +
               "To attack the most dangerous terrorist, press 4.\n" +
                "To exit press 5");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        MaximumNotifications();
                        break;
                    case 2:
                        AvailabilityOfTools();
                        break;
                    case 3:
                        PreferredTarget();
                        break;
                    case 4:
                        makingAnAttack(PreferredTarget());
                        break;
                    case 5:
                        exis = false;
                        break;
                }
            }
        }
        public void MaximumNotifications()
        {
            Console.WriteLine(aman.GetMostReportedTerrorist());
        }


        // נותנת את המצב הנוכחי של כלי התקיפה מבחינת דלק ותחמושת
        public void AvailabilityOfTools()
        {
            foreach (var tool in idf.AttackTool)
            {
                if (tool.refueling > DateTime.Now)
                {
                    Console.WriteLine($"The {tool.Name} at the refueling station will be ready in {tool.refueling - DateTime.Now} minutes.");
                }
                if (tool.armament > DateTime.Now)
                {
                    Console.WriteLine($" The {tool.Name} with its armament will be ready in {tool.armament - DateTime.Now} minutes.");
                }
                else
                {
                    Console.WriteLine($"The {tool.Name} has {tool.FuelInTheTank} liters of fuel and {tool.NumberOfAttacks} shots.");
                }
            }
        }


        // מחזירה את המחבל המסוכן ביותר
        public IntelligenceMessage PreferredTarget()
        {
            int highestDangerLevel = 0;
            IntelligenceMessage mostDangerousMessage = null;

            foreach (var report in aman.IntelligenceReports)
            {
                int dangerLevel = report.Target.TargetPrioritization();
                if (dangerLevel > highestDangerLevel)
                {
                    highestDangerLevel = dangerLevel;
                    mostDangerousMessage = report;
                }
            }
            if (mostDangerousMessage != null)
            {
                Console.WriteLine($"Most dangerous terrorist: {mostDangerousMessage.Target.Name}");
            }
            else
            {
                Console.WriteLine("No terrorists left in the intelligence reports.");
            }
            return mostDangerousMessage;
        }


        // מנהלת תקיפה
        public void makingAnAttack(IntelligenceMessage perperredTarget)
        {
            if (perperredTarget == null)
                return;

            // קלט ממשתמש
            (int attackTime, int shots) = GetAttackInput();

            // מציאת כלים זמינים
            List<AttackOptions> availableTools = FindAvailableAttackTools(perperredTarget, attackTime, shots);

            // ביצוע התקיפה או דיווח שאין כלים זמינים
            ExecuteAttack(availableTools, perperredTarget, attackTime, shots);
        }


        // מקבלת שעות טיסה וכמות תחמושת נצרכת מהמשתמש
        public (int, int) GetAttackInput()
        {
            Console.WriteLine("Enter the amount of attack time:");
            int attackTime = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the amount of ammunition for the attack:");
            int shots = int.Parse(Console.ReadLine());

            return (attackTime, shots);
        }



        // התאמת כלים למשימה
        public List<AttackOptions> FindAvailableAttackTools(IntelligenceMessage target, int attackTime, int shots)
        {
            List<AttackOptions> availableTools = new List<AttackOptions>();

            foreach (var tool in idf.AttackTool)
            {
                if (!tool.Efficiency.Contains(target.LastKnownLocation)) continue;

                bool hasFuel = tool.fuelCheck(attackTime);
                bool hasAmmo = tool.AmmunitionInspection(shots);
                bool isReady = (tool.refueling <= DateTime.Now || tool.refueling == null) &&
                               (tool.armament <= DateTime.Now || tool.armament == null);

                if (hasFuel && hasAmmo && isReady)
                {
                    availableTools.Add(tool);
                }
                else
                {
                    if (!hasFuel && tool.MaximumContainer > tool.HourlyFuelCalculation(attackTime))
                    {
                        tool.RefuelingTheTool();
                        Console.WriteLine($"The {tool.Name} is refueling. It will be ready in {tool.refueling - DateTime.Now} minutes.");
                    }

                    if (!hasAmmo && tool.MaximumShots > shots)
                    {
                        tool.armingTheTool();
                        Console.WriteLine($"The {tool.Name} is arming. It will be ready in {tool.armament - DateTime.Now} minutes.");
                    }
                }
            }

            return availableTools;
        }


        // מבצעת תקיפה
        public void ExecuteAttack(List<AttackOptions> tools, IntelligenceMessage target, int attackTime, int shots)
        {
            if (tools.Count == 0)
            {
                Console.WriteLine("No attack option available.");
                return;
            }

            for (int i = 0; i < tools.Count; i++)
            {
                Console.WriteLine($"To attack with {tools[i].Name}, press {i}");
            }

            int choice = int.Parse(Console.ReadLine());
            tools[choice].Attack(attackTime, shots);

            target.Target.IsAlive = false;
            aman.IntelligenceReports.Remove(target);
            Console.WriteLine($"{target.Target.Name} is eliminated.");
        }
    }



}


