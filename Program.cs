using System;
using System.Transactions;

internal class Program
{
    private static void Main(string[] args)
    {
        //DateTime is a struct object. Format: "yyyy-MM-dd hh:mm:ss.fff tt" year-month-day hour-minute-second-millisecond AM/PM. DateTime.Parse("...") / Convert.ToDateTime("...")
        Person person = new Person() { Name = "John" };
        person.DateOfBirth = DateTime.Parse("1992-01-01 11:11:11.111 pm"); //As set the DateTime value from a string it must be DateTime.Parsed (Of course the hh:mm:ss:fff tt is optional and it's default value is 00:00:00.
        Console.WriteLine(person.DateOfBirth.ToString()); //Printd in the format Windows uses (culture). If don't use ToString explicitly then WriteLine calls it implicitly ***

        //DateTime methods to get (readonly) the values one by one (all int):

        #region Properties of DateTime:
        //Day, Month, Year, Hour, Minute, Second, Millisecond, DayOfYear, DayOfWeek DayOfWeek, static DateTime Now

        Console.WriteLine("Year: " + person.DateOfBirth.Year);
        Console.WriteLine("Month: " + person.DateOfBirth.Month);
        Console.WriteLine("Day: " + person.DateOfBirth.Day);
        Console.WriteLine("Hour: " + person.DateOfBirth.Hour);
        Console.WriteLine("Minute: " + person.DateOfBirth.Minute);
        Console.WriteLine("Second: " + person.DateOfBirth.Second);
        Console.WriteLine("Millisecond: " + person.DateOfBirth.Millisecond);
        Console.WriteLine("Day of year: " + person.DateOfBirth.DayOfYear);
        Console.WriteLine("Day of week (enum): " + person.DateOfBirth.DayOfWeek); //enum type
        Console.WriteLine("Day of week (int)" + (int)person.DateOfBirth.DayOfWeek); //starts from Sunday - 0, Monday - 1 ... 
        Console.WriteLine(".Now: " + DateTime.Now); // ***

        #endregion

        #region Methods of DateTime:
        //string ToString(), string ToString(string format), string ToShortDateString(), string ToLongDateString(), string ToShortTimeString(), string ToLongTimeString()
        //static int DaysInMonth(int year, int month), static DateTime Parse(string value)
        //static DateTime ParseExact(string value, string format, IFormatProvider provider, DateTimeStyle style)

        //DateTime dt = DateTime.Parse("2020-12-12 23:59:59.999 pm");
        DateTime dt = DateTime.ParseExact("20?04?1986 23!16!13!111", "dd?MM?yyyy HH!mm!ss!fff",
            System.Globalization.CultureInfo.InvariantCulture,
            System.Globalization.DateTimeStyles.None);
        string date = dt.ToString();
        Console.WriteLine("ParseExact: " + date);
        Console.WriteLine(dt.ToString("dd-MM-yyyy ss:mm:hh.fff tt"));
        date = dt.ToShortDateString();
        Console.WriteLine(date);
        date = dt.ToLongDateString();
        Console.WriteLine(date);
        date = dt.ToShortTimeString();
        Console.WriteLine(date);
        date = dt.ToLongTimeString();
        Console.WriteLine(date);
        Console.WriteLine("DaysInMont: " + DateTime.DaysInMonth(1986, 4));


        #endregion

        DateTime dtCon = new DateTime(1999, 05, 01, 22, 5, 2);
        Console.WriteLine(dtCon.ToString());

        #region Subtracting

        Console.WriteLine();
        Console.WriteLine("*****************   Date Subtracting   *****************");

        Employee emp = new() { Name = "Barbara", DateOfJoining = DateTime.Parse("2019-06-13") };
        DateTime today = DateTime.Now;

        //emp.ExperienceYears = today.CompareTo(emp.DateOfJoining) > 0
        //    ? today.Subtract(emp.DateOfJoining).TotalDays / 365 //same as TimeSpan ts = (today - emp.DateOfJoining / 365) -> returns a TimeSpan struct
        //    : -1; //CompareTo returns -1 if Now is older, 0 if equal and 1 if () is the older date
        //Console.WriteLine(Math.Floor(emp.ExperienceYears));
        //emp.ExperienceMonths = Math.Floor(emp.ExperienceYears * 12);
        //Console.WriteLine(emp.ExperienceMonths);
        if (today.CompareTo(emp.DateOfJoining) == 1)
        {
            TimeSpan diff = today.Subtract(emp.DateOfJoining);
            emp.ExperienceYears = Math.Floor(diff.TotalDays / 365);
            emp.ExperienceMonths = Math.Floor((diff.TotalDays / 365 - emp.ExperienceYears) * 12);
            Console.WriteLine($"Emp experience: {emp.ExperienceYears} years and {emp.ExperienceMonths} months.");
        }
        else
        {
            Console.WriteLine("Can not calculate experience.");
        }

        #endregion

        #region Date Addition

        Console.WriteLine();
        Console.WriteLine("*****************   Date Addition   *****************");

        //It's possible to add to a DT object every part of the DT like AddYear(), AddMillisecond() etc. - All works with negative value - Works with double values
        DateTime rDt = DateTime.Parse("2022-12-31");
        Console.WriteLine("Date \"now\": " + rDt.ToString());
        Console.WriteLine("After 12 days: " + rDt.AddDays(12.55).ToString());
        Console.WriteLine("Before 12 days: " + rDt.AddDays(-12).ToString());

        #endregion
    }
    public class Person
    {
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; } //Created as DateTime type
        public DateTime DateOfJoining { get; set; }
    }
    public class Employee
    {
        public string Name { get; set; }
        public DateTime DateOfJoining { get; set; }
        public double ExperienceYears { get; set; }
        public double ExperienceMonths { get; set; }
    }

}