/*
*	FILE		  : ContentGenerators.cs
*   PROJECT		  :	WAMP_A3 - Collection Times Analysis
*   PROGRAMMER	  : Wes Martin
*	FIRST VERSION : 13/10/17
*	DESCRIPTION	  : This file contains the ContentGenerators class, which contains all
*	              : the functions needed to test the collections for their inesertion,
*	              : access, and search times. (May end up merging search and access)
*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace WAMP_A3
{
    // For all four of these classes, to enable the access within the search, simply
    // uncomment the "x = " line inside the search line.
    class ContentGenerators
    {
        static public Random rand = new Random();


        /**
        * \brief Runs a number of tests on a List collection type.
        *
        * <b>Description</b><br>
        * Based off of the controlling numbers in the constants file, this function
        * accepts a 2D array and fills it with data. This function acts on a List collection,
        * executing searches and accesses on that collection.
        * 
        * Access: The access test uses a direct index access
        * Search: The search uses the Contains function, with the option to have an access test time as well
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	        - The 2D array that will store all the timed results
        * \param					<b>int numOfElements</b>	    - The number of elements for the particular test in question
        */
        static public void listTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            List<int> list = new List<int>();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int i = 0; i < numOfElements; i++)
            {
                list.Add(i);
            }


            // Access
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToAccess; i++)
                {
                    x = list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToSearch; i++)
                {
                    if (list.Contains(rand.Next(numOfElements)))
                    {
                       // x = list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }

        /**
        * \brief Runs a number of tests on a Array List collection type.
        *
        * <b>Description</b><br>
        * Based off of the controlling numbers in the constants file, this function
        * accepts a 2D array and fills it with data. This function acts on a Array List collection,
        * executing searches and accesses on that collection.
        * 
        * Access: The access test uses a direct index access
        * Search: The search uses the Contains function, with the option to have an access test time as well
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	        - The 2D array that will store all the timed results
        * \param					<b>int numOfElements</b>	    - The number of elements for the particular test in question
        */
        static public void arrayListTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            ArrayList list = new ArrayList();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int i = 0; i < numOfElements; i++)
            {
                list.Add(i);
            }


            // Access
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToAccess; i++)
                {
                    x = (int)list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToSearch; i++)
                {
                    if (list.Contains(rand.Next(numOfElements)))
                    {
                       //x = (int)list[rand.Next(numOfElements)];
                    }
                   
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }

        /**
        * \brief Runs a number of tests on a Dictionary collection type.
        *
        * <b>Description</b><br>
        * Based off of the controlling numbers in the constants file, this function
        * accepts a 2D array and fills it with data. This function acts on a Dictionary collection,
        * executing searches and accesses on that collection.
        * 
        * Access: The access test uses a direct index access
        * Search: The search uses the Contains Value function, with the option to have an access test time as well
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	        - The 2D array that will store all the timed results
        * \param					<b>int numOfElements</b>	    - The number of elements for the particular test in question
        */
        static public void dictionaryTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            Dictionary<int, int> list = new Dictionary<int, int>();    // A collection of varying size, dependant on numOfElements
            watch.Start();


            // Insert
            for (int i = 0; i < numOfElements; i++)
            {
                list.Add(i, i);
            }


            // Access
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToAccess; i++)
                {
                    x = list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToSearch; i++)
                {
                    if (list.ContainsValue(rand.Next(numOfElements)))
                    {
                       // x = list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }

        /**
        * \brief Runs a number of tests on a Hash Table collection type.
        *
        * <b>Description</b><br>
        * Based off of the controlling numbers in the constants file, this function
        * accepts a 2D array and fills it with data. This function acts on a Hash Table collection,
        * executing searches and accesses on that collection. 
        * 
        * Access: The access test uses a direct index access
        * Search: The search uses the Contains Value function, with the option to have an access test time as well
        * 
        * <b>Details</b>
        *
        * \param					<b>double[,] times</b>	        - The 2D array that will store all the timed results
        * \param					<b>int numOfElements</b>	    - The number of elements for the particular test in question
        */
        static public void hashTableTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            Hashtable list = new Hashtable();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int i = 0; i < numOfElements; i++)
            {
                list.Add(i, i);
            }


            // Access
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToAccess; i++)
                {
                    x = (int)list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.sampleSize; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.timesToSearch; i++)
                {
                    if (list.ContainsValue(rand.Next(numOfElements)))
                    {
                        //x = (int)list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }

        static public double getAverage(double[,] times, int testType)
        {
            double average = 0.0;

            for (int i = 0; i < Constants.sampleSize; i++)
            {
                average += times[testType, i];
            }

            return average/Constants.sampleSize;
        }
    }
}
