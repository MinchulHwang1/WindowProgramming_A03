// ListTypeOfString.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WP_A03
{
 /** -* Class Comment *-
 *  NAME : ListTypeOfString
 *  PURPOSE : This class is responsible for creating a basic ListTypeOfString
 *            And this class has some methods and works as it works.
 *  -- Method --
 *  PutDataIntoList()       Put random data into List
 *  FindList()             Search data in List
 */
    internal class ListTypeOfString
    {
        private List<string> RandomDataList;                 // Make List to save random string data   
        Stopwatch stopwatch = new Stopwatch();              // Make stopwatch from stopwatch class
        long totalVaildEstimatedTime = 0;                   // A variable which save total vaild estimated time
        long totalInvaildEstimatedTime = 0;                 // A variable which save total invaild estimated time

        /** -- Method Header Comment --
         *  Name    : ListTypeOfString -- constructor
         *  Purpose : To instantiate a new ListTypeOfString object
         *  Input   : sizeOfList       int         the command line argument
         *  Output  : none
         *  Return  : none
         */
        public ListTypeOfString(int sizeOfList)
        {
            RandomDataList = new List<string>(sizeOfList);
        }

        /** -- Method Header Comment --
        *  Name    : PutDataIntoList
        *  Purpose : Put random data which is occured in main function into the list
        *  Input   : guidData       string          the guid data from main
        *  Output  : none
        *  Return  : none
        */
        public void PutDataIntoList(string guidData)
        {
            RandomDataList.Add(guidData);
        }

        /** -- Method Header Comment --
        *  Name    : FindList
        *  Purpose : Search data which is already in the list
        *  Input   : fullData       ListTypeOfString            the list which is made in the first time
        *            findData       StringArray                 the array which user try to search inside of fullData array
        *            num            int                         the command line argument
        *  Output  : the information of search time
        *  Return  : none
        */
        public void FindList(ListTypeOfString fullData, StringArray findData, int num)
        {
            string[] changeListIntoArray = fullData.RandomDataList.ToArray();           // Change list into array
            Array.Sort(changeListIntoArray);                                            // Sort the data to use BinarySearch()
            stopwatch.Reset();                                                          // reset stopwatch

            for (int i = 0; i < num; i++)                                               // Search Data inside of full data
            {
                long searchVaildTime = stopwatch.ElapsedTicks;
                long searchInvaildTime = stopwatch.ElapsedTicks;
                stopwatch.Start();
                int found = Array.BinarySearch(changeListIntoArray, findData.RandomDataArray[i]);
                stopwatch.Stop();

                if (found >= 0)
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
                
                Console.WriteLine("Average of searching vaild data in List : \t\t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);
            }
            else
            {
                long totalAverage = totalInvaildEstimatedTime / num;

                long nanosecond = (totalAverage % 10) * 100;
                long microsecond = ((totalAverage / 10) % 1000);
                long milisecond = ((totalAverage / 10_000) % 1000);
                double second = totalAverage / 10_000_000 % 60;
                double minute = totalAverage / 600_000_000 % 60;

                Console.WriteLine("Average of searching invaild data in List : \t\t {0, 3:D3}minutes {1, 3:D3}sec {2, 3:D3}ms {3, 3:D3}㎲ {4, 3:D3}㎱", (int)minute, (int)second, milisecond, microsecond, nanosecond);
            }
            // initializing the total estimated time
            totalVaildEstimatedTime = 0;             
            totalInvaildEstimatedTime = 0;
        }
    }
}
