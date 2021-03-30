#include "Player.h"

#include <string>
#include <vector>
#include "Coordinate.h"

Player::Player(int id, std::vector<Coordinate> startCoordinates, std::vector<Coordinate> goalCoordinates)
: _id(id), _startCoordinates(), _goalCoordinates()
, _name("Player" + std::to_string(id)), _number(id), _active(false)
{
    _startCoordinates.reserve(startCoordinates.size());
    for (int i = 0; i < startCoordinates.size(); i++)
        _startCoordinates.push_back(startCoordinates[i]);

    _goalCoordinates.reserve(goalCoordinates.size());
    for (int i = 0; i < goalCoordinates.size(); i++)
        _goalCoordinates.push_back(goalCoordinates[i]);
}

int const Player::Id() { return _id; }

std::string const Player::Name() { return _name; }

void Player::Name(std::string value) { _name = value; }

int const Player::Number() { return _number; }

void Player::Number(int value) { _number = value; }

bool const Player::Active() { return _active; }

void Player::Active(bool value) { _active = value; }

std::vector<Coordinate> const Player::StartCoordinates() { return _startCoordinates; }

std::vector<Coordinate> const Player::GoalCoordinates() { return _goalCoordinates; }
