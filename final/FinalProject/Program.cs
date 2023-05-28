// Main program
public class Program
{
    public static void Main()
    {
        House house = new House();

        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Store item");
            Console.WriteLine("2. Display items");
            Console.WriteLine("3. Search item");
            Console.WriteLine("4. Retrieve item");
            Console.WriteLine("5. Exit");

            Console.WriteLine("Enter your choice:");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    house.StoreItem();
                    break;
                case 2:
                    house.DisplayItems();
                    break;
                case 3:
                    house.SearchItem();
                    break;
                case 4:
                    house.RetrieveItem();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine();
        }
    }
}