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

        
        public void AddCar(car car, int banID)
        {

            foreach (var item in Cars)
            {
                if (item != null && item.BanId == banID)
                {
                    Console.WriteLine("Bu ID ile maşın artıq mövcuddur.");
                    return;
                }
            }

     
            if (CarCount < 50)
            {
                Cars[CarCount] = car;
                CarCount++;
            }
            else
            {
                Console.WriteLine("50-den artıq maşın elave etmək mümkün deyil.");
            }
        }

        public void RemoveCar(int banID)
        {
        
            bool check = false;
            for (int i = 0; i < Cars.Length; i++)
            {
                if (Cars[i] != null && Cars[i].BanId == banID)
                {
                    Cars[i] = null;
                    check = true;
                    Console.WriteLine("silindi");
                    break;
                }
            }
            if (!check)
            {
                Console.WriteLine("Bu ID ile car mövcud deyil.");
            }
        }

        public void AddCustomer(Customer customer,int customerID)
        {
            foreach (var item in Customers)
            {
                if (item != null && item.CustomerId==customerID)
                {
                    Console.WriteLine("Bu ID ile customer artıq mövcuddur.");
                    return;
                }
            }
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
            bool check = false;
            for (int i = 0; i < Customers.Length; i++)
            {
                if ( Customers[i]!=null && Customers[i].CustomerId == customerID)
                {
                    Customers[i] = null;
                    check = true;
                    Console.WriteLine("silindi");
                    break;
                }
            }
            if (!check)
            {
                Console.WriteLine("Bu ID ile müşteri mövcud deyil.");
            }
        }





        public void RentACar(int banID, int customerID)
        {
            bool carFound = false;


            foreach (var item in Cars)
            {
                if (item != null && item.BanId == banID && !item.IsRented)
                {
                    item.IsRented = true;
                    carFound = true;
                    break;
                }
            }


            if (!carFound)
            {
                Console.WriteLine("bele masin movcu deyil ve yada icareye verilib");
                return;
            }


            foreach (var customer in Customers)
            {
                if (customer != null && customer.CustomerId == customerID)
                {

                    if (customer.CarCount < 3)
                    {

                        for (int i = 0; i < customer.RentedCars.Length; i++)
                        {
                            if (customer.RentedCars[i] == null)
                            {

                                car rentedCar = Array.Find(Cars, c => c != null && c.BanId == banID);
                                if (rentedCar != null)
                                {
                                    customer.RentedCars[i] = rentedCar;
                                    customer.CarCount++;
                                    Console.WriteLine("Maşın müşteriye uğurla kiraye verildi.");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Müşteri maksimum maşın limitine çatıb.");
                        return;
                    }
                }
            }


            Console.WriteLine("Bele bir müşteri tapılmadı.");
        }

        public void ReturnCar(int banID, int customerID)
        {
            bool carFound = false;


            foreach (var item in Cars)
            {
                if (item != null && item.BanId == banID)
                {
                    item.IsRented = false;
                    carFound = true;
                    break;
                }
            }

            if (!carFound)
            {
                Console.WriteLine("Bele bir maşın tapılmadı.");
                return;
            }


            bool customerFound = false;
            foreach (var customer in Customers)
            {
                if (customer != null && customer.CustomerId == customerID)
                {
                    customerFound = true;

                    for (int i = 0; i < customer.RentedCars.Length; i++)
                    {
                        if (customer.RentedCars[i] != null && customer.RentedCars[i].BanId == banID)
                        {
                            customer.RentedCars[i] = null;
                            customer.CarCount--;
                            Console.WriteLine("Maşın icaredən qaytarıldı.");
                            return;
                        }
                    }
                }
            }


            if (!customerFound)
            {
                Console.WriteLine("Bele bir müşteri tapılmadı.");
            }
        }



    }
}
