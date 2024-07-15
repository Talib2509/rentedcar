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
        public List<car> RentedCars { get; set; }

        public Customer()
        {
            RentedCars = new List<car>();
            CarCount = 0;
        }
    }

    internal class RentCar
    {
        public int CarCount { get; set; }
        public int CustomerCount { get; set; }
        public List<car> Cars { get; set; }
        public List<Customer> Customers { get; set; }

        public RentCar()
        {
            CarCount = 0;
            Cars = new List<car>();
            Customers = new List<Customer>();
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
                Cars.Add(car);
            }
            else
            {
                Console.WriteLine("50-den artıq maşın elave etmək mümkün deyil.");
            }
        }

        public void RemoveCar(int banID)
        {
        
          car removerCar=Cars.Find(c=> c.BanId == banID);
            if (removerCar != null) { 
            Cars.Remove(removerCar);
                Console.WriteLine("Masin silindi");
            }
            else
            {
                Console.WriteLine("Bu ID ilə maşın mövcud deyil.");
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
                Customers.Add(customer);
            }
            else
            {
                Console.WriteLine("Cannot add more than 100 customers.");
            }
        }
     



        public void RemoveCustomer(int customerID)
        {
            Customer customerToRemove = Customers.Find(c => c.CustomerId == customerID);
            if (customerToRemove != null)
            {
                Customers.Remove(customerToRemove);
                Console.WriteLine("Müşteri silindi.");
            }
            else
            {
                Console.WriteLine("Bu ID ilə müşteri mövcud deyil.");
            }
        }

        public void RentACar(int banID, int customerID)
        {
            car carToRent = Cars.Find(c => c.BanId == banID && !c.IsRented);
            if (carToRent == null)
            {
                Console.WriteLine("Belə maşın mövcud deyil və ya icarəyə verilib.");
                return;
            }

            Customer customer = Customers.Find(c => c.CustomerId == customerID);
            if (customer == null)
            {
                Console.WriteLine("Belə bir müşteri tapılmadı.");
                return;
            }

            if (customer.RentedCars.Count < 3)
            {
                carToRent.IsRented = true;
                customer.RentedCars.Add(carToRent);
                Console.WriteLine("Maşın müşteriyə uğurla icarəyə verildi.");
            }
            else
            {
                Console.WriteLine("Müşteri maksimum maşın limitinə çatıb.");
            }
        }



        public void ReturnCar(int banID, int customerID)
        {
            car carToReturn = Cars.Find(c => c.BanId == banID);
            if (carToReturn == null)
            {
                Console.WriteLine("Belə bir maşın tapılmadı.");
                return;
            }

            Customer customer = Customers.Find(c => c.CustomerId == customerID);
            if (customer == null)
            {
                Console.WriteLine("Belə bir müşteri tapılmadı.");
                return;
            }

            if (customer.RentedCars.Remove(carToReturn))
            {
                carToReturn.IsRented = false;
                Console.WriteLine("Maşın icarədən qaytarıldı.");
            }
            else
            {
                Console.WriteLine("Müşterinin belə bir maşını icarəyə götürmədiyi tapılmadı.");
            }
        }



    }
}
