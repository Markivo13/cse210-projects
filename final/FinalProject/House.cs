// Class representing the family's house
public class House
{
    private List<Area> areas;

    public House()
    {
        areas = new List<Area>()
        {
            new LivingRoom(),
            new Kitchen(),
            new MastersBedroom(),
            new Bedroom1(),
            new Bedroom2(),
            new Bedroom3(),
            new Bathroom1(),
            new Bathroom2(),
            new HomeOffice(),
            new Garage(),
            new Storage(),
            new Pantry()
        };
    }

    public void StoreItem()
    {
        Console.WriteLine("Enter the item to store:");
        string item = Console.ReadLine();

        Console.WriteLine("Enter the number corresponding to the area to store the item:");
        DisplayAreaOptions();

        int areaNumber = int.Parse(Console.ReadLine());

        if (areaNumber >= 1 && areaNumber <= areas.Count)
        {
            Area selectedArea = areas[areaNumber - 1];
            selectedArea.AddItem(item);
        }
        else
        {
            Console.WriteLine("Invalid area number.");
        }
    }

    public void DisplayItems()
    {
        foreach (Area area in areas)
        {
            area.DisplayItems();
            Console.WriteLine();
        }
    }

    public void SearchItem()
    {
        Console.WriteLine("Enter the item to search:");
        string item = Console.ReadLine();

        bool found = false;

        foreach (Area area in areas)
        {
            if (area.SearchItem(item))
            {
                Console.WriteLine($"The item '{item}' is found in {area.Name}.");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine($"The item '{item}' is not found in any area.");
        }
    }

    public void RetrieveItem()
    {
        Console.WriteLine("Enter the item to retrieve:");
        string item = Console.ReadLine();

        bool retrieved = false;

        foreach (Area area in areas)
        {
            if (area.RetrieveItem(item))
            {
                retrieved = true;
            }
        }

        if (!retrieved)
        {
            Console.WriteLine($"The item '{item}' is not found in any area.");
        }
    }

    private void DisplayAreaOptions()
    {
        Console.WriteLine("Available areas:");
        for (int i = 0; i < areas.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {areas[i].Name}");
        }
    }
}
