#ifndef PLAYER_H
#define PLAYER_H

#include <string>
#include <vector>
#include "Coordinate.h"

class Player
{
public:
    Player(int id, std::vector<Coordinate> startCoordinates, std::vector<Coordinate> goalCoordinates);
    int const Id();
    std::string const Name();
    void Name(std::string value);
    int const Number();
    void Number(int value);
    bool const Active();
    void Active(bool value);
    std::vector<Coordinate> const StartCoordinates();
    std::vector<Coordinate> const GoalCoordinates();
private:
    int _id;
    int _number;
    std::string _name;
    bool _active;
    std::vector<Coordinate> _startCoordinates;
    std::vector<Coordinate> _goalCoordinates;
};

#endif /* PLAYER_H */