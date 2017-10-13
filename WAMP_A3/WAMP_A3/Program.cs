using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAMP_A3
{
    class Program
    {
        static int elements = 1000000;
        static int searches = 100;
        static Random rand = new Random();
        static void Main(string[] args)
        {
           
            TimeSpan[] times = new TimeSpan[12];
            List<int> list = new List<int>();
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            listTimes(ref times);
            foreach (var item in times)
            {
                Console.WriteLine(item);
            }
        }

        public void showTimes(TimeSpan alt, TimeSpan lt, TimeSpan dt, TimeSpan ht)
        {
            Console.WriteLine("{0,10}{1, 10}{2, 10}{3, 10}", alt, lt, dt, ht);
        }

        static void listTimes(ref TimeSpan[] times)
        {
            
            Stopwatch watch = new Stopwatch();

            List<int> list = new List<int>();
            watch.Start();
            for (int i = 0; i < elements; i++)
            {
                list.Add(i);
            }
            times[0] = watch.Elapsed;
            watch.Restart();

            int j = 0;
            foreach (var item in list)
            {
                j++;
            }
            times[1] = watch.Elapsed;
            watch.Restart();
            
            for (int i = 0; i < searches; i++)
            {
                list.Contains(rand.Next());
            }
            times[2] = watch.Elapsed;
            watch.Restart();


        }
    }
}
