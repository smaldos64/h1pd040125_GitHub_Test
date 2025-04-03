using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPOpgaveLøsning_Net9
{
    public static class Opgaver
    {
        /*
        * Introduktion til Algoritmer
        * Exercise 1. 
        * Describe an algorithm that interchanges the values of the variables x and y, using only assignment statements.
        * What is the minimum number of assignment statements needed to do so?
        */
        public static void Interchange(ref int x, ref int y)
        {
            int temp = x; //copy x value to temperary variable
            x = y; //assign x to the value of y
            y = temp; //assign y to the temp value
        }
        /*
         * Interchange values without ref.
         * Swaps elements in an array.
        */
        public static void SwapInts(int[] array, int position1, int position2)
        {
            int temp = array[position1]; // Copy the first position's element
            array[position1] = array[position2]; // Assign to the second element
            array[position2] = temp; // Assign to the first element
        }
        /*
        * Introduktion til Algoritmer
        * Exercise 2. 
        * 2.Describe an algorithm that uses only assignment statements to replace thevalues of the triple(x, y, z) with (y, z, x).
        * What is the minimum number of assignment statements needed?
        */
        public static void InterchangeTriple(ref int a, ref int b, ref int c)
        {
            int temp = a;
            a = c;
            c = b;
            b = temp;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 3.
         * A palindrome is a string that reads the same forward and backward.
         * Describe an algorithm for determining whether a string of n characters is a palindrome.
         */
        public static bool IsPalindrome(string s)
        {
            StringBuilder resversedString = new StringBuilder();
            for (int i = s.Length - 1; i >= 0; i--)
            {
                resversedString.Append(s[i]);
            }
            return s.CompareTo(resversedString.ToString()) == 0 ? true : false;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.a.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4A
         */
        public static int StepsInLinearSearch(int searchFor, int[] intergerArray)
        {
            int i = 1;
            foreach (int integer in intergerArray)
            {
                if (integer == searchFor)
                {
                    return i;
                }
                i++;
            }
            return 0;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 4.b.
         * List all the steps used to search for 9 in the sequence 1, 3, 4, 5, 6, 8, 9, 11
         * Do this by completing the unit test for 4B
         */
        public static int StepsInBinarySearch(int[] integerArray, int arrayStart, int arrayEnd, int searchFor)
        {
            if (arrayEnd >= arrayStart)
            {
                int mid = arrayStart + (arrayEnd - arrayStart) / 2;
                // If the element is present at the 
                // middle itself 
                if (integerArray[mid] == searchFor)
                    return 1;

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (integerArray[mid] > searchFor)
                    return 1 + StepsInBinarySearch(integerArray, arrayStart, mid - 1, searchFor);

                // Else the element can only be present 
                // in right subarray 
                return 1 + StepsInBinarySearch(integerArray, mid + 1, arrayEnd, searchFor);
            }

            // We reach here when element is not present 
            // in array
            return -1;
        }
        /*
         * Introduktion til Algoritmer
         * Exercise 5.
         * Describe an algorithm based on the linear search for de-termining the correct position in which to insert a new element in an already sorted list.
         */
        public static int InsertSortedList(List<int> sortedList, int insert)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                Console.WriteLine(sortedList[i]);
                if (sortedList[i] >= insert)
                {
                    sortedList.Insert(i, insert);
                    foreach (int a in sortedList)
                    {
                        Console.Write(a + " ");
                    }
                    return i;
                }
            }
            return -1;
        }
        /*
         * Arrays
         * Create a function that takes two numbers as arguments (num, length) and returns an array of multiples of num up to length.
         * Notice that num is also included in the returned array.
         */
        public static int[] ArrayOfMultiples(int num, int length)
        {
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                arr[i] = num * (i + 1);
            }
            return arr;
        }
        /*
         * Create a function that takes in n, a, b and returns the number of values raised to the nth power that lie in the range [a, b], inclusive.
         * Remember that the range is inclusive.
         * a < b will always be true.
         */
        public static int PowerRanger(int power, int min, int max)
        {
            int counter = 0;
            for (int i = min; i <= max; i++)
            {
                if (Math.Pow(i, 1.0 / power) % 1 == 0) counter++;
            }
            return counter;
        }
        /*
         * Create a Fact method that receives a non-negative integer and returns the factorial of that number.
         * Consider that 0! = 1.
         * You should return a long data type number.
         * https://www.mathsisfun.com/numbers/factorial.html
         */
        public static long Factorial(int n)
        {
            long result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
                Console.WriteLine(i + ", Result: " + result);
            }
            return result;
        }
        /*
         * Write a function which increments a string to create a new string.
         * If the string ends with a number, the number should be incremented by 1.
         * If the string doesn't end with a number, 1 should be added to the new string.
         * If the number has leading zeros, the amount of digits should be considered.
         */
        public static string StartingZeros(StringBuilder sb)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; sb[i].Equals('0'); i++)
            {
                if (!sb[i + 1].Equals('9'))
                {
                    result.Append("0");
                }
            }
            return result.ToString();
        }
        public static string IncrementString(string txt)
        {
            string s;
            string zeros = "";
            int num;
            StringBuilder str = new StringBuilder();
            //Extract numbers from the end of txt string
            for (int i = txt.Length - 1; int.TryParse(txt[i].ToString(), out num); i--)
            {
                str.Insert(0, txt[i]);
            }
            if (String.IsNullOrEmpty(str.ToString()))
            {
                return txt + "1";
            }
            if (str[0].Equals('0'))
            {
                zeros = StartingZeros(str);
            }
            num = 0;
            int.TryParse(str.ToString(), out num);
            s = str.ToString();
            str.Clear();
            str.Append(txt);
            //Console.WriteLine(zeros + num.ToString());
            str.Replace(s, zeros + (num + 1).ToString());
            return str.ToString();
        }
        public static bool ValidatePassword(string password)
        {
            bool result = true;
            string invalidCharacters = @"^[a-z A-Z 0-9 \!\@\#\$\%\^\&\*\(\)\+\=\-\{\}\[\]\:\;""\'\?\<\>\,\._]{6,24}$";
            Regex passwordRegex = new Regex(password);
            if (passwordRegex.IsMatch(invalidCharacters))
            {
                Console.WriteLine("escape");
                return false;
            }
            List<Regex> tests = new List<Regex>() { new Regex("[A-Z]"), new Regex("[a-z]"), new Regex("[0-9]") };
            foreach (Regex test in tests)
            {
                result = result && test.IsMatch(password);
            }
            char[] charsInPassword = password.ToCharArray();
            for (int i = 0; i < charsInPassword.Length - 2; i++)
            {
                result = result && !(charsInPassword[i] == charsInPassword[i + 1] && charsInPassword[i] == charsInPassword[i + 2]);
            }
            return result && password.Length >= 6 && password.Length <= 24;
        }
    }
}
