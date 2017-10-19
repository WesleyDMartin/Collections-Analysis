/*
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
        static void Main(string[] args)
        {
            double[,] searchGraph = new double[Constants.numOfCollections, Constants.numOfDataPoints];
            double[,] accessGraph = new double[Constants.numOfCollections, Constants.numOfDataPoints];
            double[,] insertGraph = new double[Constants.numOfCollections, Constants.numOfDataPoints];

            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] listResults = new double[Constants.typesOfTests, Constants.numOfTests];
                
                ContentGenerators.listTimes(ref listResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.List, i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.List, i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Access);
                insertGraph[(int)Constants.SetTypes.List, i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Insert);
                DisplayTimes.showTimes(listResults, "List");
            }
            
          
            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] arrayListResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.arrayListTimes(ref arrayListResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Access);
                insertGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Insert);
                DisplayTimes.showTimes(arrayListResults, "Array List");
            }



            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] dictionaryResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.dictionaryTimes(ref dictionaryResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Access);
                insertGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Insert);
                DisplayTimes.showTimes(dictionaryResults, "Dictionary");
            }


            for (int i = 0; i < Constants.numOfDataPoints; i++)
            {
                double[,] hashTableResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.hashTableTimes(ref hashTableResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Search);
                accessGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Access);
                insertGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Insert);
                DisplayTimes.showTimes(hashTableResults, "Hashtable");
            }

            GraphingData.charting(searchGraph, "100 Searches");
            GraphingData.charting(accessGraph, "All Accesses");
            GraphingData.charting(insertGraph, "All Inserts");

        }
    }
}
