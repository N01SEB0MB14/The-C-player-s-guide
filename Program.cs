void main()
{
    Console.WriteLine("Enter arrow choice. Type 1 for Beginner, Type 2 for Elite, Type 3 for Marksman and type 4 for Custom: ");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        arrow a = arrow.CreateBeginnerArrow();
        float cost = a.GetCost(a.arrowhead, a.fletchling, a.length);
        Console.WriteLine("The cost of the arrow is: " + cost);
    }
    else if (choice == 2)
    {
        arrow a = arrow.CreateEliteArrow();
        float cost = a.GetCost(a.arrowhead, a.fletchling, a.length);
        Console.WriteLine("The cost of the arrow is: " + cost);
    }
    else if (choice == 3)
    {
        arrow a = arrow.CreateMarksmanArrow();
        float cost = a.GetCost(a.arrowhead, a.fletchling, a.length);
        Console.WriteLine("The cost of the arrow is: " + cost);
    }
    else if (choice == 4)
    {

        arrow a = new arrow();
        bool check = false;
        while (check == false)
        {
            Console.WriteLine("Enter arrowhead type:");
            string type = Console.ReadLine();
            type.ToLower();
            if (type == "steel")
            {
                a.arrowhead = Arrowhead.steel;
                check = true;
            }
            else if (type == "wood")
            {
                a.arrowhead = Arrowhead.wood;
                check = true;
            }
            else if (type == "obsidian")
            {
                a.arrowhead = Arrowhead.obsidian;
                check = true;
            }
            else
            {
                Console.WriteLine("Invalid arrowhead type.");
            }
        }
        check = false;
        while (!check)
        {
            Console.WriteLine("Enter fletchling type:");
            string type = Console.ReadLine();
            type.ToLower();
            if (type == "plastic")
            {
                a.fletchling = Fletchling.plastic;
                check = true;
            }
            else if (type == "turkey" || type == "turkey feathers")
            {
                a.fletchling = Fletchling.turkey;
                check = true;
            }
            else if (type == "goose" || type == "goose feathers")
            {
                a.fletchling = Fletchling.goose;
                check = true;
            }
            else
            {
                Console.WriteLine("Invalid fletchling type.");
            }
        }
        check = false;
        while (!check)
        {
            Console.WriteLine("Enter Arrow length:");
            float len = (float)(Convert.ToInt32(Console.ReadLine()));
            if (len < 0 || len > 100)
            {
                Console.WriteLine("Invalid length.");
            }
            else
            {
                a.length = len;
                check = true;
            }
        }
        float cost = a.GetCost(a.arrowhead, a.fletchling, a.length);
        Console.WriteLine("The cost of the arrow is: " + cost);
    }
    else
    {
        Console.WriteLine("Invalid choice.");
    }
}
main();




enum Arrowhead
{
    steel,
    wood,
    obsidian,
}
enum Fletchling
{
    plastic,
    turkey,
    goose,
}
class arrow
{
    public Arrowhead arrowhead { get; set; }
    public Fletchling fletchling { get; set; }
    public float length { get; set; }
    public static arrow CreateEliteArrow()
    {
        return new arrow()
        {
            arrowhead = Arrowhead.steel,
            fletchling = Fletchling.plastic,
            length = 95,
        };
    }
    public static arrow CreateBeginnerArrow()
    {
        return new arrow()
        {
            arrowhead = Arrowhead.wood,
            fletchling = Fletchling.goose,
            length = 75,
        };
    }
    public static arrow CreateMarksmanArrow()
    {
        return new arrow()
        {
            arrowhead = Arrowhead.steel,
            fletchling = Fletchling.goose,
            length = 85,
        };
    }
    public float GetCost(Arrowhead arr, Fletchling fl, float len) {
        float cost;
        if (arr == Arrowhead.steel)
        {
            cost = 10;
        }
        else if (arr == Arrowhead.wood)
        {
            cost = 3;
        }
        else
        {
            cost = 5;
        }
        if ( fl==Fletchling.plastic)
        {
            cost += 10;
        }
        else if (fl == Fletchling.turkey)
        {
            cost += 5;
        }
        else
        {
            cost += 3;

        }
        cost += (float)(len * 0.05);
        return cost;
    }
}





