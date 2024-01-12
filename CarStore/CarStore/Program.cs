using System;
using System.Globalization;

namespace CarStore
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true) 
            {
                try 
                {
                    run();

                }
                catch(Exception excepton)
                {
                    Console.WriteLine(excepton.Message);
                }
            }
            static void run()
            {
                Console.WriteLine("1:add car \n" +
                    "2:add user \n" +
                    "3:Rent Car \n" +
                    "4:Use Rented Car");
                var option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 1:
                        {
                            var type = GetInt("type 1:IR 2.FR");
                            if(type !=1 && type != 2)
                            {
                                throw new Exception("not valid type");
                            }
                            var carName = GetString("car name?");
                            var carModel = GetInt("car model?");
                            var carSpeed = GetInt("car speed?");
                            var carDailyPrice = GetInt("car dailyprice?");
                            var carCount = GetInt("car count?");
                            Store.AddCar(type, carName, carSpeed, carModel,carDailyPrice, carCount);
                            break;
                        }
                    case 2:
                        {
                            var userName = GetString("user name?");
                            Store.AddUser(userName);
                            break;
                        }
                    case 3:
                        {
                            var carName = GetString("car name?");
                            var userName = GetString("user name?");
                            DateTime dateToReturnTheCar;
                            string pattern = "MM/dd/yyyy";
                            bool IsValid = false;
                            do
                            {
                                Console.WriteLine("Enter date that you give back the book?(MM/dd/yyyy)");
                                IsValid = DateTime.TryParseExact(Console.ReadLine(), pattern, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateToReturnTheCar);

                            } while (!IsValid);
                            Store.RentCar(userName,carName,dateToReturnTheCar);
                            break;
                        }
                    case 4:
                        {
                            Store.ShowRentedCar();
                            break;
                        }
                }
            }
          
        
        }
        static string GetString(string message)
        {
            Console.WriteLine(message);
            string value = Console.ReadLine()!;
            return value;
        }

        static int GetInt(string message)
        {
            Console.WriteLine(message);
            int value = int.Parse(Console.ReadLine()!);
            return value;
        }
    }
}
