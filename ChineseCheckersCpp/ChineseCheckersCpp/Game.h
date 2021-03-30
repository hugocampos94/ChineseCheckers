#ifndef GAME_H
#define GAME_H

#include <vector>
#include "Board.h"
#include "Coordinate.h"

class Game
{
public:
	int PromptNumPlayers();
	std::vector<Coordinate> GetAvailableMoves(Board board, Coordinate inputCoordinate, int player);
	Coordinate PromptCoordinatesToMove(Board* board, Player* player);
	int SelectMove(Board* board, std::vector<Coordinate>* list, Coordinate* inputCoordinate);
	void Run();
};

#endif /* GAME_H */