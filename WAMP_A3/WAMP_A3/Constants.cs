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
        static public int numOfTests        = 10;   // The number of test used on each operation to calculate the average
        static public int typesOfTests      = 3;    // The number of different operations being tested
        static public int numOfOpExecutes   = 100;  // The number of searches to be performed
        static public int numOfDataPoints      = 7;    // The number of points in the graph


        // An enumerated list of the types of tests
        public enum TestTypes
        {
            Insert = 0,
            Access = 1,
            Search = 2
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
