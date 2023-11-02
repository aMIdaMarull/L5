namespace Lab5
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Equipment Rental System");

            // Select equipment type
            Console.WriteLine("Select Equipment Type:");
            Console.WriteLine("1. Excavator");
            Console.WriteLine("2. Bulldozer");
            Console.WriteLine("3. Crane");

            if (int.TryParse(Console.ReadLine(), out int equipmentChoice) && Enum.IsDefined(typeof(EquipmentType), equipmentChoice - 1))
            {
                EquipmentType selectedEquipmentType = (EquipmentType)(equipmentChoice - 1);
                Console.Clear();
                // Select rental type
                Console.WriteLine("Select Rental Type:");
                Console.WriteLine("1. Standard");
                Console.WriteLine("2. Preferential");
                Console.WriteLine("3. Penal");

                if (int.TryParse(Console.ReadLine(), out int rentalTypeChoice) && Enum.IsDefined(typeof(RentalType), rentalTypeChoice - 1))
                {
                    RentalType selectedRentalType = (RentalType)(rentalTypeChoice - 1);
                    Console.Clear();

                    Console.Write("Enter the number of rental days: ");
                    if (int.TryParse(Console.ReadLine(), out int rentalDays) && rentalDays > 0)
                    {
                        ICalculateCostStrategy strategy;

                        switch (selectedRentalType)
                        {
                            case RentalType.Standard:
                                strategy = new StandardCostStrategy();
                                break;
                            case RentalType.Preferential:
                                strategy = new PreferentialCostStrategy();
                                break;
                            case RentalType.Penal:
                                strategy = new PenalCostStrategy();
                                break;
                            default:
                                throw new ArgumentException("Invalid rental type.");
                        }
                        Console.Clear();
                        var equipmentRental = new EquipmentRental(strategy, selectedEquipmentType, rentalDays);
                        Console.WriteLine($"{selectedEquipmentType} - {selectedRentalType} Rental Cost ({rentalDays} days): $" + equipmentRental.CalculateTotalCost());

                    }
                    else
                    {
                        Console.WriteLine("Invalid rental days count. Please enter a positive integer.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid rental type choice.");
                }
            }
            else
            {
                Console.WriteLine("Invalid equipment type choice.");
            }


        }
    }
}