using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAMP_A3
{
    class Constants
    {
        static public int numOfTypes = 4;
        static public int numOfTests = 9;
        static public int typesOfTests = 3;
        static public int numOfElements = 1000000;
        static public int numOfSearches = 10;
        public enum TestTypes
        {
            Insert = 0,
            Access = 1,
            Search = 2
        }
    }
}
