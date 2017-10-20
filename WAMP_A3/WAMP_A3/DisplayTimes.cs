/*
*	FILE		  : DisplayTimes.cs
*   PROJECT		  :	WAMP_A3 - Collection Times Analysis
*   PROGRAMMER	  : Wes Martin
*	FIRST VERSION : 13/10/17
*	DESCRIPTION	  : This file contains the DisplayTimes class, which contains all functionality needed
*	              : to display the times for the various tests to the screen. 
*/

using System;

namespace WAMP_A3
{
    class DisplayTimes
    {

        /**
        * \brief Displayed a chart of times 
        *
        * <b>Description</b><br>
        * Displays a chart with all the processing times for a specific collection.
        * Displays headings, details, and averages.
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	        - The times that will be displayed
        * \param					<b>string type</b>	            - Which collection is being displayed
        * \param					<b>int elementCountIndex</b>    - The number of elements in the test
        */
        static public void showTimes(double[,] times, string type, int elementCountIndex)
        {
            // Controls whether or not all the ~raw data is blurted out
            if (Constants.displayStats)
            {
                displayHeader(type);
                displayRow(times, (int)Constants.TestTypes.Access, "Access");
                displayRow(times, (int)Constants.TestTypes.Search, "Search");
                Console.WriteLine();
            }
            else
            {
                Console.Write("Currently Processing " + type + " - Sample Size: ");
                Console.WriteLine(Constants.varyingElementCount[elementCountIndex]);
            }
        }


        /**
        * \brief Displays the rows of data
        *
        * <b>Description</b><br>
        * Displays the times for a specific test, as well as the average at the end of the line
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	- The times that will be displayed
        * \param					<b>int whichTeste</b>	- Which test data is being accessed
        * \param					<b>string heading</b>	- Which test title is to be displayed
        */
        static void displayRow(double[,] times, int whichTest, string heading)
        {
            Console.Write(heading + ":   ");
            for (int i = 0; i < Constants.sampleSize; i++)
            {
                Console.Write(times[whichTest, i].ToString(" 000.0000") + " ");
            }
            Console.WriteLine(ContentGenerators.getAverage(times, whichTest).ToString(" 000.0000"));
        }


        /**
        * \brief Displays the headings for the rows of data
        *
        * <b>Description</b><br>
        * Displays the column headings, based off how many tests are to be run
        * 
        * <b>Details</b>
        *
        * \param					<b>string type</b>	-The collection that is being displayed
        */
        static void displayHeader(string type)
        {
            Console.WriteLine("TIMES FOR: "+type);
            Console.Write("Test Type");
            for (int i = 1; i <= Constants.sampleSize; i++)
            {
                Console.Write("   TEST: "+i.ToString());
            }

            Console.WriteLine("  AVERAGE");
        }

    }
}
