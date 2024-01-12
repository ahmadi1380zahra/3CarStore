using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore
{
   static class Store
    {
        private static List<Cars> _cars = new();
        private static List<User> _users = new();
        public static void AddCar(int type,string name,int speed,int model,int price,int count)
        {
            if (type == 1)
            {
                var iranianCar = new IranianCars(name);
                iranianCar.SetModel(model);
                iranianCar.SetSpeed(speed);
                iranianCar.SetPrice(price);
                iranianCar.SetCount(count);
                _cars.Add(iranianCar);
            }
            if (type == 2)
            {
                var foreighnianCar = new Foreigncar(name);
                foreighnianCar.SetModel(model);
                foreighnianCar.SetSpeed(speed);
                foreighnianCar.SetPrice(price);
                foreighnianCar.SetCount(count);
                _cars.Add(foreighnianCar);
            }
        }
        public static void AddUser(string name)
        {
            var user = new User(name);
            if (_users.Any(item => item.Name == name))
            {
                throw new Exception("name should be unique");
            }
            _users.Add(user);
        }
        public static void RentCar(string userName,string carName,DateTime returnDate)
        {
            var user = _users.Find(item=>item.Name==userName);
            var car = _cars.Find(item=>item.Name==carName);
            car.SetCountAfterRent();
            user.AddUserRentCars(car.Name,returnDate,car.DailyPrice,(car is IranianCars? CarType.Iranian : CarType.forignian ));
        }
        public static void ShowRentedCar()
        {
           
                foreach (var user in _users)
                {
                    Console.WriteLine($"{ user.Name } ");
                    user.RentalUserCar();
                }

            
        }
    }
}
