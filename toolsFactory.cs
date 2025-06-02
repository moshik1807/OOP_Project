using System;
using System.ComponentModel.Design;
using System.Runtime.ConstrainedExecution;
namespace IDF.model
{
    // יוצר כלי תקיפה באופן רנדומלי
    public class toolsFactory
    {
        public static List<AttackOptions> toolsList = new List<AttackOptions>();
        public static Random rnd = new Random();
        public static List<string> tools = new List<string> { "f16", "m109", "zik" };


        public static void CreatAttackTools()
        {
            for (int i = 0; i < rnd.Next(10,15);i++)
            {
                string toolType = tools[rnd.Next(0, tools.Count)];


                switch (toolType)
                {
                    case "f16":
                        toolsList.Add(new F16($"{toolType} id:{rnd.Next(1000, 2000)}", rnd.Next(1, 10), rnd.Next(500, 5000), "building, house"));
                        break;
                    case "m109":
                        toolsList.Add(new M109($"{toolType} id:{rnd.Next(2000, 3000)}", rnd.Next(1, 40), rnd.Next(50, 500), "open space, car"));
                        break;
                    case "zik":
                        toolsList.Add(new ZIK($"{toolType} id:{rnd.Next(3000, 4000)}", rnd.Next(2, 3), rnd.Next(10, 150), "open space"));
                        break;
                    default:
                        break;
                }
            }

        }

    }

}

