// DictionaryData.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WP_A03
{

 /** -* Class Comment *-
 *  NAME : DictionaryData
 *  PURPOSE : This class is responsible for creating a basic DictionaryData
 *            And this class has some methods and works as it works.
 *  -- Method --
 *  PutDataIntoDictionary()         Put random data into Dictionary
 *  FindDictionary()                Search data in Dictionary
 */
    internal class DictionaryData
    {
        private Dictionary<string, string> RandomDataDictionary;            // Make Dictionary to save random string data
        Stopwatch stopwatch = new Stopwatch();                              // Make stopwatch from stopwatch class
        long totalVaildEstimatedTime = 0;                   // A variable which save total vaild estimated time
        long totalInvaildEstimatedTime = 0;                 // A variable which save total invaild estimated time

        /** -- Method Header Comment --
         *  Name    : DictionaryData -- constructor
         *  Purpose : To instantiate a new DictionaryData object
         *  Input   : sizeOfDictionary       int         the command line argument
         *  Output  : none
         *  Return  : none
         */
        public DictionaryData(int sizeOfDictionary)
        {
            RandomDataDictionary = new Dictionary<string, string>(sizeOfDictionary);
        }

        /** -- Method Header Comment --
        *  Name    : PutDataIntoDictionary
        *  Purpose : Put random data which is occured in main function into the Dictionary
        *  Input   : guidData       string          the guid data from main
        *  Output  : none
        *  Return  : none
        */
        public void PutDataIntoDictionary(string guidData1, string guidData2)
        {
            RandomDataDictionary[guidData1] = guidData2;
        }


        /** -- Method Header Comment --
        *  Name    : FindDictionary
        *  Purpose : Search data which is already in the Dictionary
        *  Input   : fullData       DictionaryData              the Dictionary which is made in the first time
        *            findData       StringArray                 the array which user try to search inside of fullData array
        *            num            int                         the command line argument
        *  Output  : the information of search time
        *  Return  : none
        */

        public void FindDictionary(DictionaryData fullData, StringArray findData, int num)
        {
            stopwatch.Reset();
            
            for (int i = 0; i < num; i++)                           // Search Data inside of full data
            {
                long searchVaildTime = stopwatch.ElapsedTicks;
                long searchInvaildTime = stopwatch.ElapsedTicks;
                stopwatch.Start();
                string key = findData.RandomDataArray[i];
                stopwatch.Stop();
                
                if(fullData.RandomDataDictionary.TryGetValue(key, out string found))
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
                
                Console.WriteLine("Average of searching vaild data in Dictionary : \t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);
                
            }
            else
            {
                long totalAverage = totalInvaildEstimatedTime / num;

                long nanosecond = (totalAverage % 10) * 100;
                long microsecond = ((totalAverage / 10) % 1000);
                long milisecond = ((totalAverage / 10_000) % 1000);
                double second = totalAverage / 10_000_000 % 60;
                double minute = totalAverage / 600_000_000 % 60;

                Console.WriteLine("Average of searching invaild data in Dictionary : \t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);
            }
            // initializing the total estimated time
            totalVaildEstimatedTime = 0;             
            totalInvaildEstimatedTime = 0;
        }
    }
}
