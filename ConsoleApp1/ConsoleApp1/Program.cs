using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            VolkswagenUp myCar = new VolkswagenUp();
            myCar.status();
            myCar.refuel(3);
            myCar.status();
            myCar.driveMiles(10);
            myCar.status();
        }
    }

    class Car
    {
        public string model;
        public float tankSize; //in gallons
        public float fuel; //in gallons
        public float efficiency; //in miles per gallon
        public float distance; //in miles

        public Car()
        {
            model = "Generic";
            tankSize = 15;
            fuel = 0;
            efficiency = 50;
            distance = 0;
        }
        public void playSound()
        {
            Console.WriteLine("Vroom");
        }

        public void status()
        {
            Console.WriteLine($"Car status\n----------\nModel: {model}\nFuel: {fuel}/{tankSize} gallons\nFuel Efficiency: {efficiency} mpg\nTotal distance: {distance} miles\n");
        }

        public void driveMiles(float distance)
        {
            float fuelUsed = distance / efficiency;
            float distanceTraveled;

            if (fuel < fuelUsed)
            {
                distanceTraveled = fuel * efficiency;
                fuelUsed = fuel;
                fuel = 0;
            }
            else
            {
                distanceTraveled = distance;
                fuel -= fuelUsed;
            }

            distance += distanceTraveled;

            Console.WriteLine($"Tried driving {distance} miles\nSuccessfully drove {distanceTraveled} miles\nUsed {fuelUsed} gallons of fuel\nCurrent fuel is now {fuel} gallons\n");
        }

        public void refuel(float amount)
        {
            float fuelAdded;
            if (fuel + amount > tankSize)
            {
                fuelAdded = tankSize - fuel;
                fuel = tankSize;
            }
            else
            {
                fuel += amount;
                fuelAdded = amount;
            }

            Console.WriteLine($"Added {fuelAdded} gallons of fuel\nCurrent fuel is now {fuel}/{tankSize}\n");
        }
    }
    class VolkswagenUp : Car
    {
        public VolkswagenUp()
        {
            model = "VolkswagenUp";
            efficiency = 55;
            tankSize = 7.7f;

        }
    }
}
