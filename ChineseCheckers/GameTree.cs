using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    class GameTree
    {
        private int[][] _boardState;

        private Player _currentPlayer;

        private GameTree[] _children;

        private static double[][] CENTRAL_TOP_TO_BOTTOM = new double[][] {
            new double[] { 0, 6 },
            new double[] { 1, 5.5 },
            new double[] { 2, 6 },
            new double[] { 3, 5.5 },
            new double[] { 4, 6 },
            new double[] { 5, 5.5 },
            new double[] { 6, 6 },
            new double[] { 7, 5.5 },
            new double[] { 8, 6 },
            new double[] { 9, 5.5 },
            new double[] { 10, 6 },
            new double[] { 11, 5.5 },
            new double[] { 12, 6 },
            new double[] { 13, 5.5 },
            new double[] { 14, 6 },
            new double[] { 15, 5.5 },
            new double[] { 16, 6 }
        };

        private static double[][] CENTRAL_TOP_RIGHT_TO_BOTTOM_LEFT = new double[][] {
            new double[] { 4, 24 },
            new double[] { 4.5, 22.5 },
            new double[] { 5, 21 },
            new double[] { 5.5, 19.5 },
            new double[] { 6, 18 },
            new double[] { 6.5, 16.5 },
            new double[] { 7, 15 },
            new double[] { 7.5, 13.5 },
            new double[] { 8, 12 },
            new double[] { 8.5, 10.5 },
            new double[] { 9, 9 },
            new double[] { 9.5, 7.5 },
            new double[] { 10, 6 },
            new double[] { 10.5, 4.5 },
            new double[] { 11, 3 },
            new double[] { 11.5, 1.5 },
            new double[] { 12, 0 }
        };

        private static double[][] CENTRAL_TOP_LEFT_TO_BOTTOM_RIGHT = new double[][] {
            new double[] { 4, 0 },
            new double[] { 4.5, 1.5 },
            new double[] { 5, 3 },
            new double[] { 5.5, 4.5 },
            new double[] { 6, 6 },
            new double[] { 6.5, 7.5 },
            new double[] { 7, 9 },
            new double[] { 7.5, 10.5 },
            new double[] { 8, 12 },
            new double[] { 8.5, 13.5 },
            new double[] { 9, 15 },
            new double[] { 9.5, 16.5 },
            new double[] { 10, 18 },
            new double[] { 10.5, 19.5 },
            new double[] { 11, 21 },
            new double[] { 11.5, 22.5 },
            new double[] { 12, 24 }
        };

        public int[][] BoardState
        {
            get { return _boardState; }
        }
        public Player CurrentPlayer
        {
            get { return _currentPlayer; }
        }
        public GameTree[] Children
        {
            get { return _children; }
        }
        public GameTree(int[][] board, Player player)
        {
            _boardState = board;
            _currentPlayer = player;
        }

        private double[] ConvertToAbsolute(int i, int j)
        {
            if (i % 2 == 0)
                return new double[] { i, j * 2 };
            else
                return new double[] { i, 1 + j * 2 };
        }

        private double GetDistanceToCentralLine(int i, int j)
        {
            double[][] centralLine = null;
            double[] current = ConvertToAbsolute(i, j);
            if (CurrentPlayer.IsPlayerCoordinate((int)CENTRAL_TOP_TO_BOTTOM[0][0], (int)CENTRAL_TOP_TO_BOTTOM[0][0]))
                centralLine = CENTRAL_TOP_TO_BOTTOM;
            else if (CurrentPlayer.IsPlayerCoordinate((int)CENTRAL_TOP_RIGHT_TO_BOTTOM_LEFT[0][0], (int)CENTRAL_TOP_RIGHT_TO_BOTTOM_LEFT[0][0]))
                centralLine = CENTRAL_TOP_RIGHT_TO_BOTTOM_LEFT;
            else if (CurrentPlayer.IsPlayerCoordinate((int)CENTRAL_TOP_LEFT_TO_BOTTOM_RIGHT[0][0], (int)CENTRAL_TOP_LEFT_TO_BOTTOM_RIGHT[0][0]))
                centralLine = CENTRAL_TOP_LEFT_TO_BOTTOM_RIGHT;
            else
                throw new ArgumentException("Coordinates provided don't belong to any player");
            double distance = double.MaxValue;
            foreach (double[] c in centralLine)
            {
                var temp = Math.Sqrt(Math.Pow(c[0] - current[0], 2) + Math.Pow(c[1] - current[1], 2));
                if (temp < distance)
                    distance = temp;
            }
            return distance;
        }

        public double GetSumOfDistancesToCentralLine()
        {
            double sum = 0;
            for(int i = 0; i < BoardState.Length; i++)
            {
                for(int j = 0; j < BoardState[i].Length; j++)
                {
                    if (BoardState[i][j] == CurrentPlayer.Id)
                        sum = sum + GetDistanceToCentralLine(i, j);
                }
            }
            return sum;
        }

        public double GetSumOfDistancesToCorner()
        {
            double sum = 0;
            for (int i = 0; i < BoardState.Length; i++)
            {
                for (int j = 0; j < BoardState[i].Length; j++)
                {
                    if (BoardState[i][j] == CurrentPlayer.Id)
                    {
                        double[] current = ConvertToAbsolute(i, j);
                        double[] goal = ConvertToAbsolute(CurrentPlayer.GoalCoordinates[0].i, CurrentPlayer.GoalCoordinates[0].j);
                        double distance = Math.Sqrt(Math.Pow(goal[0] - current[0], 2) + Math.Pow(goal[1] - current[1], 2));
                        sum = sum + distance;
                    }   
                }
            }
            return sum;
        }
    }
}
