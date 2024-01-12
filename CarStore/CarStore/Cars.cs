using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarStore
{
   abstract class Cars
    {
        protected Cars(string name)
        {
        Name=name;

        }
        public string Name { get; set; }
        public int DailyPrice { get;private set; }
        public int Model { get;protected set; }
        public int Speed { get;private set; }
        public int Count { get;private set; }

        public virtual void SetCountAfterRent()
        {
            if (Count == 0)
            {
                throw new Exception("this car is rented");
            }
            var newCount = Count;
            SetCount(--newCount);
        }
        public virtual void SetCount(int count)
        {
            if (count < 0)
            {
                throw new Exception("count cant be negative");
            }
            Count = count;
        }
        public virtual void SetPrice(int price)
        {
            if (price < 0)
            {
                throw new Exception("price cant be negative");
            }
            DailyPrice = price;
        }

        public virtual void SetSpeed(int speed)
        {
            if (speed < 0)
            {
                throw new Exception("speed cant be negative");
            }
            Speed = speed;
        }
    }
    class IranianCars:Cars
    {
        public IranianCars(string name):base(name)
        {

        }
        public override void SetPrice(int price)
        {
            if (price>500)
            {
                throw new Exception("highst price for iranian car is 500");
            }
            base.SetPrice(price);
        }

        public override void SetSpeed(int speed)
        {
            if (speed > 120)
            {
                throw new Exception("highst speed for iranian car is 120");
            }
            base.SetSpeed(speed);
        }
        public void SetModel(int model)
        {

            if (model <= 2010)
            {
                throw new Exception("iran model cant be under 2010");
            }
            Model = model;
        }
     
    }
    class Foreigncar : Cars
    {
        public Foreigncar(string name):base(name)
        {

        }
        public override void SetPrice(int price)
        {
            if (price > 800)
            {
                throw new Exception("highst price for Foreigncar car is 800");
            }
            base.SetPrice(price);
        }
        public override void SetSpeed(int speed)
        {
            if (speed > 200)
            {
                throw new Exception("highst speed for Foreigncar  is 200");
            }
            base.SetSpeed(speed);
        }
        public void SetModel(int model)
        {

            if (model <= 1990)
            {
                throw new Exception(" Foreign model cant be under 1990");
            }
            Model = model;
        }

    }
}
