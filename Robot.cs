void main()
{
    string command1;
    string command2;
    string command3;
    Console.WriteLine("Enter 3 commands");
    command1 = Console.ReadLine().ToLower();
    command2 = Console.ReadLine().ToLower();
    command3 = Console.ReadLine().ToLower();
    Robot robot = new Robot();
    if (command1 == "on")
    {
        robot.Commands[0] = new OnCommand();
    }
    else if (command1 == "off")
    {
        robot.Commands[0] = new OffCommand();
    }
    else if (command1 == "north")
    {
        robot.Commands[0] = new NorthCommand();
    }
    else if (command1 == "south")
    {
        robot.Commands[0] = new SouthCommand();
    }
    else if (command1 == "east")
    {
        robot.Commands[0] = new EastCommand();
    }
    else if (command1 == "west")
    {
        robot.Commands[0] = new WestCommand();

    }
    if (command2 == "on")
    {
        robot.Commands[1] = new OnCommand();
    }
    else if (command2 == "off")
    {
        robot.Commands[1] = new OffCommand();
    }
    else if (command2 == "north")
    {
        robot.Commands[1] = new NorthCommand();
    }
    else if (command2 == "south")
    {
        robot.Commands[1] = new SouthCommand();
    }
    else if (command2 == "east")
    {
        robot.Commands[1] = new EastCommand();
    }
    else if (command2 == "west")
    {
        robot.Commands[1] = new WestCommand();
    }
    if (command3 == "on")
    {
        robot.Commands[2] = new OnCommand();
    }
    else if (command3 == "off")
    {
        robot.Commands[2] = new OffCommand();
    }
    else if (command3 == "north")
    {
        robot.Commands[2] = new NorthCommand();
    }
    else if (command3 == "south")
    {
        robot.Commands[2] = new SouthCommand();
    }
    else if (command3 == "east")
    {
        robot.Commands[2] = new EastCommand();
    }
    else if (command3 == "west")
    {
        robot.Commands[2] = new WestCommand();
    }
    robot.Run();
}
main();
public abstract class RobotCommand
{
    public abstract void Run(Robot robot);
}
public class OnCommand :RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = true;
    }

}
public class OffCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class  NorthCommand :RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y++;
        }
    }
}
public class SouthCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.Y--;
        }
    }
}
public class EastCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X++;
        }
    }
}
public class WestCommand : RobotCommand
{
    public override void Run(Robot robot)
    {
        if (robot.IsPowered)
        {
            robot.X--;
        }
    }
}
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    public  RobotCommand?[] Commands { get; } = new RobotCommand?[3];
    public void Run()
    {
        foreach (RobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}