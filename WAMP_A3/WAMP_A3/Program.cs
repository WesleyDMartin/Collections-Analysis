using System;
using System.Collections;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAMP_A3
{

    class Program
    {
        static void Main(string[] args)
        {
            //double[,] listResults       = new double[Constants.typesOfTests, Constants.numOfTests];
            //double[,] arrayListResults  = new double[Constants.typesOfTests, Constants.numOfTests];
            //double[,] dictionaryResults = new double[Constants.typesOfTests, Constants.numOfTests];
            //double[,] hashTableResults  = new double[Constants.typesOfTests, Constants.numOfTests];

            double[,] searchGraph = new double[Constants.numOfCollections, Constants.numOfXPoints];
            for (int i = 0; i < Constants.numOfXPoints; i++)
            {
                double[,] listResults = new double[Constants.typesOfTests, Constants.numOfTests];
                
                ContentGenerators.listTimes(ref listResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.List,i] = ContentGenerators.getAverage(listResults, (int)Constants.TestTypes.Search);
                DisplayTimes.showTimes(listResults, "List");
            }
            
          
            for (int i = 0; i < Constants.numOfXPoints; i++)
            {
                double[,] arrayListResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.arrayListTimes(ref arrayListResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.ArrayList, i] = ContentGenerators.getAverage(arrayListResults, (int)Constants.TestTypes.Search);
                DisplayTimes.showTimes(arrayListResults, "Array List");
            }



            for (int i = 0; i < Constants.numOfXPoints; i++)
            {
                double[,] dictionaryResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.dictionaryTimes(ref dictionaryResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Dictionary, i] = ContentGenerators.getAverage(dictionaryResults, (int)Constants.TestTypes.Search);
                DisplayTimes.showTimes(dictionaryResults, "Dictionary");
            }


            for (int i = 0; i < Constants.numOfXPoints; i++)
            {
                double[,] hashTableResults = new double[Constants.typesOfTests, Constants.numOfTests];

                ContentGenerators.hashTableTimes(ref hashTableResults, Constants.varyingElementCount[i]);
                searchGraph[(int)Constants.SetTypes.Hashtable, i] = ContentGenerators.getAverage(hashTableResults, (int)Constants.TestTypes.Search);
                DisplayTimes.showTimes(hashTableResults, "Hashtable");
            }

            GraphingData.charting(searchGraph, "Search.png");

        }
    }
}
