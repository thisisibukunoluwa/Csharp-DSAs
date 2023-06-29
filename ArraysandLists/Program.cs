﻿using System.Globalization;
using System.Collections;

namespace arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            // initialization
            int[] numbers;
            // declaration
            numbers = new int[5];

            //initialization and declaration;
            int[] numbers1 = new int[5];

            // all elements have default values, zeros in the case of integer
            //values we can assign values to the elements using array indexing 
            numbers[0] = 7;
            numbers[1] = 4;
            numbers[2] = 3;

            int[] numbers2 = new int[] { 9, -11, 4, 56, 78 };

            // get values using the [] operator
            int middle = numbers[2];

            string[] months = new string[] {"January","February","March","April","May",
             "June","July","August","September","October","November","December"};

            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months[month - 1] = name;


            }
            foreach (string month in months)
            {
                Console.WriteLine($"--> {month}");
            }

            // multidimensional arrays
            //2 dimensional array
            // we initialized an array with five rows and two columns
            int[,] numbersArr1 = new int[5, 2];

            //3 dimensional array
            int[,,] numbersArr2 = new int[5, 4, 3];

            //2 dimensional array declared and initialized
            int[,] numbersArr3 = new int[,] {
                { 9, 5, -9},
                { -11, 4, 0 },
                { 6, 115, 3 },
                { -12, -9, 71 },
                { 1, -6, -1 }
            };

            //int number2 = numbersArr3[1][3];

            //multiplication table
            // build the multiplication table
            int[,] results = new int[10, 10];

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i, j] = (i + 1) * (j + 1);
                }
            }
            // display the results
            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    Console.WriteLine("{0,4}", results[i, j]);
                }
                Console.WriteLine();
            }

            // Game map


            //Console.ReadLine();
            TerrainEnum[,] map =
            {
                {
                    TerrainEnum.SAND, TerrainEnum.SAND, TerrainEnum.SAND,
                    TerrainEnum.SAND, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS, TerrainEnum.GRASS, TerrainEnum.GRASS,
                    TerrainEnum.GRASS
                },
                {
                    TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                     TerrainEnum.WATER, TerrainEnum.WATER, TerrainEnum.WATER,
                     TerrainEnum.WATER, TerrainEnum.WALL, TerrainEnum.WATER,
                     TerrainEnum.WATER
                }
            };

            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int column = 0; column < map.GetLength(1); column++)
                {
                    Console.ForegroundColor = map[row, column].GetColor();
                    Console.Write(map[row,column].GetChar() + " ");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;

            //Jagged Arrays
            //int[][] numbersJagged = new int[4][];

            //numbers[0] = new int[] { 9, 5, -9 };
            //numbers[1] = new int[] { 0, -3, 12, 51, -3 };
            //numbers[3] = new int[] { 54 };

            int[][] numbersJagged1 =
            {
                new int[] {9,5,-9},
                new int[] {0,-3, 12, 51,-3 },
                null,
                new int[] {54}
            };
            int number = numbersJagged1[1][2];
            numbersJagged1[1][3] = 50;

            Random random = new Random();

            // get the number types of transport from getting the enum length
            int TransportTypesCount = Enum.GetNames(typeof(TransportEnum)).Length;

            // initialize a jagged array with 12 elements, each is a one dimensional array

            TransportEnum[][] transport = new TransportEnum[12][];

            for (int month = 1; month <= 12; month++)
            {
                //get the number of days in a month 
                int DaysCount = DateTime.DaysInMonth(DateTime.Now.Year, month);

               transport[month - 1] = new TransportEnum[DaysCount];

                // populate all the days in the month with random enum types
                for (int day = 1;day <= DaysCount; day++)
                {
                   int randomType = random.Next(0,TransportTypesCount);

                   transport[month - 1][day - 1] = (TransportEnum)randomType;
                }
            }

            string[] monthNames = GetMonthNames();

            int monthNamesPart = monthNames.Max(n => n.Length) + 2;

            for (int month = 1; month <= transport.Length; month++)
            {
                Console.Write($"{monthNames[month - 1]}:".PadRight(monthNamesPart));

                for (int day = 1; day <= transport[month - 1].Length; day++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor =
               transport[month - 1][day - 1].GetColor();
                    Console.Write(transport[month - 1][day - 1].GetChar());
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }



            static string[] GetMonthNames()
            {
                string[] names = new string[12];

                for (int month = 1; month <= 12; month++)
                {
                    DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                    string name = firstDay.ToString("MMMM",
                        CultureInfo.CreateSpecificCulture("en"));
                    names[month - 1] = name;
                }
                return names;
            }

            //lists
            // add an element or elements to an arraylist 
            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.AddRange(new int[] { 6, -7, 8 });
            arrayList.AddRange(new object[] { "Marcin", "Mary" });
            arrayList.Insert(5, 9.8);

            object first = arrayList[0];
            // this casting is necessary, because the array list stores object values
            int third = (int)arrayList[2];

            foreach(object element in arrayList)
            {
                Console.WriteLine(element);
            }
            // count returns the number of elements stored in the arrayList
            int count = arrayList.Count;
            // capacity returns the how many elements can be stored within it 
            int capacity = arrayList.Capacity;

            //check if arraylist contains element with a particular value
            bool containsMary = arrayList.Contains("Mary");

            // find the index of an element
            //first occurrence of an element
            int minusIndex = arrayList.IndexOf(-7);

            //last occurence of an element
            int minusIndexLast = arrayList.LastIndexOf(-7);

            arrayList.Remove(5);

            Console.WriteLine(containsMary.ToString());
            Console.WriteLine(capacity.ToString());
            Console.WriteLine(minusIndex.ToString());
            Console.WriteLine(minusIndexLast.ToString());
            //Generic List
            //average value
            List<double> numbersList = new List<double>();

            do
            {
                Console.Write("Enter a number:");

                string numberString = Console.ReadLine();

                if (!double.TryParse(numberString,NumberStyles.Float,new NumberFormatInfo(),out double numberResult))
                {
                    break;
                }
                numbersList.Add(numberResult);
                Console.WriteLine($"The average value is {numbers.Average()} ");
            }
            while (true);



            //list of people
            // add people to the people list
            List<Person> people = new List<Person>();
            people.Add(new Person()
            {
                name = "Marcello",
                Country = CountryEnum.PL,
                age = 36
            });
            people.Add(new Person()
            {
                name = "Rinola",
                Country = CountryEnum.DE,
                age = 23
            });
            people.Add(new Person()
            {
                name = "letam",
                Country = CountryEnum.UK,
                age = 23
            });

            // Here we used a lINQ expression to 
            List<Person> results1 = people.OrderBy(p => p.name).ToList();

            foreach(Person person in people)
            {
                Console.WriteLine($"{person.name} {person.age} years from {person.Country}");
            }

        }
    }
}
