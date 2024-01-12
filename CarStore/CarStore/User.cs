using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore
{
    class User
    {
        private List<UserRentedCar> _UserRentedCar;
        public User(string name)
        {
            _UserRentedCar = new();
            Name = name;
        }
        public string Name { get; set; }

        public void AddUserRentCars(string carName,DateTime returnDate,int rentPrice,CarType carType)
        {
            _UserRentedCar.Add(new UserRentedCar(carName,returnDate,rentPrice,carType));
        }
        public void RentalUserCar()
        {
            foreach (var rentalCar in _UserRentedCar)
            {
                //{((int)(user.ReturnDate[j] - user.RentDate[j]).TotalDays)*book.DailyPrice}
                var daysRentCount = (int)(Math.Ceiling((rentalCar.ReturnDate - rentalCar.RentDate).TotalDays));
                var cost = daysRentCount * rentalCar.PriceToRent;
                Console.WriteLine($"car is : {rentalCar.CarName}" +
                    $" the daily price was: {rentalCar.PriceToRent} " +
                    $"rent at : {rentalCar.RentDate}" +
                    $" will return at : {rentalCar.ReturnDate}" +
                    $" it  cost {cost}" +
                    $" this car will be retun in {Math.Ceiling((rentalCar.ReturnDate - DateTime.Now).TotalDays)} days");
            }
        }
    }
    class UserRentedCar
    {
        public UserRentedCar(string carName,DateTime returnDate,int priceToRent, CarType carType)
        {
            CarName = carName;
            RentDate = DateTime.Now;
            ReturnDate = returnDate;
            PriceToRent = priceToRent;
            CarType = carType;
        }
        public string CarName { get; set; }
        public CarType CarType { get; set; }
        public int PriceToRent { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
    enum CarType
    {
        Iranian,
        forignian
    }

}
