#ifndef BOARD_H
#define BOARD_H

#include <vector>
#include <memory>
#include "Coordinate.h"
#include "Player.h"
#include "Movement.h"

class Board
{
public:
    static int Empty();
    static int Void();
    Board();
    Board(int numPlayers);
    void SetupPlayers(int numPlayers);
    void SetupPlayer(Player* player, int playerNum);
    Player* GetPlayer(int player);
    std::vector<Player>* GetPlayerList();
    int RowCount();
    int ColumnCount();
    void SetBoardCoordinates(const std::vector<Coordinate>* coordinates, int value);
    std::string GetBoardStr(Coordinate* highlight1, Coordinate* highlight2);
    Coordinate GetCoordinateFromChars(char a, char b);
    Coordinate GetCoordinateFromIndex(int i, int j);
    int GetValueFromChars(char a, char b);
    int GetValueFromIndex(int i, int j);
    bool IsOccupied(int i, int j);
    char GetCharFromIndex(int i);
    int GetIndexFromChar(char c);
    bool IsPlayer(int i, int j, Player player);
    void GetAvailableMoves(Coordinate* c, std::vector<Coordinate>* list);
    void GetAvailableJumpMoves(Coordinate* c, std::vector<Coordinate>* list);
    void ValidateCoordinate(int i, int j);
    void PerformMove(Coordinate* from, Coordinate* to);
    bool PlayerHasWon(Player* player);
private:
    static constexpr const int EMPTY_VALUE = 0;
    static constexpr const int VOID_VALUE = -1;
    Movement _movement;
    std::vector<std::vector<int>> _boardMap;
    static std::vector<std::vector<int>> _defaultBoardMap;
    static std::vector<Player> _players;
};

#endif /* BOARD_H */