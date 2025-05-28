using System.Security.Cryptography;
using System.Xml.Linq;

void main()
{
    pack backpack = new pack(10, 10, 10);
    Nullable<int> choice1 = null;
    int choice2;
    bool validInput = false;
    while (true)
    {
        while (!validInput)
        {
            Console.WriteLine("Choose an option:\n1: Add item\n2: Check current values\n3: Exit");
            choice1 = Convert.ToInt32(Console.ReadLine());
            if (choice1 < 1 && choice1 > 3)
            {
                continue;
            }
            else
            {
                validInput = true;
            }
        }
        if (choice1 == 1)
        {
            Console.WriteLine(backpack.ToString());
            Console.WriteLine("Enter item to add:\n1: Arrow\n2:Bow\n3:Sword\n4:Rope\n5:Water");
            choice2 = Convert.ToInt32(Console.ReadLine());
            switch (choice2)
            {
                case 1:
                    Arrow arrow = new Arrow();
                    if (backpack.Add(arrow))
                    {
                        Console.WriteLine("Arrow added successfully.");
                        validInput = false; 
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Arrow. Backpack is full or item exceeds limits.");
                        validInput = false;
                    }
                    break;
                case 2:
                    Bow bow = new Bow();
                    if (backpack.Add(bow))
                    {
                        Console.WriteLine("Bow added successfully.");
                        validInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Bow. Backpack is full or item exceeds limits.");
                        validInput = false;
                    }
                    break;
                case 3:
                    Sword sword = new Sword();
                    if (backpack.Add(sword))
                    {
                        Console.WriteLine("Sword added successfully.");
                        validInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Sword. Backpack is full or item exceeds limits.");
                        validInput = false;
                    }
                    break;
                case 4:
                    Rope rope = new Rope();
                    if (backpack.Add(rope))
                    {
                        Console.WriteLine("Rope added successfully.");
                        validInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Rope. Backpack is full or item exceeds limits.");
                        validInput = false;
                    }
                    break;
                case 5:
                    Water water = new Water();
                    if (backpack.Add(water))
                    {
                        Console.WriteLine("Water added successfully.");
                        validInput = false;
                    }
                    else
                    {
                        Console.WriteLine("Failed to add Water. Backpack is full or item exceeds limits.");
                        validInput = false;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }

            Console.WriteLine($"Current Weight: {backpack.currentWeight}");
            Console.WriteLine($"Current Volume: {backpack.currentVolume}");

        }
        else if (choice1 == 2)
        {
            backpack.CheckCurrentValues();
            validInput = false; 
        }
        else if (choice1 == 3)
        {
            Console.WriteLine("Exiting...");
            break;
        }
    }
}
main();
class InventoryItem
{
    public string Name { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public InventoryItem(string name, double weight, double volume)
    {
        Name = name;
        Weight = weight;
        Volume = volume;
    }
}
class Arrow : InventoryItem
{
    private static string name = "Arrow";
    private static double weight = 0.1;
    private static double volume = 0.05;
    public Arrow() : base(name, weight, volume) { }
    public override string ToString()
    {
        return name;
    }
}
class Bow : InventoryItem
{
    private static string name = "Bow";
    private static double weight = 1;
    private static double volume = 4;
    public Bow() : base(name, weight, volume) { }
    public override string ToString()
    {
        return name;
    }
}
class Sword : InventoryItem
{
    private static string name = "Sword";
    private static double weight = 5;
    private static double volume = 3;
    public Sword() : base(name, weight, volume) { }
    public override string ToString()
    {
        return name;
    }
}
class Rope : InventoryItem
{
    private static string name = "Rope";
    private static double weight = 1;
    private static double volume = 1.5;
    public Rope() : base(name, weight, volume) { }
    public override string ToString()
    {
        return name;
    }
}
class Water : InventoryItem
{
    private static string name = "Water";
    private static double weight = 2;
    private static double volume = 3;
    public Water() : base(name, weight, volume) { }
    public override string ToString()
    {
        return name;
    }
}

class pack {
    public static InventoryItem[] items { get; set; }
    public static double maxWeight { get; set; }
    public static double maxVolume { get; set; }
    public double currentWeight { get; set; } = 0;
    public double currentVolume { get; set; } = 0;
    public int currentItemCount { get; set; } = 0;
    public pack(int numberOfItems, double weight, double volume)
    {
        items = new InventoryItem[numberOfItems];
        maxWeight = weight;
        maxVolume = volume;
    }
    public bool Add(InventoryItem item)
    {
        if ((currentWeight + item.Weight > maxWeight) || (currentVolume + item.Volume > maxVolume)||((currentItemCount+1)>items.Length))
        {
            return false; 
        }
        else
        {
            
                
                    items[currentItemCount] = item;
                    currentWeight += item.Weight;
                    currentVolume += item.Volume;
                    currentItemCount++;
                    return true;
                
            
            
        }   
    }
    public void CheckCurrentValues()
    {
        Console.WriteLine($"Current Weight: {currentWeight}/{maxWeight}");
        Console.WriteLine($"Current Volume: {currentVolume}/{maxVolume}");
        Console.WriteLine($"Current Item Count: {currentItemCount}/{items.Length}");
    }
    public override string ToString()
    {
        string curr = "Current Items in Backpack :";
        for (int i = 0; i < currentItemCount; i++)
        {
           curr+=(items[i].ToString() + ", ");
        }
        return curr;
    }


}


