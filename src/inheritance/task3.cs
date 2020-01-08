using System;

namespace inheritance 
{
    abstract class Vehicle 
    {
        public int price, year;
        private double speed;
        public virtual double Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        
        public Vehicle() {}

        public Vehicle(int price, int year) 
        {
            this.price = price;
            this.year = year;
        }

    }

    class Car : Vehicle 
    {
        public Car(int price) : base(price, DateTime.Now.Year) {}
    }

    interface ICountable {
        public int CountPassengers();
    }

    class Plane : Vehicle, ICountable  
    {
        public int CountPassengers() 
        {
            return 100;
        }

        public int GetHeight() {
            return 2400;
        }
    }

    class Ship : Vehicle, ICountable {

        public Ship() {
            price = 55;
        }
        public int CountPassengers() { return 200; }
    }

    class StarShip : Vehicle {

        static double LIGHT_SPEED = 300*10^6;

        private double speed; 

        public override double Speed 
        {
            get { return base.Speed; }
            set 
            {
                base.Speed = speed; 
                speed = LIGHT_SPEED/(LIGHT_SPEED - value + Double.MinValue);
            }
        }
    }
}