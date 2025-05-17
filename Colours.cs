

void main()
{
    Console.WriteLine("Enter color choice. Type 1 for red, 2 for green, 3 for blue, 4 for orange, 5 for yellow, 6 for purple, 7 for white, 8 for black and 9 for custom:");
    int choice = Convert.ToInt32(Console.ReadLine());
    Colors colour = new Colors();
    (Nullable<double>, Nullable<double>, Nullable<double>) colours;

    switch (choice)
    {
        case 1:

            colours = Colors.Red();
            break;
        case 2:

             colours = Colors.Green();
            break;
        case 3:

            colours = Colors.Blue();
            break;
        case 4:

             colours = Colors.Orange();
            break;
        case 5:

            colours = Colors.Yellow();
            break;
        case 6:

            colours = Colors.Purple();
            break;
        case 7:

            colours = Colors.White();
            break;
        case 8:

            colours = Colors.Black();
            break;
        case 9:
            Console.WriteLine("Enter red value:");
            double red = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter green value:");
            double green = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter blue value:");
            double blue = Convert.ToDouble(Console.ReadLine());
            colours = ( red, green, blue );
            break;
        default:
            Console.WriteLine("Invalid choice");
            colours = (null,null,null);
            Environment.Exit(0);
            break;


    }
    Console.WriteLine($"R,G,B values={colours}");
}
main();


class Colors
{
    public double _red { get; set; }
    public double _green { get; set; }
    public double _blue { get; set; }
    public Colors(double red, double green, double blue)
    {
        this._red = red;
        this._green = green;
        this._blue = blue;

    }
    public Colors()
    {
    }
        public static (double, double, double) White() => (255, 255, 255);
        public static (double, double, double) Red() => (255, 0, 0);
        public static (double, double, double) Green() => (0, 128, 0);
        public static (double, double, double) Blue() => (0, 0, 255);
        public static (double, double, double) Orange() => (255, 165, 0);
        public static (double, double, double) Yellow() => (255, 255, 0);
        public static (double, double, double) Purple() => (128, 255, 128);
        public static (double, double, double) Black() => (0, 0, 0);
    }

    

