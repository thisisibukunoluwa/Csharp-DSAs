﻿// See https://aka.ms/new-console-template for more information

namespace GettingStarted { 
    // Place your classes, interfaces, enums, etc. here

    class Program
    {
        static void Main(string[] args)
        {
            // Entry point of your application
            // You can write your code logic here or call other methods or classes
            // to start the execution of your program

            Person person = new Person("Mary", 20);

            person.Relocate("London");

            double distance = person.GetDistance("Warsaw");

            Console.WriteLine(distance);


            // declaration
            int number;

            // assignment
            number = 500;


            // assignment and declaration
            int number1 = 500;


            // constant - immutable values

            const int DAYS_IN_WEEK = 7;


            // enumerations 
            //enum Language { PL, EN, DE };

            //Language language = language.PL;

            //switch (language)
            //{
            //    case Language.PL:
            //        Console.WriteLine("Polish");
            //        break;
            //    case Language.DE:
            //        Console.WriteLine("German");
            //        break;
            //    default:
            //        Console.WriteLine("English");
            //        break;
            //}

            // strings

            string firstName = "Marcin", lastName = "Jamro";
            int year = 1988;

            string note = firstName + " " + lastName.ToUpper() + " was born in " + year;

            string initials = firstName[0] + "." + lastName[0] + ".";


            // we can also use the format static method for constructing the string

            string note1 = string.Format("{0} {1} was born in {2}", firstName, lastName.ToUpper(), year);


            // interpolated string
            string note2 = $"{firstName} {lastName.ToUpper()} was born in {year}";


            int age = 28;
            object ageBoxing = age;
            int ageUnboxing = (int)ageBoxing;

            //dynamic
        }
    }
}



//classes

public class Person
{
    private string _location = string.Empty;
    public string Name { get; set; }
    public int Age { get; set; }

    private Person() => Name = "___";

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    public void Relocate(string location)
    {
        if (!String.IsNullOrEmpty(location))
        {
            _location = location;
        }
    }
    public double GetDistance(string location)
    {
        return DistanceHelpers.GetDistance(_location, location);
    }
}


public static class DistanceHelpers
{
    private const double EarthRadiusKm = 6371.0;

    public static double GetDistance(string location1, string location2)
    {
        var coordinates1 = GetCoordinates(location1);
        var coordinates2 = GetCoordinates(location2);

        var lat1 = ToRadians(coordinates1.latitude);
        var lon2 = ToRadians(coordinates2.longitude);
        var lat2 = ToRadians(coordinates2.latitude);
        var lon1 = ToRadians(coordinates1.latitude);


        var dlon = lon2 - lon1;
        var dlat = lat2 - lat1;

        var a = Math.Pow(Math.Sin(dlat / 2), 2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Pow(Math.Sin(dlon / 2), 2);
        var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
        var distance = EarthRadiusKm * c;

        return distance;
    }
    private static (double latitude, double longitude) GetCoordinates(string location)
    {

        var coordinates = new Dictionary<string, (double, double)>
        {
            { "New York", (40.7128, -74.0060) },  // New York City coordinates
            { "L2ondon", (51.5074, -0.1278) },
            {"Warsaw",(52.2297,21.0122) }
        };

        if (coordinates.ContainsKey(location))
        {
            return coordinates[location];
        }
        else
        {
            throw new ArgumentException("Location coordinates not found");
        }
    }
    private static double ToRadians(double degrees)
    {
        return degrees * Math.PI / 180.0;
    }
}