using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Lesson_2._1
{
    internal class PersonDealsInApartment
    {
        public static void Main()
        {
            Person person = new Person();

            try
            {
                string PersonInfo = File.ReadAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json");

                Person Jsonperson = JsonSerializer.Deserialize<Person>(PersonInfo);

                if (Jsonperson.Name == null | Jsonperson.Name == string.Empty | Jsonperson.Name == "")
                {
                    City.MaternityHospital.GivePersonName();
                }

            }
            catch
            {

                City.MaternityHospital.GivePersonName();

            }

            string PersonNameFromJsonFile = File.ReadAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json");

            Person PersonName = JsonSerializer.Deserialize<Person>(PersonNameFromJsonFile);

            Console.WriteLine($"Hi, {PersonName.Name}");





            Console.WriteLine(@"What would you like to do?
1. Cook some food in mircowave?
2. Sleep some time?
3. Maybe take a bath?
4. Or leave already?");

            while (true)
            {
                string UserChoice = Console.ReadLine();

                string[] UserCommands = UserChoice.Split(' ');

                switch (UserCommands[0])
                {
                    case "Cook": string CookedFood = City.House.Apartment.Kitchen.Stove.CookProduct(UserCommands[1]); Console.WriteLine($"Mmm {CookedFood}"); person.Fed = true;
                        break;
                    case "Sleep":
                        try
                        {
                            int SleepingHours = int.Parse(UserCommands[1]);

                            City.House.Apartment.Bedroom.Bed.Slept(SleepingHours);

                        }
                        catch
                        {
                            Console.WriteLine("You can sleep only in hours, not symboles");
                        }
                        break;
                    case "Wash":
                        City.House.Apartment.Bathroom.Wash();



                        break;
                    case "Leave":
                        Console.WriteLine("Bye.");

                        Environment.Exit(0);
                        break;
                    default: Console.WriteLine("Type what would you like to do correctly");
                        break;
                }
            }




        }
    }
    public class Person
    {
        public string Name { get; set; }

        public bool Fed { get; set; }

        public bool Cleaned { get; set; } 

        public bool Sleeped { get; set; }

    }

    public class City
    {
        public class MaternityHospital
        {
            public static void GivePersonName()
            {
                Person person = new Person();

                Console.WriteLine("What`s your name?");

                person.Name = Console.ReadLine();

                string PersonInfo = JsonSerializer.Serialize(person);

                File.WriteAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json", PersonInfo);

            }
        }

        public string CityName { get; set; }

        public class House
        {
            public string HouseAdress = "Street Lenina, 7, ";
            public class Apartment
            {
                public string ApartmentNumber = "19";
                public class Bathroom
                {
                    public static void Wash()
                    {
                        Console.WriteLine("You are clean now");

                        string Json = File.ReadAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json");

                        Person JsonWriter = JsonSerializer.Deserialize<Person>(Json);

                        JsonWriter.Cleaned = true;

                        string PersonIsCleaned = JsonSerializer.Serialize(JsonWriter);

                        File.WriteAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json", PersonIsCleaned);
                    }
                }

                public class Bedroom
                {
                    public class Bed
                    {
                        public static void Slept(int SleepingHours)
                        {
                            Person person = new Person();

                            int SleepingQuality;

                            if (SleepingHours > 0 && SleepingHours < 5)
                            {
                                Console.WriteLine("Did you get enough sleep after for that amount hours?");

                                SleepingQuality = 0;
                            }
                            else if (SleepingHours > 6 && SleepingHours < 10)
                            {
                                Console.WriteLine("You slept well");

                                SleepingQuality = 1;
                            }
                            else if (SleepingHours > 11 && SleepingHours < 24)
                            {
                                Console.WriteLine("Get up, you have been sleeping almost all day long");

                                SleepingQuality = 0;
                            }
                            else
                            {
                                Console.WriteLine("Are u a bear or something?");

                                SleepingQuality = 0;
                            }

                            if (SleepingQuality == 1)
                            {
                                string Json = File.ReadAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json");

                                Person JsonWriter = JsonSerializer.Deserialize<Person>(Json);

                                JsonWriter.Sleeped = true;

                                string PersonSleep = JsonSerializer.Serialize(JsonWriter);

                                File.WriteAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json", PersonSleep);
                            }
                            else if (SleepingQuality == 0)
                            {
                                person.Sleeped = false;
                            }
                        }


                    }
                }
                public class Kitchen
                {

                    public class Stove
                    {
                        public static string CookProduct(string Food)
                        {

                            string Json = File.ReadAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json");

                            Person JsonWriter = JsonSerializer.Deserialize<Person>(Json);

                            JsonWriter.Fed = true;

                            string PersonIsFeeded = JsonSerializer.Serialize(JsonWriter);

                            File.WriteAllText(@"C:\Users\windo\source\repos\Lesson_2.1\Lesson_2.1\PersonInfo.json", PersonIsFeeded);

                            return ("cooked " + Food);
                        }
                    }
                }

            }
        }
    }
}
