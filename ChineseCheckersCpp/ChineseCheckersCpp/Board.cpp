#include "Board.h"

#include <vector>
#include <memory>
#include <array>
#include <sstream>
#include "Coordinate.h"
#include "PlayerPositions.h"
#include "Player.h"

std::vector<std::vector<int>> Board::_defaultBoardMap =
{
    {-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
    {0,0,0,0,0,0,0,0,0,0,0,0,0},
    {0,0,0,0,0,0,0,0,0,0,0,0,-1},
    {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
    {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
    {-1,-1,0,0,0,0,0,0,0,0,0,-1,-1},
    {-1,0,0,0,0,0,0,0,0,0,0,-1,-1},
    {-1,0,0,0,0,0,0,0,0,0,0,0,-1},
    {0,0,0,0,0,0,0,0,0,0,0,0,-1},
    {0,0,0,0,0,0,0,0,0,0,0,0,0},
    {-1,-1,-1,-1,0,0,0,0,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,-1,0,0,0,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,-1,0,0,-1,-1,-1,-1,-1,-1},
    {-1,-1,-1,-1,-1,-1,0,-1,-1,-1,-1,-1,-1}
};

std::vector<Player> Board::_players =
{
    Player(1, PlayerPositions::TOP_PIECES(), PlayerPositions::BOTTOM_PIECES()),
    Player(2, PlayerPositions::TOP_LEFT_PIECES(), PlayerPositions::BOTTOM_RIGHT_PIECES()),
    Player(3, PlayerPositions::BOTTOM_LEFT_PIECES(), PlayerPositions::TOP_RIGHT_PIECES()),
    Player(4, PlayerPositions::BOTTOM_PIECES(), PlayerPositions::TOP_PIECES()),
    Player(5, PlayerPositions::BOTTOM_RIGHT_PIECES(), PlayerPositions::TOP_LEFT_PIECES()),
    Player(6, PlayerPositions::TOP_RIGHT_PIECES(), PlayerPositions::BOTTOM_LEFT_PIECES())
};

int Board::Empty() { return EMPTY_VALUE; }

int Board::Void() { return VOID_VALUE; }

Board::Board() : _boardMap(), _movement(this)
{
    _boardMap.reserve(_defaultBoardMap.size());
    for (int i = 0; i < _defaultBoardMap.size(); i++)
        _boardMap.push_back(_defaultBoardMap[i]);
}

Board::Board(int numPlayers) : _boardMap(), _movement(this)
{
    _boardMap.reserve(_defaultBoardMap.size());
    for (int i = 0; i < _defaultBoardMap.size(); i++)
        _boardMap.push_back(_defaultBoardMap[i]);
    SetupPlayers(numPlayers);
}

void Board::SetupPlayers(int numPlayers)
{
    switch (numPlayers)
    {
    case 2:
        SetupPlayer(&_players[0], 1);
        SetupPlayer(&_players[3], 2);
        break;
    case 3:
        SetupPlayer(&_players[0], 1);
        SetupPlayer(&_players[2], 2);
        SetupPlayer(&_players[4], 3);
        break;
    case 4:
        SetupPlayer(&_players[5], 1);
        SetupPlayer(&_players[1], 2);
        SetupPlayer(&_players[2], 3);
        SetupPlayer(&_players[4], 4);
        break;
    case 5:
        SetupPlayer(&_players[0], 1);
        SetupPlayer(&_players[1], 2);
        SetupPlayer(&_players[2], 3);
        SetupPlayer(&_players[3], 4);
        SetupPlayer(&_players[4], 5);
        break;
    case 6:
        SetupPlayer(&_players[0], 1);
        SetupPlayer(&_players[1], 2);
        SetupPlayer(&_players[2], 3);
        SetupPlayer(&_players[3], 4);
        SetupPlayer(&_players[4], 5);
        SetupPlayer(&_players[5], 6);
        break;
    }
}

void Board::SetupPlayer(Player* player, int playerNum)
{
    player->Number(playerNum);
    player->Active(true);
    SetBoardCoordinates(
        &player->StartCoordinates(), playerNum);
}

Player* Board::GetPlayer(int player)
{
    return &_players[player - 1];
}

std::vector<Player>* Board::GetPlayerList()
{
    return &_players;
}

int Board::RowCount()
{
    return _boardMap.size();
}

int Board::ColumnCount()
{
    int maxColumnCount = 0;
    for (auto row : _boardMap)
    {
        if (row.size() > maxColumnCount)
            maxColumnCount = row.size();
    }
    return maxColumnCount;
}

void Board::SetBoardCoordinates(const std::vector<Coordinate>* coordinates, int value)
{
    for(auto coordi : *coordinates)
    {
        _boardMap[coordi.I()][coordi.J()] = value;
    }
}

std::string Board::GetBoardStr(Coordinate* highlight1, Coordinate* highlight2)
{
    std::stringstream boardStr;
    bool shouldHighlight = highlight1 && highlight2;
    for (int i = 0; i < RowCount(); i++)
    {
        if (i % 2 != 0)
        {
            boardStr << "    ";
        }
        for (int j = 0; j < ColumnCount(); j++)
        {
            if (_boardMap[i][j] != Void())
            {
                if (shouldHighlight && (
                    (i == highlight1->I() && j == highlight1->J())
                    || (i == highlight2->I() && j == highlight2->J())))
                    boardStr << '*';
                else
                    boardStr << ' ';
                boardStr << static_cast<char>(_boardMap[i][j] == 0 ? ' ' : '0' + _boardMap[i][j]);
                boardStr << GetCharFromIndex(i) << GetCharFromIndex(j);
            }
            else
                boardStr << "    ";
            if (j < ColumnCount() - 1)
                boardStr << "    ";
        }
        if (i < RowCount() - 1)
            boardStr << '\n';
    }
    return boardStr.str();
}

Coordinate Board::GetCoordinateFromChars(char a, char b)
{
    int i = GetIndexFromChar(a);
    int j = GetIndexFromChar(b);
    return GetCoordinateFromIndex(i, j);
}

Coordinate Board::GetCoordinateFromIndex(int i, int j)
{
    ValidateCoordinate(i, j);
    return Coordinate(i, j);
}

int Board::GetValueFromChars(char a, char b)
{
    int i = GetIndexFromChar(a);
    int j = GetIndexFromChar(b);
    return GetValueFromIndex(i, j);
}

int Board::GetValueFromIndex(int i, int j)
{
    ValidateCoordinate(i, j);
    return _boardMap[i][j];
}

bool Board::IsOccupied(int i, int j)
{
    int v = GetValueFromIndex(i, j);
    if (v != Empty() && v != Void())
        return true;
    else
        return false;
}

char Board::GetCharFromIndex(int i)
{
    if (i >= 0 && i <= 9)
        return (char)(i + '0');
    else if (i >= 10 && i <= 35)
        return (char)(i - 10 + 'A');
    else
        throw "Invalid value for argument i: " + std::to_string(i);
}
int Board::GetIndexFromChar(char c)
{
    if (c >= '0' && c <= '9')
        return c - '0';
    else if (c >= 'A' && c <= 'Z')
        return c - 'A' + 10;
    else
        throw "Invalid value for argument c: " + c;
}

bool Board::IsPlayer(int i, int j, Player player)
{
    ValidateCoordinate(i, j);
    bool result = false;
    if (_boardMap[i][j] == player.Number()) result = true;
    return result;
}

void Board::GetAvailableMoves(Coordinate* c, std::vector<Coordinate>* list)
{
    ValidateCoordinate(c->I(), c->J());
    list->clear();
    _movement.GetLeftMove(c, list);
    _movement.GetRightMove(c, list);
    _movement.GetUpLeftMove(c, list);
    _movement.GetUpRightMove(c, list);
    _movement.GetDownLeftMove(c, list);
    _movement.GetDownRightMove(c, list);
    GetAvailableJumpMoves(c, list);
}

void Board::GetAvailableJumpMoves(Coordinate* c, std::vector<Coordinate>* list)
{
    ValidateCoordinate(c->I(), c->J());

    if (_movement.GetLeftJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
    if (_movement.GetRightJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
    if (_movement.GetUpLeftJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
    if (_movement.GetUpRightJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
    if (_movement.GetDownLeftJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
    if (_movement.GetDownRightJumpMove(c, list))
    {
        GetAvailableJumpMoves(&list->back(), list);
    }
}

void Board::ValidateCoordinate(int i, int j)
{
    if (i < 0 || i >= RowCount())
        throw "Invalid value for argument i: " + std::to_string(i);
    if (j < 0 || j >= ColumnCount())
        throw "Invalid value for argument j: " + std::to_string(j);
}

void Board::PerformMove(Coordinate* from, Coordinate* to)
{
    ValidateCoordinate(from->I(), from->J());
    ValidateCoordinate(to->I(), to->J());
    auto temp = _boardMap[from->I()][from->J()];
    _boardMap[from->I()][from->J()] = _boardMap[to->I()][to->J()];
    _boardMap[to->I()][to->J()] = temp;
}

bool Board::PlayerHasWon(Player* player)
{
    bool result = true;
    for(auto c : player->GoalCoordinates())
    {
        if (GetValueFromIndex(c.I(), c.J()) != player->Id())
            result = false;
    }
    return result;
}