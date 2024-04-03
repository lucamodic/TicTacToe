using System;

class Program
{
    static void Main()
    {
        Player player1 = new Player(PlayerType.X);
        Player player2 = new Player(PlayerType.O);
        Game game = new Game(player1, player2);

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Current board:");
            PrintBoard(game);

            Console.WriteLine($"Player {game.CurrentPlayer}'s turn.");
            int row, col = -1;
            bool validInput = false;
            do
            {
                Console.Write("Enter row (0-2): ");
                string rowInput = Console.ReadLine();
                Console.Write("Enter column (0-2): ");
                string colInput = Console.ReadLine();

                if (!int.TryParse(rowInput, out row) || !int.TryParse(colInput, out col) || row < 0 || row > 2 || col < 0 || col > 2)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 0 and 2.");
                }
                else if (game.Board.GetCell(row, col) != PlayerType.None)
                {
                    Console.WriteLine("Cell is already taken. Please choose another cell.");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);

            try
            {
                game.MakeMove(row, col);

                if (game.Board.HasWinner())
                {
                    Console.Clear();
                    Console.WriteLine("Current board:");
                    PrintBoard(game);
                    Console.WriteLine($"Player {game.CurrentPlayer} wins!");
                    break;
                }

                if (game.Board.IsFull())
                {
                    Console.Clear();
                    Console.WriteLine("Current board:");
                    PrintBoard(game);
                    Console.WriteLine("It's a tie!");
                    break;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }

        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    static void PrintBoard(Game game)
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(game.Board.GetCell(i, j) + " ");
            }
            Console.WriteLine();
        }
    }
}
