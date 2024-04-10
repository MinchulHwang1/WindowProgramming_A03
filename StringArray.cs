// StringArray.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WP_A03
{
 /** -* Class Comment *-
 *  NAME : StringArray
 *  PURPOSE : This class is responsible for creating a basic StringArray
 *                     And this class has some methods and works as it works.
 *  -- Method --
 *  PutDataIntoArray()      Put random data into array
 *  GetArray()              Get array elements from array 
 *  FindArray()             Search data in array
 */
    internal class StringArray
    {
        public string[] RandomDataArray;                // Make array to save random string data
        private Random random;                          // Make random which is come from random class
        Stopwatch stopwatch = new Stopwatch();          // Make stopwatch from stopwatch class
        long totalVaildEstimatedTime = 0;               // A variable which save total vaild estimated time
        long totalInvaildEstimatedTime = 0;             // A variable which save total invaild estimated time

        /** -- Method Header Comment --
         *  Name    : StringArray -- constructor
         *  Purpose : To instantiate a new StringArray object
         *  Input   : sizeOfArray       int         the command line argument
         *  Output  : none
         *  Return  : none
         */
        public StringArray(int sizeOfArray)
        {
            RandomDataArray = new string[sizeOfArray];
            random = new Random();
        }

        /** -- Method Header Comment --
        *  Name    : PutDataIntoArray
        *  Purpose : Put random data which is occured in main function into the array
        *  Input   : guidData       string          the guid data from main
        *            index          int             the command line argument
        *  Output  : none
        *  Return  : none
        */
        public void PutDataIntoArray(string guidData, int index)
        {
            RandomDataArray[index] = guidData;
        }

        /** -- Method Header Comment --
        *  Name    : GetArray
        *  Purpose : Get data which is saved in array
        *  Input   : none
        *  Output  : none
        *  Return  : RandomDataArray            which is already made in array
        */
        public string GetArray()
        {
            return RandomDataArray[random.Next(RandomDataArray.Length)];
        }

        /** -- Method Header Comment --
        *  Name    : FindArray
        *  Purpose : Search data which is already in the array
        *  Input   : fullData       StringArray          the array which is made in the first time
        *            findData       StringArray          the array which user try to search inside of fullData array
        *            num            int                  the command line argument
        *  Output  : the information of search time
        *  Return  : none
        */
        public void FindArray(StringArray fullData, StringArray findData, int num)
        {
            stopwatch.Reset();                  // reset stopwatch
            
            for (int i = 0; i < num; i++)       // Search Data inside of full data
            {
                long searchVaildTime = stopwatch.ElapsedTicks;
                long searchInvaildTime = stopwatch.ElapsedTicks;
                stopwatch.Start();
                string found = Array.Find(fullData.RandomDataArray, data => data == findData.RandomDataArray[i]);
                stopwatch.Stop();

                if (found != null)
                {
                    totalVaildEstimatedTime += searchVaildTime;
                }
                else
                {
                    totalInvaildEstimatedTime += searchInvaildTime;
                }
            }

            // Calculate average time to search
            if (totalInvaildEstimatedTime == 0)
            {
                long totalAverage = totalVaildEstimatedTime / num;

                long nanosecond = (totalAverage % 10) * 100;
                long microsecond = ((totalAverage / 10) % 1000);
                long milisecond = ((totalAverage / 10_000) % 1000);
                double second = totalAverage / 10_000_000 % 60;
                double minute = totalAverage / 600_000_000 % 60;
                
                Console.WriteLine("Average of searching vaild data in Array : \t\t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);

            }
            else
            {
                long totalAverage = totalInvaildEstimatedTime / num;

                long nanosecond = (totalAverage % 10) * 100;
                long microsecond = ((totalAverage / 10) % 1000);
                long milisecond = ((totalAverage / 10_000) % 1000);
                double second = totalAverage / 10_000_000 % 60;
                double minute = totalAverage / 600_000_000 % 60;
                
                Console.WriteLine("Average of searching invaild data in Array : \t\t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);
            }
            // initializing the total estimated time
            totalVaildEstimatedTime = 0;             
            totalInvaildEstimatedTime = 0;
        }
    }
}
