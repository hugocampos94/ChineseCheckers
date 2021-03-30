#ifndef PLAYERPOSITIONS_H
#define PLAYERPOSITIONS_H

#include <vector>
#include "Coordinate.h"

#define NUM_PLAYER_PIECES 10

class PlayerPositions
{
public:
    static std::vector<Coordinate> TOP_PIECES();
    static std::vector<Coordinate> TOP_RIGHT_PIECES();
    static std::vector<Coordinate> BOTTOM_RIGHT_PIECES();
    static std::vector<Coordinate> BOTTOM_PIECES();
    static std::vector<Coordinate> BOTTOM_LEFT_PIECES();
    static std::vector<Coordinate> TOP_LEFT_PIECES();
private:
    //static std::vector<Coordinate> _top;
    //static std::vector<Coordinate> _top_right;
    //static std::vector<Coordinate> _bottom_right;
    //static std::vector<Coordinate> _bottom;
    //static std::vector<Coordinate> _bottom_left;
    //static std::vector<Coordinate> _top_left;
};

#endif /* PLAYERPOSITIONS_H */