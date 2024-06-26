using System;
using System.ComponentModel;
using System.Runtime.ConstrainedExecution;

namespace rente3car
{
    internal class car
    {
        public string CarName { get; set; }
        public int BanId { get; set; }
        public bool IsRented { get; set; }

        public car()
        {
            IsRented = false;
        }
    }

    internal class Customer
    {
        public string Name { get; set; }
        public int CustomerId { get; set; }
        public int CarCount { get; set; }
        public car[] RentedCars { get; set; }

        public Customer()
        {
            RentedCars = new car[3];
            CarCount = 0;
        }
    }

    internal class RentCar
    {
        public int CarCount { get; set; }
        public int CustomerCount { get; set; }
        public car[] Cars { get; set; }
        public Customer[] Customers { get; set; }

        public RentCar()
        {
            CarCount = 0;
            Cars = new car[50];
            Customers = new Customer[100];
            CustomerCount = 0;
        }

        public void AddCar(car car)
        {
            if (CarCount < 50)
            {
                Cars[CarCount] = car;
                CarCount++;
            }
            else
            {
                Console.WriteLine("Cannot add more than 50 cars.");
            }
        }

        public void RemoveCar(int banID)
        {
            int count = 0;
            foreach (var item in Cars)
            {
                if (item.BanId == banID)
                {
                    CarCount--;
                    Cars[CarCount-1] = null;
                    break;
                }
                count++;
            }
        }

        public void AddCustomer(Customer customer)
        {
            if (CustomerCount < 100)
            {
                Customers[CustomerCount] = customer;
                CustomerCount++;
            }
            else
            {
                Console.WriteLine("Cannot add more than 100 customers.");
            }
        }

        public void RemoveCustomer(int customerID)
        {
           
            int count = 0;
            foreach (var item in Customers)
            {
                if (item.CustomerId == customerID)
                {

                    Cars[count] = null;
                    break;
                }
                count++;

            }
        }
        public void RentACar(int customerID, int banID)
        {
            car car = new car();
            bool check = true;
            foreach (var item in Cars)
            {
                if (item.BanId == banID)
                {
                    car = item;
                    item.IsRented = true;
                    check = false;
                    break;
                }
            }
            if (check)
            {

                Console.WriteLine("gdgfg");
            }
            else
            {
                check = true;
                int ecount = 0;
                foreach (var item in Customers)
                {
                    ecount++;
                    if (item.CustomerId == customerID)
                    {
                        if (item.CarCount < 3)
                        {
                            item.CarCount++;
                            item.RentedCars[ecount] = car;
                            check = false;
                            break;
                        }
                    }
                }
            }

        }

        public void ReturnCar(int customerID, int banID)
        {
            car car = new car();
            bool check = true;
            foreach (var item in Cars)
            {
                if (item.BanId == banID)
                {
                    car = item;
                    item.IsRented = false;
                    check = false;
                    break;
                }
            }
            if (check)
            {

                Console.WriteLine("gdgfg");
            }
            else
            {
                check = true;
                int ecount = 0;
                foreach (var item in Customers)
                {
                    ecount++;
                    if (item.CustomerId == customerID)
                    {
                        item.CarCount--;
                        item.RentedCars[ecount] = null;
                        check = false; break;
                    }
                }
            }
        }
    }
}