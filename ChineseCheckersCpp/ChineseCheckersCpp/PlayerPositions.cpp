#include "PlayerPositions.h"

#include <vector>
#include "Coordinate.h"

std::vector<Coordinate> PlayerPositions::TOP_PIECES()
{
    static std::vector<Coordinate> _top{};
    if (_top.size() == 0)
    {
        _top.reserve(10);
        _top.push_back(Coordinate(0, 6));
        _top.push_back(Coordinate(1, 5));
        _top.push_back(Coordinate(1, 6));
        _top.push_back(Coordinate(2, 5));
        _top.push_back(Coordinate(2, 6));
        _top.push_back(Coordinate(2, 7));
        _top.push_back(Coordinate(3, 4));
        _top.push_back(Coordinate(3, 5));
        _top.push_back(Coordinate(3, 6));
        _top.push_back(Coordinate(3, 7));
    }
    return _top;
}

std::vector<Coordinate> PlayerPositions::TOP_RIGHT_PIECES()
{
    static std::vector<Coordinate> _top_right{};
    if (_top_right.size() == 0)
    {
        _top_right.reserve(10);
        _top_right.push_back(Coordinate(4, 12));
        _top_right.push_back(Coordinate(4, 11));
        _top_right.push_back(Coordinate(5, 11));
        _top_right.push_back(Coordinate(4, 10));
        _top_right.push_back(Coordinate(5, 10));
        _top_right.push_back(Coordinate(6, 11));
        _top_right.push_back(Coordinate(4, 9));
        _top_right.push_back(Coordinate(5, 9));
        _top_right.push_back(Coordinate(6, 10));
        _top_right.push_back(Coordinate(7, 10));
    }
    return _top_right;
}

std::vector<Coordinate> PlayerPositions::BOTTOM_RIGHT_PIECES()
{
    static std::vector<Coordinate> _bottom_right{};
    if (_bottom_right.size() == 0)
    {
        _bottom_right.reserve(10);
        _bottom_right.push_back(Coordinate(12, 12));
        _bottom_right.push_back(Coordinate(11, 11));
        _bottom_right.push_back(Coordinate(12, 11));
        _bottom_right.push_back(Coordinate(10, 11));
        _bottom_right.push_back(Coordinate(11, 10));
        _bottom_right.push_back(Coordinate(12, 10));
        _bottom_right.push_back(Coordinate(9, 10));
        _bottom_right.push_back(Coordinate(10, 10));
        _bottom_right.push_back(Coordinate(11, 9));
        _bottom_right.push_back(Coordinate(12, 9));
    }
    return _bottom_right;
}

std::vector<Coordinate> PlayerPositions::BOTTOM_PIECES()
{
    static std::vector<Coordinate> _bottom{};
    if (_bottom.size() == 0)
    {
        _bottom.reserve(10);
        _bottom.push_back(Coordinate(16, 6));
        _bottom.push_back(Coordinate(15, 5));
        _bottom.push_back(Coordinate(15, 6));
        _bottom.push_back(Coordinate(14, 5));
        _bottom.push_back(Coordinate(14, 6));
        _bottom.push_back(Coordinate(14, 7));
        _bottom.push_back(Coordinate(13, 4));
        _bottom.push_back(Coordinate(13, 5));
        _bottom.push_back(Coordinate(13, 6));
        _bottom.push_back(Coordinate(13, 7));
    }
    return _bottom;
}
std::vector<Coordinate> PlayerPositions::BOTTOM_LEFT_PIECES()
{
    static std::vector<Coordinate> _bottom_left{};
    if (_bottom_left.size() == 0)
    {
        _bottom_left.reserve(10);
        _bottom_left.push_back(Coordinate(12, 0));
        _bottom_left.push_back(Coordinate(11, 0));
        _bottom_left.push_back(Coordinate(12, 1));
        _bottom_left.push_back(Coordinate(10, 1));
        _bottom_left.push_back(Coordinate(11, 1));
        _bottom_left.push_back(Coordinate(12, 2));
        _bottom_left.push_back(Coordinate(9, 1));
        _bottom_left.push_back(Coordinate(10, 2));
        _bottom_left.push_back(Coordinate(11, 2));
        _bottom_left.push_back(Coordinate(12, 3));
    }
    return _bottom_left;
}

std::vector<Coordinate> PlayerPositions::TOP_LEFT_PIECES()
{
    static std::vector<Coordinate> _top_left{};
    if (_top_left.size() == 0)
    {
        _top_left.reserve(10);
        _top_left.push_back(Coordinate(4, 0));
        _top_left.push_back(Coordinate(4, 1));
        _top_left.push_back(Coordinate(5, 0));
        _top_left.push_back(Coordinate(4, 2));
        _top_left.push_back(Coordinate(5, 1));
        _top_left.push_back(Coordinate(6, 1));
        _top_left.push_back(Coordinate(4, 3));
        _top_left.push_back(Coordinate(5, 2));
        _top_left.push_back(Coordinate(6, 2));
        _top_left.push_back(Coordinate(7, 1));
    }
    return _top_left;
}