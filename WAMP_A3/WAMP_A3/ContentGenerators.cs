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
    class ContentGenerators
    {
        static public Random rand = new Random();
        static public void listTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            List<int> list = new List<int>();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                list.Clear();
                watch.Restart();
                for (int i = 0; i < numOfElements; i++)
                {
                    list.Add(i);
                }
                times[(int)Constants.TestTypes.Insert, k] = watch.Elapsed.TotalMilliseconds;

            }


            // Access
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    x = list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    if (list.Contains(rand.Next(numOfElements)))
                    {
                        x = list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void arrayListTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            ArrayList list = new ArrayList();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                list.Clear();
                watch.Restart();
                for (int i = 0; i < numOfElements; i++)
                {
                    list.Add(i);
                }
                times[(int)Constants.TestTypes.Insert, k] = watch.Elapsed.TotalMilliseconds;

            }


            // Access
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    x = (int)list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    if (list.Contains(rand.Next(numOfElements)))
                    {
                       x = (int)list[rand.Next(numOfElements)];
                    }
                   
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void dictionaryTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            Dictionary<int, int> list = new Dictionary<int, int>();    // A collection of varying size, dependant on numOfElements
            watch.Start();


            // Insert
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                list.Clear();
                watch.Restart();
                for (int i = 0; i < numOfElements; i++)
                {
                    list.Add(i, i);
                }
                times[(int)Constants.TestTypes.Insert, k] = watch.Elapsed.TotalMilliseconds;

            }


            // Access
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    x = list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    if (list.ContainsValue(rand.Next(numOfElements)))
                    {
                        x = list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void hashTableTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();  // Used to track all times in tests
            Hashtable list = new Hashtable();   // A collection of varying size, dependant on numOfElements
            watch.Start();

            // Insert
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                list.Clear();
                watch.Restart();
                for (int i = 0; i < numOfElements; i++)
                {
                    list.Add(i, i);
                }
                times[(int)Constants.TestTypes.Insert, k] = watch.Elapsed.TotalMilliseconds;

            }


            // Access
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    x = (int)list[rand.Next(numOfElements)];
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            // Search
            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int x = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfOpExecutes; i++)
                {
                    if (list.ContainsValue(rand.Next(numOfElements)))
                    {
                        x = (int)list[rand.Next(numOfElements)];
                    }
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }

        static public double getAverage(double[,] times, int testType)
        {
            double average = 0.0;

            for (int i = 0; i < Constants.numOfTests; i++)
            {
                average += times[testType, i];
            }

            return average/Constants.numOfTests;
        }
    }
}
