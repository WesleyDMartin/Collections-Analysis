using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAMP_A3
{
    class DisplayTimes
    {
        static public void showTimes(double[,] times, string type)
        {
            displayHeader(type);
            displayRow(times, (int)Constants.TestTypes.Insert, "Insert");
            displayRow(times, (int)Constants.TestTypes.Access, "Access");
            displayRow(times, (int)Constants.TestTypes.Search, "Search");
            Console.WriteLine();
        }

        static void displayRow(double[,] times, int whichTest, string heading)
        {
            Console.Write(heading + ":   ");
            for (int i = 0; i < Constants.numOfTests; i++)
            {
                Console.Write(times[whichTest, i].ToString(" 000.0000") + " ");
            }
            Console.WriteLine(ContentGenerators.getAverage(times, whichTest).ToString(" 000.0000"));
        }
        
        static void displayHeader(string type)
        {
            Console.WriteLine("TIMES FOR: "+type);
            Console.Write("Test Type");
            for (int i = 1; i <= Constants.numOfTests; i++)
            {
                Console.Write("   TEST: "+i.ToString());
            }

            Console.WriteLine("  AVERAGE");
        }

    }
}
