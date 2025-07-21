using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;


void main()
{
       board gameBoard = new board();
    gameBoard.runGame();
}
main();
class fountain
{
    public static ValueTuple<int, int> FountainCoordinates = (0, 2);
    public bool enabled { get; set; }
    public fountain()
    {
        enabled= false;
    }
    public void setEnabled(bool state)
    {
        enabled = state;
    }
    public bool isEnabled()
    {
        return enabled;
    }
}
class board {
    public ValueTuple<int, int>[] Board = new ValueTuple<int, int>[] { (0, 3), (1, 3), (2, 3), (3, 3), (0, 2), (1, 2), (2, 2), (3, 2), (0, 1), (1, 1), (2, 1), (3, 1), (0, 0), (1, 0), (2, 0), (3, 0) };
    public Nullable<ValueTuple<int?, int?>> PlayerCoordinates { get; set; }
    public Nullable<ValueTuple<int?, int?>> MaelstromCoordinates { get; set; }
    private static ValueTuple<int, int> cavernEntrance = (0, 0);
    public static ValueTuple<int, int> pit = (2,2);
    public ValueTuple<int, int>[] detectDraft = new ValueTuple<int, int>[] {(2,1), (1,2), (2,3), (3,2),(3,3),(1,1),(3,1),(1,3)};
    private static fountain Fountain = new fountain();
    public board()
    {
        PlayerCoordinates = (0, 0);
        MaelstromCoordinates = (1, 3);
    }
    private void movePlayer()
    {
        
        bool validMove = false;
        while (!validMove)
        {
            Console.WriteLine("What do you want to do? ");
            string? input = Console.ReadLine();
            input = input?.ToLower();
            if (input == null)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            else if (input =="move north")
            {
                if (PlayerCoordinates?.Item2<1)
                {
                    Console.WriteLine("Cannot move north from this position.");
                }
                else
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? y= temp?.Item2 - 1;
                    Nullable<ValueTuple<int?, int?>> temp2 = (PlayerCoordinates?.Item1, y);
                    PlayerCoordinates = temp2;
                    validMove = true;
                }
            }
            else if (input == "move south")
            {
                if (PlayerCoordinates?.Item2 > 2)
                {
                    Console.WriteLine("Cannot move south from this position.");
                }
                else
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? y = temp?.Item2 + 1;
                    Nullable<ValueTuple<int?, int?>> temp2 = (PlayerCoordinates?.Item1, y);
                    PlayerCoordinates = temp2;
                    validMove = true;
                }
            }
            else if (input == "move east")
            {
                if (PlayerCoordinates?.Item1 > 2)
                {
                    Console.WriteLine("Cannot move east from this position.");
                }
                else
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? x = temp?.Item1 + 1;
                    Nullable<ValueTuple<int?, int?>> temp2 = (x, PlayerCoordinates?.Item2);
                    PlayerCoordinates = temp2;
                    validMove = true;
                }
            }
            else if (input == "move west")
            {
                if (PlayerCoordinates?.Item1 < 1)
                {
                    Console.WriteLine("Cannot move west from this position.");
                }
                else
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? x = temp?.Item1 - 1;
                    Nullable<ValueTuple<int?, int?>> temp2 = (x, PlayerCoordinates?.Item2);
                    PlayerCoordinates = temp2;
                    validMove = true;
                }
            }else if (input == "enable fountain")
            {
                if (PlayerCoordinates == fountain.FountainCoordinates && Fountain.isEnabled()==false)
                {
                    Fountain.setEnabled(true);
                    Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                    validMove = true;
                }
                else if (PlayerCoordinates == fountain.FountainCoordinates && Fountain.isEnabled() == true)
                {
                    Console.WriteLine("The Fountain of Objects is already active.");
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("You must be in the same room as the fountain to activate it.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
            if (PlayerCoordinates == MaelstromCoordinates)
            {
                Console.WriteLine("You have been sucked into the maelstrom!");
                if (PlayerCoordinates?.Item2 >= 0 && PlayerCoordinates?.Item1 <=1)
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? y = temp?.Item2 - 1;
                    int? x = temp?.Item1 + 2;
                    Nullable<ValueTuple<int?, int?>> temp2 = (x, y);
                    PlayerCoordinates = temp2;
                }
                else if (PlayerCoordinates?.Item2 == 0)
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? x = temp?.Item1 + 2;
                    int? y = 0;
                    Nullable<ValueTuple<int?, int?>> temp2 = (x, y);
                    PlayerCoordinates = temp2;

                }
                else if (PlayerCoordinates?.Item1 > 1)
                {
                    Nullable<ValueTuple<int?, int?>> temp = PlayerCoordinates;
                    int? x = 3;
                    int? y = temp?.Item2 - 1;
                    Nullable<ValueTuple<int?, int?>> temp2 = (x, y);
                    PlayerCoordinates = temp2;
                }
                if (MaelstromCoordinates?.Item1 > 2 && MaelstromCoordinates?.Item2< 2)
                {
                    MaelstromCoordinates = (MaelstromCoordinates?.Item1 - 2, MaelstromCoordinates?.Item2 + 1);
                }
                else if (MaelstromCoordinates?.Item1 < 2 && MaelstromCoordinates?.Item2 > 2)
                {
                    MaelstromCoordinates = (0, 3);
                }
                else if (MaelstromCoordinates?.Item1 < 2)
                {
                    MaelstromCoordinates = (0, MaelstromCoordinates?.Item2 + 1);
                }
                else if (MaelstromCoordinates?.Item2 > 2)
                {
                    MaelstromCoordinates = (MaelstromCoordinates?.Item1 - 2, 3);
                }
            }
            
        }
    }
    public void runGame()
    {
        bool run = true;
        while (run)
        {
            Console.WriteLine("----------------------------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={PlayerCoordinates?.Item1}, Column={PlayerCoordinates?.Item2}).");
            if (PlayerCoordinates == cavernEntrance && Fountain.isEnabled() == true)
            {
                Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou win!");
                break;

            }
            else if (PlayerCoordinates == cavernEntrance)
            {
                Console.WriteLine("You see light coming from the cavern entrance.");
            }
            else if (PlayerCoordinates == fountain.FountainCoordinates)
            {
                Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
            }
            else if (PlayerCoordinates == pit)
            {
                Console.WriteLine("You have fallen into a pit and died. Game over.");
                break;
            }
            else{ 
                for (int i = 0; i < detectDraft.Length; i++)
                    if (detectDraft[i]==PlayerCoordinates)
                {
                    Console.WriteLine("You feel a draft. There is a pit in a nearby room");
                }
            }
            if ((MaelstromCoordinates?.Item1 + 1, MaelstromCoordinates?.Item2) == PlayerCoordinates||(MaelstromCoordinates?.Item1-1,MaelstromCoordinates?.Item2) == PlayerCoordinates || (MaelstromCoordinates?.Item1 - 1, MaelstromCoordinates?.Item2-1) == PlayerCoordinates || (MaelstromCoordinates?.Item1, MaelstromCoordinates?.Item2 - 1) == PlayerCoordinates || (MaelstromCoordinates?.Item1 + 1, MaelstromCoordinates?.Item2 - 1) == PlayerCoordinates || (MaelstromCoordinates?.Item1 - 1, MaelstromCoordinates?.Item2 + 1) == PlayerCoordinates || (MaelstromCoordinates?.Item1 , MaelstromCoordinates?.Item2 + 1) == PlayerCoordinates || (MaelstromCoordinates?.Item1 + 1, MaelstromCoordinates?.Item2 + 1) == PlayerCoordinates)
            {
                Console.WriteLine("You hear the growling and groaning of a maelstrom nearby");
            }

            movePlayer();

        }
    

}
}