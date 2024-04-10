// Program.cs 
/** 
 * This is a Program cs's comment
 *  name        : Program.cs
 *  PURPOSE     : This program estimates which data structure works fast.
 *                There are 3 data structure ; Array, List, and Dictionary.
 *                And it shows the result which contain of average time to search vaild and invaild data on each data structure.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WP_A03
{
    internal class Program
    {
        
        public delegate string DataStructure(string randomData);
        static void Main(string[] args)
        {
            // Error checking
            int[] numberInArgs = new int[args.Length];                  // to Set array to save the number which is from command line argument
            // To check the command line argument is vaild or not
            if (args.Length == 0)                                       // if there is no argument.
            {
                Console.WriteLine("There are no Command line arguments");
                Console.WriteLine("Put integer number in the Commandline arguments more than 2.");
                Environment.Exit(0);
            }
            else if (args.Length == 1)                                  // if there is only one argument.
            {
                Console.WriteLine("Command line argument is not vaild");
                Console.WriteLine("Put integer in the Commandline Second argument.");
                Environment.Exit(0);
            }

            for (int i = 0; i < args.Length; i++)                        // Get argument 
            {
                if (int.TryParse(args[i], out int number))              // Put argument into array of numberInArgs
                {
                    numberInArgs[i] = number;
                }
                else
                {                                                                   // when there is error in argument
                    Console.WriteLine("Command line argument is not vaild");        
                    Console.WriteLine("Put integer in the Commandline argument.");
                    Environment.Exit(0);
                }
            }

            if ((numberInArgs[0] * 0.01) < numberInArgs[1])                     // If Second argument is at least smaller than 1% of the first argument
            {
                Console.WriteLine("Command line argument is not vaild");        // when there is error in argument
                Console.WriteLine("Second argument is at least smaller than 1% of the first argument");
                Environment.Exit(0);
            }
            else if ((numberInArgs[0] < 100 || numberInArgs[0] > 5000000))
            {
                Console.WriteLine("Command line argument is not vaild");        // when there is error in argument
                Console.WriteLine("The Range of the first argument is from 100 to 5,000,000");
                Environment.Exit(0);
            }
            else if ((numberInArgs[1] < 1))
            {
                Console.WriteLine("Command line argument is not vaild");        // when there is error in argument
                Console.WriteLine("The Second argument is more than 1");
                Environment.Exit(0);
            }

            //Make array,list, Dictionary
            StringArray stringArray = new StringArray(numberInArgs[0]);
            ListTypeOfString List = new ListTypeOfString(numberInArgs[0]);
            DictionaryData DD = new DictionaryData(numberInArgs[0]);

            // Pur random data into each datadtructure
            for (int i = 0; i < numberInArgs[0]; i++) {
                string randomData = Guid.NewGuid().ToString();
                stringArray.PutDataIntoArray(randomData, i);
                List.PutDataIntoList(randomData);
                DD.PutDataIntoDictionary(randomData, randomData);
            }

            // To make array to save vaild data
            Random random = new Random();

            // get random data which is already made from array
            StringArray vaildDataArray = new StringArray(numberInArgs[1]);
            for (int i = 0; i < numberInArgs[1]; i++)
            {
                vaildDataArray.PutDataIntoArray(stringArray.GetArray(), i);
            }

            // To make array to save invaild data
            StringArray invaildDataArray = new StringArray(numberInArgs[1]);
            for (int i = 0; i < numberInArgs[1]; i++)
            {
                string randomData = Guid.NewGuid().ToString();
                invaildDataArray.PutDataIntoArray(randomData, i);
            }

            // Show the result of data
            Console.WriteLine("Total data amount : {0}, Searching Data's amount is {1}", numberInArgs[0], numberInArgs[1]);
            Console.WriteLine();

            Console.WriteLine("Result of search.");
            stringArray.FindArray(stringArray, vaildDataArray, numberInArgs[1]);
            stringArray.FindArray(stringArray, invaildDataArray, numberInArgs[1]);
            List.FindList(List, vaildDataArray, numberInArgs[1]);
            List.FindList(List,invaildDataArray, numberInArgs[1]);
            DD.FindDictionary(DD, vaildDataArray, numberInArgs[1]);
            DD.FindDictionary(DD, invaildDataArray, numberInArgs[1]);

            Console.WriteLine("Press any button...");
            Console.ReadLine();
        }
    }
}
