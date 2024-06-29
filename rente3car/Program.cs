using rente3car;

internal class Program
{
    static void Main(string[] args)
    {
        RentCar rentCar = new RentCar();
        Console.WriteLine("Welcome");

        while (true)
        {
            Console.WriteLine("1. Add car");
            Console.WriteLine("2. Remove car");
            Console.WriteLine("3. Add customer");
            Console.WriteLine("4. Remove customer");
            Console.WriteLine("5. Rent car");
            Console.WriteLine("6. Return car");
            Console.WriteLine("0. Exit");

            int option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter car ID:");
                    int banid = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car name:");
                    string carName = Console.ReadLine();
                    car car = new car { BanId = banid, CarName = carName };
                    rentCar.AddCar(car,banid);
                    break;

                case 2:
                    Console.WriteLine("Enter car ID to remove:");
                    int removeCarId = Convert.ToInt32(Console.ReadLine());
                    rentCar.RemoveCar(removeCarId);
                    break;

                case 3:
                    Console.WriteLine("Enter customer ID:");
                    int customerId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter customer name:");
                    string customerName = Console.ReadLine();
                    Customer customer = new Customer { CustomerId = customerId, Name = customerName };
                    rentCar.AddCustomer(customer,customerId);
                    break;

                case 4:
                    Console.WriteLine("Enter customer ID to remove:");
                    int removeCustomerId = Convert.ToInt32(Console.ReadLine());
                    rentCar.RemoveCustomer(removeCustomerId);
                    break;

                case 5:
                    Console.WriteLine("Enter car ID to rent:");
                    int rentCarId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter customer ID:");
                    int rentCustomerId = Convert.ToInt32(Console.ReadLine());
                
                    rentCar.RentACar(rentCarId,rentCustomerId);
                    break;

                case 6:
                    Console.WriteLine("Enter customer ID:");
                    int returnCustomerId = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter car ID to return:");
                    int returnCarId = Convert.ToInt32(Console.ReadLine());
                    rentCar.ReturnCar(returnCarId,returnCustomerId);
                    break;

                case 0:
                    return;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
