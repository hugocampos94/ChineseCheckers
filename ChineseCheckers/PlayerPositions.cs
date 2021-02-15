using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChineseCheckers
{
    public class PlayerPositions
    {
        public static List<Coordinate> TOP_PIECES = new List<Coordinate>()
        {
            new Coordinate(0, 6),
            new Coordinate(1, 5),
            new Coordinate(1, 6),
            new Coordinate(2, 5),
            new Coordinate(2, 6),
            new Coordinate(2, 7),
            new Coordinate(3, 4),
            new Coordinate(3, 5),
            new Coordinate(3, 6),
            new Coordinate(3, 7)
        };
        public static List<Coordinate> TOP_RIGHT_PIECES = new List<Coordinate>()
        {
            new Coordinate(4, 12),
            new Coordinate(4, 11),
            new Coordinate(5, 11),
            new Coordinate(4, 10),
            new Coordinate(5, 10),
            new Coordinate(6, 11),
            new Coordinate(4, 9),
            new Coordinate(5, 9),
            new Coordinate(6, 10),
            new Coordinate(7, 10)
        };

        public static List<Coordinate> BOTTOM_RIGHT_PIECES = new List<Coordinate>()
        {
            new Coordinate(12, 12),
            new Coordinate(11, 11),
            new Coordinate(12, 11),
            new Coordinate(10, 11),
            new Coordinate(11, 10),
            new Coordinate(12, 10),
            new Coordinate(9, 10),
            new Coordinate(10, 10),
            new Coordinate(11, 9),
            new Coordinate(12, 9)
        };

        public static List<Coordinate> BOTTOM_PIECES = new List<Coordinate>()
        {
            new Coordinate(16, 6),
            new Coordinate(15, 5),
            new Coordinate(15, 6),
            new Coordinate(14, 5),
            new Coordinate(14, 6),
            new Coordinate(14, 7),
            new Coordinate(13, 4),
            new Coordinate(13, 5),
            new Coordinate(13, 6),
            new Coordinate(13, 7)
        };

        public static List<Coordinate> BOTTOM_LEFT_PIECES = new List<Coordinate>()
        {
            new Coordinate(12, 0),
            new Coordinate(11, 0),
            new Coordinate(12, 1),
            new Coordinate(10, 1),
            new Coordinate(11, 1),
            new Coordinate(12, 2),
            new Coordinate(9, 1),
            new Coordinate(10, 2),
            new Coordinate(11, 2),
            new Coordinate(12, 3)
        };

        public static List<Coordinate> TOP_LEFT_PIECES = new List<Coordinate>()
        {
            new Coordinate(4, 0),
            new Coordinate(4, 1),
            new Coordinate(5, 0),
            new Coordinate(4, 2),
            new Coordinate(5, 1),
            new Coordinate(6, 1),
            new Coordinate(4, 3),
            new Coordinate(5, 2),
            new Coordinate(6, 2),
            new Coordinate(7, 1)
        };

    }
}
