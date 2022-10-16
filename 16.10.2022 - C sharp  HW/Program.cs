using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16._10._2022___C_sharp__HW
{
    internal class Program
    {
        static void Main(string[] args)
        {

            DateTime timeToCompare = DateTime.Now;

            Console.Write("Введите год от 1970 по наше время: ");
            int startYear = int.Parse(Console.ReadLine());

            if(startYear < 1970 || startYear > timeToCompare.Year)
            {
                Console.WriteLine("Неверный год");
                Console.ReadKey();
                return;

            }

            Console.Write("Введите месяц (01-12): ");
            int startMonth = int.Parse(Console.ReadLine());

            if(startMonth < 1 || startMonth > 12)
            {
                Console.WriteLine("Неверный месяц");
                Console.ReadKey();
                return;
            }

            Console.Write("Введите день в (01-31): ");
            int startDay = int.Parse(Console.ReadLine());

            if (startDay < 1 || startDay > 31)
            {
                Console.WriteLine("Неверный день");
                Console.ReadKey();
                return;
            }


            bool myException ()
            {
                // Переменная на проверку високосного года
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
