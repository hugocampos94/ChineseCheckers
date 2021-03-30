#ifndef MOVEMENT_H
#define MOVEMENT_H

#include <vector>
#include "Coordinate.h"
class Board;

class Movement
{
public:
    Movement(Board* board);
    bool GetLeftMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetRightMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetUpLeftMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetUpRightMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetDownLeftMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetDownRightMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetUpLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetUpRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetDownLeftJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
    bool GetDownRightJumpMove(Coordinate* c, std::vector<Coordinate>* cList);
private:
    Board* _board;
};

#endif /* MOVEMENT_H */