using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._10._2022___C_sharp__HW
{
    // Never used
    enum DayOfWeekEnum:byte
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime timeToCompare = DateTime.Now;

            Console.Write("Please, enter Year starts from 1970 until present days: ");
            int startYear = int.Parse(Console.ReadLine());

            if(startYear < 1970 || startYear > timeToCompare.Year)
            {
                Console.WriteLine("Wrong year");
                Console.ReadKey();
                return;

            }

            Console.Write("Enter month (01-12): ");
            int startMonth = int.Parse(Console.ReadLine());

            if(startMonth < 1 || startMonth > 12)
            {
                Console.WriteLine("Wrong month");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter day (01-31): ");
            int startDay = int.Parse(Console.ReadLine());

            if (startDay < 1 || startDay > 31)
            {
                Console.WriteLine("Wrong day");
                Console.ReadKey();
                return;
            }


            bool myException ()
            {
                // Variable to check Leap Year
                bool isLeapYear = false;

                if(startYear % 4 == 0)
                {
                    isLeapYear = true;
                }

                // February
                if ((startMonth == 2 && startDay == 29 && !isLeapYear) || (startMonth == 2 && startDay == 30) || (startMonth == 2 && startDay == 31))
                    return true;

                //April, June, September, November
                if ((startMonth == 4 && startDay == 31) || (startMonth == 6 && startDay == 31) || (startMonth == 9 && startDay == 31) || (startMonth == 11 && startDay == 31)) 
                    return true;

                else return false;
            }

            try
            {
                if(myException())
                {
                    throw new ArgumentOutOfRangeException(nameof(startDay), $"Wrong date: {startDay}");
                }
                System.DateTime timeToWorkWith = new System.DateTime(startYear, startMonth, startDay);

                string dayOfWeek = timeToWorkWith.DayOfWeek.ToString();

                Console.WriteLine($"День недели: {dayOfWeek}");
                Console.ReadKey();
            }
            catch (System.ArgumentOutOfRangeException argumentOutOfRangeException)
            {
                Console.WriteLine($"Error: {argumentOutOfRangeException.Message}");
                Console.ReadKey();
            }
        }
    }
}
