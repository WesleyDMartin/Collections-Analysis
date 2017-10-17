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
            double[,] listResults       = new double[Constants.typesOfTests, Constants.numOfTests];
            double[,] arrayListResults  = new double[Constants.typesOfTests, Constants.numOfTests];
            double[,] dictionaryResults = new double[Constants.typesOfTests, Constants.numOfTests];
            double[,] hashTableResults  = new double[Constants.typesOfTests, Constants.numOfTests];

            ContentGenerators.listTimes(ref listResults);
            DisplayTimes.showTimes(listResults, "List");

            ContentGenerators.arrayListTimes(ref arrayListResults);
            DisplayTimes.showTimes(arrayListResults, "Array List");

            ContentGenerators.dictionaryTimes(ref dictionaryResults);
            DisplayTimes.showTimes(dictionaryResults, "Dictionary");

            ContentGenerators.hashTableTimes(ref hashTableResults);
            DisplayTimes.showTimes(hashTableResults, "Hashtable");
        }
    }
}
