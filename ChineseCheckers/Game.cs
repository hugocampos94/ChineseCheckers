using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Data.Entity.ModelConfiguration.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    class Game
    {
        public static void Main(string[] args)
        {
            //int i1 = 4;
            //int j1 = 0;
            //int i2 = 12;
            //int j2 = 12;
            //int i0 = 5;
            //int j0 = 1;

            //Console.WriteLine($"Result: {Math.Abs(((j2 - j1) * i0 - (i2 - i1) * j0 + i2 * j1 - j2 * i1) / Math.Sqrt(Math.Pow(j2 - j1, 2) + Math.Pow(i2 - i1, 2)))}");

            //Console.ReadLine();
            //return;

            Board board = null;

            int step = 1;
            Player player = null;
            int numPlayers = 0;
            Coordinate inputCoordinate = null;
            Coordinate highlight1 = null;
            Coordinate highlight2 = null;
            List<Coordinate> list = null;
            int selectedMove = 0;

            while(true)
            {
                switch(step)
                {
                    case 1:
                        highlight1 = null;
                        highlight2 = null;
                        numPlayers = GetNumPlayers();
                        board = new Board(numPlayers);
                        player = board.GetPlayer(1);
                        step = 2;
                        continue;
                    case 2:
                        Console.WriteLine(board.GetBoardStr(highlight1, highlight2));
                        Console.WriteLine($"Player {player} turn...");
                        Console.WriteLine();
                        step = 3;
                        continue;
                    case 3:
                        inputCoordinate = GetInputCoordinates(board, player);
                        Console.WriteLine();
                        step = 4;
                        continue;
                    case 4:
                        list = board.GetAvailableMoves(inputCoordinate);
                        if(list == null || list.Count == 0)
                        {
                            Console.WriteLine("No moves for the piece selected");
                            Console.WriteLine();
                            step = 3;
                        }
                        else
                        {
                            step = 5;
                        }
                        continue;
                    case 5:
                        selectedMove = SelectMove(board, list, inputCoordinate);
                        if (selectedMove < 1)
                        {
                            Console.WriteLine();
                            step = 3;
                        }
                        else
                        {
                            board.PerformMove(inputCoordinate, list.ElementAt(selectedMove - 1));
                            Console.WriteLine();
                            step = 6;
                        }
                        continue;
                    case 6:
                        highlight1 = inputCoordinate;
                        highlight2 = list.ElementAt(selectedMove - 1);
                        if (board.PlayerHasWon(player))
                        {
                            step = 7;
                        }
                        else
                        {
                            var playerList = board.GetPlayerList();
                            int i = player.Id < playerList.Count ? player.Id : 0;
                            while(i != player.Id - 1)
                            {
                                if (playerList[i].Active)
                                {
                                    player = playerList[i];
                                    break;
                                }
                                else
                                {
                                    i = i + 1 < playerList.Count ? i + 1 : 0;
                                }
                            }
                            step = 2;
                        }
                        continue;
                    case 7:
                        Console.WriteLine(board.GetBoardStr(highlight1, highlight2));
                        Console.WriteLine($"Player {player} has won!!!!");
                        Console.WriteLine("Congratulations!!");
                        Thread.Sleep(3000);
                        Console.WriteLine("Press any key to start a new game...");
                        Console.ReadLine();
                        step = 1;
                        continue;
                }
            }
            
        }
        public static int GetNumPlayers()
        {
            while(true)
            {
                Console.WriteLine("Please enter the number of players(2-6):");
                var input = Console.ReadLine();
                if(Regex.IsMatch(input, "^[23456]$"))
                {
                    return int.Parse(input);
                }
                else
                {
                    Console.WriteLine("Invalid input...");
                }
            }
        }

        public static List<Coordinate> GetInputAvailableMoves(Board board, Coordinate inputCoordinate, int player)
        {
            var list = board.GetAvailableMoves(inputCoordinate);
            return list;
        }
        public static Coordinate GetInputCoordinates(Board board, Player player)
        {
            string input;
            while(true)
            {
                Console.WriteLine("Please select the piece you want to move\n"
                + "by entering the coordinates in format i,j (ex. 0,A)...");
                input = Console.ReadLine().ToUpper();

                if (!Regex.IsMatch(input, "^[0-9A-Z][,][0-9A-Z]$"))
                    Console.WriteLine("Invalid piece coordinates...");
                    
                else if (board.GetValueFromChars(input[0],input[2]) != player.Id)
                    Console.WriteLine("Coordinates don't belong to any piece for current player...");
                else
                    return board.GetCoordinateFromChars(input[0],input[2]);
                Console.WriteLine("");
            }
        }

        public static int SelectMove(Board board, List<Coordinate> list, Coordinate inputCoordinate)
        {
            string input;
            while (true)
            {
                Console.WriteLine("List of available moves for Coordinate "
                + $"{{{board.GetCharFromIndex(inputCoordinate.iInt)},{board.GetCharFromIndex(inputCoordinate.jInt)}}} :");
                for (int i = 0; i < list.Count; i++)
                {
                    var curr = list.ElementAt(i);
                    Console.WriteLine($"{i + 1}{{{board.GetCharFromIndex(curr.iInt)},{board.GetCharFromIndex(curr.jInt)}}}");
                }
                Console.WriteLine("Please enter the movement you want to perform");
                input = Console.ReadLine().ToUpper();

                if (!Regex.IsMatch(input, "^[0-9A-Z][,][0-9A-Z]$"))
                    Console.WriteLine("Invalid piece coordinates...");
                else if (input.Equals("P", StringComparison.OrdinalIgnoreCase))
                    return -1;
                Coordinate c = board.GetCoordinateFromChars(input[0], input[2]);
                if (list.Contains(c))
                    return list.IndexOf(c) + 1;

                Console.WriteLine("Invalid movement...");
                Console.WriteLine();
            }
        }
    }
}
