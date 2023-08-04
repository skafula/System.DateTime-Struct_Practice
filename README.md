# System.DateTime-Struct_Practice

**How can you perform date arithmetic and comparison operations using the DateTime structure in C#?**

The DateTime structure provides various methods and properties for performing date arithmetic and comparison operations in C#. 
For example, you can use the AddDays(), AddMonths(), and AddYears() methods to perform addition or subtraction of days, months, and years to a DateTime value. 
You can also use the CompareTo() method or comparison operators (>, <, ==, etc.) to compare two DateTime values.

DateTime currentDate = DateTime.Now;
DateTime futureDate = currentDate.AddDays(7);
DateTime pastDate = currentDate.AddMonths(-1);

int result = currentDate.CompareTo(futureDate);
bool isPast = pastDate < currentDate;

**How can you work with dates and times in C# using the DateTime. Write some sample scenarios.**

The DateTime structure in C# provides built-in functionality for working with dates and times. Here are some commonly used DateTime methods and
techniques for date manipulation:

Creating a DateTime object:

You can create a DateTime object using the DateTime constructor, which takes parameters for year, month, day, hour, minute, and second.

For example:

DateTime dt = new DateTime(2023, 4, 16, 10, 30, 0);


Getting the current date and time:

You can get the current date and time using the DateTime.Now property, which returns a DateTime object representing the current date and time.

DateTime currentDateTime = DateTime.Now;


Formatting a DateTime object:

You can format a DateTime object into a string representation using the ToString() method and providing a format string.

For example:

DateTime dt = DateTime.Now;
string formattedDate = dt.ToString("MM/dd/yyyy HH:mm:ss");


Adding or subtracting time from a DateTime object:

You can add or subtract time from a DateTime object using the Add() and Subtract() methods. For example:

DateTime dt = DateTime.Now;
DateTime futureDate = dt.Add(TimeSpan.FromDays(7)); // add 7 days to the current date
DateTime pastDate = dt.Subtract(TimeSpan.FromHours(12)); // subtract 12 hours from the current date


Comparing DateTime objects:

You can compare DateTime objects using comparison operators such as <, >, <=, >=, ==, and != to perform date and time comparisons.

For example:

DateTime dt1 = new DateTime(2023, 4, 16);
DateTime dt2 = new DateTime(2023, 4, 17);

if (dt1 < dt2)
{
Console.WriteLine("dt1 is earlier than dt2");
}
else if (dt1 > dt2)
{
Console.WriteLine("dt1 is later than dt2");
}
else
{
Console.WriteLine("dt1 and dt2 are the same");
}


Parsing a string to a DateTime object:

You can parse a string representing a date and time into a DateTime object using the DateTime.Parse() or DateTime.TryParse() methods.

For example:

string dateString = "04/16/2023 10:30:00";
DateTime dt = DateTime.Parse(dateString); // throws an exception if the string is not a valid DateTime format

// OR

if (DateTime.TryParse(dateString, out DateTime result))
{
  // successful parsing
  dt = result;
}




Performing other date manipulation operations:

The DateTime structure also provides many other useful methods for various date and time manipulation operations, 
such as getting the day of the week, getting the number of days between two dates, getting the age of a person based on their birthdate, etc. 
You can refer to the official Microsoft documentation for a comprehensive list of DateTime methods and their usage.
