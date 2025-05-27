

using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ExceptionServices;

void main()
{
    Console.WriteLine("Welcome to Tic Tac Toe");
    board board = new board();
    while (board.turn < 10)
    {
        board.createBoard();
        Console.WriteLine("Enter x co-ordinate (betweeen 0 and 2)");
        int x = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter y co-ordinate (between 0 and 2)");
        int y = Convert.ToInt32(Console.ReadLine());
        if (x > 2 || x < 0)
        {
            Console.WriteLine("Invalid x co-ordinate. please try again");
        }
        else if (y > 2 || y < 0)
        {
            Console.WriteLine("Invalid y co-ordinate. please try again");
        }
        else
        {
            board.getCoordinates(x, y);
            if (board.winCondition())
            {
                Console.WriteLine("Game Over! Press any key to exit");
                Console.ReadKey();
                break;
            }
        }
    }


}
main();
class board
{
    public bool winCondition()
    {
        if ((player1turn.Any(t=>t==(0, 0)) && player1turn.Any(t=>t==(0, 1)) && player1turn.Any(t => t == (0, 2))) || (player1turn.Any(t => t == (1, 0)) && player1turn.Any(t => t == (1, 1)) && player1turn.Any(t => t == (1, 2)) || (player1turn.Any(t => t == (2, 0)) && player1turn.Any(t => t == (2, 1)) && player1turn.Any(t => t == (2, 2)) || (player1turn.Any(t => t == (0, 0)) && player1turn.Any(t => t == (1, 1)) && player1turn.Any(t => t == (2, 2)) || player1turn.Any(t => t == (0, 2)) && player1turn.Any(t => t == (1, 1)) && player1turn.Any(t => t == (2, 0))))))
        {
            Console.WriteLine("Player 1 wins!");
            return true;
        }
        else if ((player2turn.Any(t => t == (0, 0)) && player2turn.Any(t => t == (0, 1)) && player2turn.Any(t => t == (0, 2))) || (player2turn.Any(t => t == (1, 0)) && player1turn.Any(t => t == (1, 1)) && player2turn.Any(t => t == (1, 2)) || (player2turn.Any(t => t == (2, 0)) && player2turn.Any(t => t == (2, 1)) && player2turn.Any(t => t == (2, 2)) || (player2turn.Any(t => t == (0, 0)) && player2turn.Any(t => t == (1, 1)) && player2turn.Any(t => t == (2, 2)) || player2turn.Any(t => t == (0, 2)) && player2turn.Any(t => t == (1, 1)) && player2turn.Any(t => t == (2, 0))))))
        {
            Console.WriteLine("Player 2 wins!");
            return true;
        }
        else if (turn == 10)
        {
            Console.WriteLine("It's a draw!");
            return true;
        }
        else
        {
            return false;

        }
    }
    public ValueTuple<int, int>[] boardArray = new ValueTuple<int, int>[] { (0, 2), (1, 2), (2, 2),(0,1), (1, 1), (2, 1), (0, 0), (1, 0), (2, 0) };
    public static int turn { get; set; }
    public static int player { get; set; }
    public static int subOdd;
    public static int subEven;
    public Nullable<ValueTuple<int, int>>[] player1turn { get; set; } = new Nullable<ValueTuple<int, int>>[9];
    public Nullable<ValueTuple<int, int>>[] player2turn { get; set; } = new Nullable<ValueTuple<int, int>>[9];
    public board()
    {
        turn = 1;
        player = 1;
        subOdd = 2;
        subEven = 2;
        for (int i = 0; i < 9; i++)
        {
            player1turn[i] = null;
            player2turn[i] = null;
        }
    }
    public void createBoard()
    {
        Console.WriteLine($"Turn:{turn}");
        Console.WriteLine($"Player {player} turn:");
        bool use = false;
        
                Console.WriteLine(" _  _  _");
            for (int i = 0; i < 9; i++)
            {
            use = false;
                var x = boardArray[i];
            for (int j = 0;j < 9; j++)
            {
                if (boardArray[i] == player1turn[j])
                    if (boardArray[i] == (2, 0) || boardArray[i] == (2, 1) || boardArray[i] == (2, 2))
                    {
                        Console.WriteLine("|X|");
                        use = true;
                    }
                    else
                    {
                        Console.Write("|X|");
                        use = true;

                    }

                else if (boardArray[i] == player2turn[j])
                    if (boardArray[i] == (2, 0) || boardArray[i] == (2, 1) || boardArray[i] == (2, 2))
                    {
                        Console.WriteLine("|O|");
                        use = true;
                    }
                    else
                    {
                        Console.Write("|O|");
                        use = true;

                    }
                else if ((boardArray[i] == (2, 0) || boardArray[i] == (2, 1) || boardArray[i] == (2, 2)) && j==8&&use==false)
                {
                    Console.WriteLine("|_|");
                }
                else if(j==8&&use==false)
                {
                    Console.Write("|_|");

                }
            }
            }


        
    }

    public void getCoordinates(int x, int y)
    {
        bool valid = true;
        while (valid)
        {
           
                (int, int) coordinates = (x, y);
                for (int i = 0; i < 9; i++)
                {
                    if (player1turn[i] == coordinates)
                    {
                        Console.WriteLine("Invalid move. Please try again");
                        return;
                    }
                    else if (player2turn[i] == coordinates)
                    {
                        Console.WriteLine("Invalid move. Please try again");
                        return;
                    }
                }
                if (turn==1)
                {
                    player = 1;
                    player1turn[turn - 1] = coordinates;
                    valid = false;
                    player++;
                    turn++;

                }
            else if (turn % 2 != 0)
            {
                player = 1;
                player1turn[turn - subOdd] = coordinates;
                subOdd += 1;
                valid = false;
                player++;
                turn++;
            }
                else
            {
                player = 2;
                player2turn[turn - subEven] = coordinates;
                subEven ++;
                valid = false;
                player = 1;
                turn++;
            }

            



        }
    }
}
