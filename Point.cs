void main()
{
    point p1 = new point(2, 3);
    point p2 = new point(-4, 0);
    Tuple<double, double> point1 = p1.createPoint();
    Tuple<double, double> point2 = p2.createPoint();
    Console.WriteLine($"Point 1: {point1}");
    Console.WriteLine($"Point 2: {point2}");

}
main();
class point
{
    public double x{get; set;}
    public double y { get; set; }
    public point(double x, double y)
    {
        this.x = x;
        this.y = y;
    }
    public point()
    {
        this.x = 0;
        this.y = 0;
 
    }
    public Tuple<double,double> createPoint()
    {
        return Tuple.Create(x,y);

    }
}
