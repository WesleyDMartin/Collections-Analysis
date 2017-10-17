namespace WAMP_A3
{
    class Constants
    {
        static public int numOfCollections  = 4;
        static public int numOfTests        = 5;
        static public int typesOfTests      = 3;
        static public int numOfElements     = 1000000;
        static public int numOfSearches     = 100;
        static public int numOfXPoints      = 6;
        public enum TestTypes
        {
            Insert = 0,
            Access = 1,
            Search = 2
        }

        public enum SetTypes
        {
            List = 0,
            ArrayList = 1,
            Dictionary = 2,
            Hashtable = 3
        }

        static public int[] varyingElementCount = new int[] { 10, 100, 1000, 10000, 100000, 1000000};
    }
}
