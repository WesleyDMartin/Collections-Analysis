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
            Stopwatch watch = new Stopwatch();
            List<int> list = new List<int>();
            watch.Start();

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


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int dummy = 0;
                watch.Restart();
                foreach (var item in list)
                {
                    dummy = item;
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                watch.Restart();
                for (int i = 0; i < Constants.numOfSearches; i++)
                {
                    list.Contains(rand.Next(numOfElements));
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void arrayListTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();
            ArrayList list = new ArrayList();
            watch.Start();

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


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int dummy = 0;
                watch.Restart();
                foreach (var item in list)
                {
                    dummy = (int)item;
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                watch.Restart();
                for (int i = 0; i < Constants.numOfSearches; i++)
                {
                    list.Contains(rand.Next(numOfElements));
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void dictionaryTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();
            Dictionary<int, int> list = new Dictionary<int, int>();
            watch.Start();

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


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                KeyValuePair<int, int> dummy = new KeyValuePair<int, int>();
                watch.Restart();
                foreach (var item in list)
                {
                    dummy = item;
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int dummy = 0;
                watch.Restart();
                for (int i = 0; i < Constants.numOfSearches; i++)
                {
                    dummy = list[rand.Next(numOfElements)];
                    list.ContainsValue(rand.Next(numOfElements));
                }
                times[(int)Constants.TestTypes.Search, k] = watch.Elapsed.TotalMilliseconds;
            }
        }
        static public void hashTableTimes(ref double[,] times, int numOfElements)
        {
            Stopwatch watch = new Stopwatch();
            Hashtable list = new Hashtable();
            watch.Start();

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


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                int j = 0;
                watch.Restart();
                foreach (var item in list)
                {
                    j++;
                }
                times[(int)Constants.TestTypes.Access, k] = watch.Elapsed.TotalMilliseconds;
            }


            for (int k = 0; k < Constants.numOfTests; k++)
            {
                watch.Restart();
                object x = 0;
                for (int i = 0; i < Constants.numOfSearches; i++)
                {
                    x = list[rand.Next(numOfElements)];
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
