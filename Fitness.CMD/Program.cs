using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace Fitness.CMD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness.CMD.Languages.Message", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello",culture));

            Console.WriteLine(resourceManager.GetString("EnterName",culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("Вес");
                var height = ParseDouble("Рост");


                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать ?");
            Console.WriteLine("Е - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                //Console.WriteLine(eatingController.Eating);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();

        }

        private static (Food Food,double Weight) EnterEating()
        {
            Console.Write("ВВедите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("Калорийность");
            var proteins = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories,proteins,fats, carbs);


            return (Food: product,Weight: weight);

        }

        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("ВВедите дату рождения (dd.mm.yyyy) ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}");
                }
            }
        }
    }
}