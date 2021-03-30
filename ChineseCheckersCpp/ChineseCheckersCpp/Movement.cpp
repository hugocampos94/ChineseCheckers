#include "Movement.h"

#include <vector>
#include <algorithm>
#include "Coordinate.h"
#include "Board.h"

Movement::Movement(Board* board) : _board(board){}

bool Movement::GetLeftMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    if (c->J() - 1 >= 0 && _board->GetValueFromIndex(c->I(), c->J() - 1) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I(), c->J() - 1));
        return true;
    }
    return false;
}

bool Movement::GetRightMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    if (c->J() + 1 < _board->ColumnCount() && _board->GetValueFromIndex(c->I(), c->J() + 1) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I(), c->J() + 1));
        return true;
    }
    return false;
}

bool Movement::GetUpLeftMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 == 0)
        jOffset = -1;

    if (c->I() - 1 >= 0 && c->J() + jOffset >= 0
        && _board->GetValueFromIndex(c->I() - 1, c->J() + jOffset) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I() - 1, c->J() + jOffset));
        return true;
    }
    return false;
}

bool Movement::GetUpRightMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 != 0)
        jOffset = 1;

    if (c->I() - 1 >= 0 && c->J() + jOffset < _board->ColumnCount()
        && _board->GetValueFromIndex(c->I() - 1, c->J() + jOffset) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I() - 1, c->J() + jOffset));
        return true;
    }
    return false;
}

bool Movement::GetDownLeftMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 == 0)
        jOffset = -1;

    if (c->I() + 1 < _board->RowCount() && c->J() + jOffset >= 0
        && _board->GetValueFromIndex(c->I() + 1, c->J() + jOffset) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I() + 1, c->J() + jOffset));
        return true;
    }
    return false;
}

bool Movement::GetDownRightMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 != 0)
        jOffset = 1;

    if (c->I() + 1 < _board->RowCount() && c->J() + jOffset < _board->ColumnCount()
        && _board->GetValueFromIndex(c->I() + 1, c->J() + jOffset) == Board::Empty())
    {
        cList->push_back(Coordinate(c->I() + 1, c->J() + jOffset));
        return true;
    }
    return false;
}

bool Movement::GetLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    if (c->J() - 2 >= 0 && _board->GetValueFromIndex(c->I(), c->J() - 2) == Board::Empty() && _board->IsOccupied(c->I(), c->J() - 1))
    {
        auto jump = Coordinate(c->I(), c->J() - 2);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}

bool Movement::GetRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    if (c->J() + 2 < _board->ColumnCount() && _board->GetValueFromIndex(c->I(), c->J() + 2) == Board::Empty() && _board->IsOccupied(c->I(), c->J() + 1))
    {
        auto jump = Coordinate(c->I(), c->J() + 2);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}

bool Movement::GetUpLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 == 0)
        jOffset = -1;

    if (c->I() - 2 >= 0 && c->J() - 1 >= 0
        && _board->GetValueFromIndex(c->I() - 2, c->J() - 1) == Board::Empty() && _board->IsOccupied(c->I() - 1, c->J() + jOffset))
    {
        auto jump = Coordinate(c->I() - 2, c->J() - 1);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}

bool Movement::GetUpRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 != 0)
        jOffset = 1;

    if (c->I() - 2 >= 0 && c->J() + 1 < _board->ColumnCount()
        && _board->GetValueFromIndex(c->I() - 2, c->J() + 1) == Board::Empty() && _board->IsOccupied(c->I() - 1, c->J() + jOffset))
    {
        auto jump = Coordinate(c->I() - 2, c->J() + 1);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}

bool Movement::GetDownLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 == 0)
        jOffset = -1;

    if (c->I() + 2 < _board->RowCount() && c->J() - 1 >= 0
        && _board->GetValueFromIndex(c->I() + 2, c->J() - 1) == Board::Empty() && _board->IsOccupied(c->I() + 1, c->J() + jOffset))
    {
        auto jump = Coordinate(c->I() + 2, c->J() - 1);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}

bool Movement::GetDownRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList)
{
    int jOffset = 0;
    if (c->I() % 2 != 0)
        jOffset = 1;

    if (c->I() + 2 < _board->RowCount() && c->J() + 1 < _board->ColumnCount()
        && _board->GetValueFromIndex(c->I() + 2, c->J() + 1) == Board::Empty() && _board->IsOccupied(c->I() + 1, c->J() + jOffset))
    {
        auto jump = Coordinate(c->I() + 2, c->J() + 1);
        if (std::find_if(cList->begin(), cList->end(), [&jump](Coordinate c) { return jump.Compare(&c); }) == cList->end())
        {
            cList->push_back(jump);
            return true;
        }
    }
    return false;
}