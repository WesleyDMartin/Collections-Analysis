/*
*	FILE		  : Constants.cs
*   PROJECT		  :	WAMP_A3 - Collection Times Analysis
*   PROGRAMMER	  : Wes Martin
*	FIRST VERSION : 13/10/17
*	DESCRIPTION	  : This class contains the Constants class, which contains all
*	              : constants used in the WAMP_A3 assignment. Essentially, this
*	              : file acts as a config file for the program.
*/

namespace WAMP_A3
{
    class Constants
    {
        static public int numOfCollections  = 4;    // The number of different collection types
        static public int typesOfTests      = 3;    // The number of different operations being tested
        static public int sampleSize        = 100;   // The number of search or access sets that will be used in the average
        static public int numOfDataPoints   = 7;    // The number of points in the graph
        static public int timesToAccess     = 10000;
        static public int timesToSearch     = 100;
        static public bool displayStats     = false; 


        // An enumerated list of the types of tests
        public enum TestTypes
        {
            Access = 0,
            Search = 1
        }


        // An enumerated list of the collection types
        public enum SetTypes
        {
            List = 0,
            ArrayList = 1,
            Dictionary = 2,
            Hashtable = 3
        }


        // The count of different element quantities to be used
        static public int[] varyingElementCount = new int[] 
        {
            1,
            10,
            100,
            1000,
            10000,
            100000,
            1000000
        };
    }
}
