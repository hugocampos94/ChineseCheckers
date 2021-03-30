#ifndef COORDINATE_H
#define COORDINATE_H

class Coordinate
{
public:
    int const I();
    void I(int value);
    int const J();
    void J(int value);
    Coordinate();
    Coordinate(int i, int j);
    bool Compare(Coordinate* other);
private:
    int _i;
    int _j;
};

#endif /* COORDINATE_H */