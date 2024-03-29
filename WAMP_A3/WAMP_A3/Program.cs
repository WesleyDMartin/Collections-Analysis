﻿/*
*	FILE		  : Program.cs
*   PROJECT		  :	WAMP_A3 - Collection Times Analysis
*   PROGRAMMER	  : Wes Martin
*	FIRST VERSION : 13/10/17
*	DESCRIPTION	  : This file contains the main Program class, which is the controller 
*	              : for the display, graphing, and content generator classes. This file
*	              : is essentially useless without the other files around.
*/

namespace WAMP_A3
{
    
    class Program
    {
        //public const int test = 0;
        static void Main(string[] args)
        {
            double[,] searchGraph = new double[Constants.numOfCollections, Constants.numOfDataPoints];
            double[,] accessGraph = new double[Constants.numOfCollections, Constants.numOfDataPoints];


            // List
            // This section is responsible for running tests on the List collection
            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                // Create a 2D array that will store all the times for each sample set, for each test type
                double[,] listResults = new double[Constants.typesOfTests, Constants.sampleSize];
                
                ContentGenerators.listTimes(ref listResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.List, i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.List, i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Access);
                DisplayTimes.showTimes(listResults, "List", i);
            }


            // Array List
            // This section is responsible for running tests on the Array List collection
            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] arrayListResults = new double[Constants.typesOfTests, Constants.sampleSize];

                ContentGenerators.arrayListTimes(ref arrayListResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Access);
                DisplayTimes.showTimes(arrayListResults, "Array List", i);
            }


            // Dictionary
            // This section is responsible for running tests on the Dictionary collection
            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] dictionaryResults = new double[Constants.typesOfTests, Constants.sampleSize];

                ContentGenerators.dictionaryTimes(ref dictionaryResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Access);
                DisplayTimes.showTimes(dictionaryResults, "Dictionary", i);
            }


            // Hash Table
            // This section is responsible for running tests on the Hash Table collection
            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] hashTableResults = new double[Constants.typesOfTests, Constants.sampleSize];

                ContentGenerators.hashTableTimes(ref hashTableResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Access);
                DisplayTimes.showTimes(hashTableResults, "Hashtable", i);
            }

            // Creates graphs of the search and access timed results
            GraphingData.charting(searchGraph, Constants.timesToSearch.ToString() + " Searches");
            GraphingData.charting(accessGraph, Constants.timesToAccess.ToString() + " Accesses");

            // Creates log scaled graphs of the search and access timed results
            GraphingData.charting(searchGraph, Constants.timesToSearch.ToString() + " Searches", true);
            GraphingData.charting(accessGraph, Constants.timesToAccess.ToString() + " Accesses", true);

        }
    }
}
