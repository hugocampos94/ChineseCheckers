using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class Board
    {
        public const int EMPTY_VALUE = 0;
        public const int VOID_VALUE = -1;
        public int Empty
        {
            get { return EMPTY_VALUE; }
        }
        public int Void
        {
            get { return VOID_VALUE; }
        }
        private readonly int[][] board;
        private static readonly List<Player> players = new List<Player>()
        {
            new Player(1, PlayerPositions.TOP_PIECES, PlayerPositions.BOTTOM_PIECES),
            new Player(2, PlayerPositions.TOP_LEFT_PIECES, PlayerPositions.BOTTOM_RIGHT_PIECES),
            new Player(3, PlayerPositions.BOTTOM_LEFT_PIECES, PlayerPositions.TOP_RIGHT_PIECES),
            new Player(4, PlayerPositions.BOTTOM_PIECES, PlayerPositions.TOP_PIECES),
            new Player(5, PlayerPositions.BOTTOM_RIGHT_PIECES, PlayerPositions.TOP_LEFT_PIECES),
            new Player(6, PlayerPositions.TOP_RIGHT_PIECES, PlayerPositions.BOTTOM_LEFT_PIECES)
        };

        public Board()
        {
            board = new int[][]
            {
                new int[] {-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
                new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
                new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                new int[] {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
                new int[] {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
                new int[] {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
                new int[] {0,0,0,0,0,0,0,0,0,0,0,0,-1},
                new int[] {0,0,0,0,0,0,0,0,0,0,0,0,0},
                new int[] {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
                new int[] {-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1}
            };
        }

        public Board(int numPlayers) : this()
        {
            switch (numPlayers)
            {
                case 2:
                    players[0].Number = 1;
                    players[3].Number = 2;
                    SetupPlayer(players[0], 1);
                    SetupPlayer(players[3], 2);
                    break;
                case 3:
                    SetupPlayer(players[0], 1);
                    SetupPlayer(players[2], 2);
                    SetupPlayer(players[4], 3);
                    break;
                case 4:
                    SetupPlayer(players[5], 1);
                    SetupPlayer(players[1], 2);
                    SetupPlayer(players[2], 3);
                    SetupPlayer(players[4], 4);
                    break;
                case 5:
                    SetupPlayer(players[0], 1);
                    SetupPlayer(players[1], 2);
                    SetupPlayer(players[2], 3);
                    SetupPlayer(players[3], 4);
                    SetupPlayer(players[4], 5);
                    break;
                case 6:
                    SetupPlayer(players[0], 1);
                    SetupPlayer(players[1], 2);
                    SetupPlayer(players[2], 3);
                    SetupPlayer(players[3], 4);
                    SetupPlayer(players[4], 5);
                    SetupPlayer(players[5], 6);
                    break;
            }
        }

        private void SetupPlayer(Player player, int playerNum)
        {
            player.Number = playerNum;
            player.Active = true;
            SetBoardCoordinates(player.StartCoordinates, playerNum);
        }

        public Player GetPlayer(int player)
        {
            return players[player - 1];
        }
        public List<Player> GetPlayerList()
        {
            return players;
        }

        public void SetBoardCoordinates(List<Coordinate> coordinates, int value)
        {
            foreach (var coordi in coordinates)
            {
                board[(int)Math.Round(coordi.i)][(int)Math.Round(coordi.j)] = value;
            }
        }

        public string GetBoardStr(Coordinate highlight1, Coordinate highlight2)
        {
            StringBuilder sb = new StringBuilder();
            bool shouldHighlight = highlight1 != null && highlight2 != null;
            for (int i = 0; i < board.Count(); i++)
            {
                if (i % 2 != 0)
                {
                    sb.Append("    ");
                }
                for (int j = 0; j < board[0].Count(); j++)
                {
                    if (board[i][j] != VOID_VALUE)
                        if (shouldHighlight && (
                            (i == highlight1.i && j == highlight1.j)
                            || (i == highlight2.i && j == highlight2.j)))
                            sb.Append($"*{(char)(board[i][j] == 0 ? ' ' : ('0' + board[i][j]))}{GetCharFromIndex(i)}{GetCharFromIndex(j)}");
                        else
                            sb.Append($" {(char)(board[i][j] == 0 ? ' ' : ('0' + board[i][j]))}{GetCharFromIndex(i)}{GetCharFromIndex(j)}");
                    //sb.Append($"{board[i][j]}{i},{j}");
                    else
                        sb.Append("    ");
                    if (j < board[0].Count() - 1)
                        sb.Append("    ");
                }
                if (i < board.Count() - 1)
                    sb.AppendLine();
            }
            return sb.ToString();
        }

        public Coordinate GetCoordinateFromChars(char a, char b)
        {
            int i = GetIndexFromChar(a);
            int j = GetIndexFromChar(b);
            return GetCoordinateFromIndex(i, j);
        }

        public Coordinate GetCoordinateFromIndex(int i, int j)
        {
            ValidateCoordinate(i, j);
            return new Coordinate(i, j);
        }

        public int GetValueFromChars(char a, char b)
        {
            int i = GetIndexFromChar(a);
            int j = GetIndexFromChar(b);
            return GetValueFromIndex(i, j);
        }

        public int GetValueFromIndex(int i, int j)
        {
            ValidateCoordinate(i, j);
            return board[i][j];
        }

        public bool IsOccupied(int i, int j)
        {
            int v = GetValueFromIndex(i, j);
            if (v != Empty && v != Void)
                return true;
            else
                return false;
        }

        public char GetCharFromIndex(int i)
        {
            if (i >= 0 && i <= 9)
                return (char)(i + '0');
            else if (i >= 10 && i <= 35)
                return (char)(i - 10 + 'A');
            else
                throw new ArgumentOutOfRangeException("i", i, $"Invalid value for argument i: {i}");
        }
        public int GetIndexFromChar(char c)
        {
            if (c >= '0' && c <= '9')
                return c - '0';
            else if (c >= 'A' && c <= 'Z')
                return c - 'A' + 10;
            else
                throw new ArgumentOutOfRangeException("c", c, $"Invalid value for argument c: {c}");
        }

        public bool IsPlayer(int i, int j, Player player)
        {
            ValidateCoordinate(i, j);
            bool result = false;
            if (board[i][j] == player.Id) result = true;
            return result;
        }

        public List<Coordinate> GetAvailableMoves(Coordinate c)
        {
            ValidateCoordinate(c.iInt, c.jInt);
            var list = new List<Coordinate>();
            Coordinate tmp = null;
            if ((tmp = Movement.GetLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetRightMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetUpLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetUpRightMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetDownLeftMove(this, c)) != null) list.Add(tmp);
            if ((tmp = Movement.GetDownRightMove(this, c)) != null) list.Add(tmp);
            GetAvailableJumpMoves(c, list);
            return list;
        }

        public void GetAvailableJumpMoves(Coordinate c, List<Coordinate> list)
        {
            ValidateCoordinate(c.iInt, c.jInt);
            Coordinate tmp = null;
            if ((tmp = Movement.GetLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetUpLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetUpRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetDownLeftJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
            if ((tmp = Movement.GetDownRightJumpMove(this, c)) != null && !list.Contains(tmp))
            {
                list.Add(tmp);
                GetAvailableJumpMoves(tmp, list);
            }
        }

        private void ValidateCoordinate(int i, int j)
        {
            if (i < 0 || i >= board.Length)
                throw new ArgumentOutOfRangeException("i", i, $"Invalid value for argument i: {i}");
            if (j < 0 || j >= board[i].Length)
                throw new ArgumentOutOfRangeException("j", j, $"Invalid value for argument j: {j}");
        }

        public void PerformMove(Coordinate from, Coordinate to)
        {
            ValidateCoordinate(from.iInt, from.jInt);
            ValidateCoordinate(to.iInt, to.jInt);
            var temp = board[from.iInt][from.jInt];
            board[from.iInt][from.jInt] = board[to.iInt][to.jInt];
            board[to.iInt][to.jInt] = temp;
        }

        public bool PlayerHasWon(Player player)
        {
            bool result = true;
            foreach (Coordinate c in player.GoalCoordinates)
            {
                if (GetValueFromIndex(c.iInt, c.jInt) != player.Id)
                    result = false;
            }
            return result;
        }
    }
}
