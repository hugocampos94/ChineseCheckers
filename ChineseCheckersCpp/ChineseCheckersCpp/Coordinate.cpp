#include "Coordinate.h"

int const Coordinate::I() { return _i; }

void Coordinate::I(int value) { _i = value; }

int const Coordinate::J() { return _j; }

void Coordinate::J(int value) { _j = value; }

Coordinate::Coordinate()
{
    _i = -1;
    _j = -1;
}

Coordinate::Coordinate(int i, int j)
{
    _i = i;
    _j = j;
}

bool Coordinate::Compare(Coordinate* other)
{
    if (this->I() == other->I() && this->J() == other->J())
        return true;
    else
        return false;
}