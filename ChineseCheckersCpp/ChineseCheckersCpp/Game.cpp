#include "Game.h"

#include <vector>
#include <iostream>
#include <thread>
#include <chrono>
#include <algorithm>
#include <regex>
#include "Board.h"
#include "Coordinate.h"

int Game::PromptNumPlayers()
{
    while (true)
    {
        std::cout << "Please enter the number of players(2-6):" << std::endl;
        std::string input;
        std::getline(std::cin, input);
        
        if (std::regex_match(input, std::regex("^[23456]$")))
        {
            return std::stoi(input);
        }
        else
        {
            std::cout << "Invalid input..." << std::endl;
        }
    }
}

std::vector<Coordinate> Game::GetAvailableMoves(Board board, Coordinate inputCoordinate, int player)
{
    std::vector<Coordinate> list{};
    board.GetAvailableMoves(&inputCoordinate, &list);
    return list;
}

Coordinate Game::PromptCoordinatesToMove(Board* board, Player* player)
{
    std::string input;
    while (true)
    {
        std::cout << "Please select the piece you want to move" << std::endl
            << "by entering the coordinates in format i,j (ex. 0,A)..." << std::endl;
        std::getline(std::cin, input);
        std::transform(input.begin(), input.end(), input.begin(), ::toupper);
        if (!std::regex_match(input, std::regex("^[0-9A-Z][,][0-9A-Z]$")))
            std::cout << "Invalid piece coordinates..." << std::endl;

        else if (board->GetValueFromChars(input[0], input[2]) != player->Number())
            std::cout << "Coordinates don't belong to any piece for current player..." << std::endl;
        else
            return board->GetCoordinateFromChars(input[0], input[2]);
        std::cout << std::endl;
    }
}

int Game::SelectMove(Board* board, std::vector<Coordinate>* list, Coordinate* inputCoordinate)
{
    std::string input;
    while (true)
    {
        input = "";
        std::cout << "List of available moves for Coordinate {"
            << board->GetCharFromIndex(inputCoordinate->I()) << ","
            << board->GetCharFromIndex(inputCoordinate->J()) << "} :" << std::endl;
        for (int i = 0; i < list->size(); i++)
        {
            auto curr = list->at(i);
            std::cout << i + 1 << "{" << board->GetCharFromIndex(curr.I()) << ","
                << board->GetCharFromIndex(curr.J()) << "}" << std::endl;
        }
        std:: cout << "Please enter the movement you want to perform" << std::endl;
        std::getline(std::cin, input);
        std::transform(input.begin(), input.end(), input.begin(), ::toupper);

        if (!std::regex_match(input, std::regex("^[0-9A-Z][,][0-9A-Z]$")))
            std::cout << "Invalid piece coordinates..." << std::endl;
        else if (input.compare("P") == 0)
            return -1;
        else
        {
            Coordinate c = board->GetCoordinateFromChars(input[0], input[2]);
            auto result = std::find_if(list->begin(), list->end(), [&c](Coordinate other) { return c.Compare(&other); });
            if (result != list->end())
                return result - list->begin() + 1;

            std::cout << "Invalid movement..." << std::endl;
            std::cout << std::endl;
        }
    }
}

void Game::Run()
{
    Board board;

    int step = 1;
    Player* player = nullptr;
    int numPlayers;
    Coordinate* inputCoordinate = nullptr;
    Coordinate* highlight1 = nullptr;
    Coordinate* highlight2 = nullptr;
    std::vector<Coordinate> list{};
    int selectedMove = 0;

    while (true)
    {
        switch (step)
        {
        case 1:
            highlight1 = nullptr;
            highlight2 = nullptr;
            numPlayers = PromptNumPlayers();
            board.SetupPlayers(numPlayers);
            player = board.GetPlayer(1);
            step = 2;
            continue;
        case 2:
            std::cout << board.GetBoardStr(highlight1, highlight2) << std::endl;
            std::cout << "Player " << player->Number() << " turn..." << std::endl;
            std::cout << std::endl;
            step = 3;
            continue;
        case 3:
            inputCoordinate = &PromptCoordinatesToMove(&board, player);
            std::cout << std::endl;
            step = 4;
            continue;
        case 4:
            board.GetAvailableMoves(inputCoordinate, &list);
            if (list.size() == 0)
            {
                std::cout << "No moves for the piece selected" << std::endl;
                std::cout << std::endl;
                step = 3;
            }
            else
            {
                step = 5;
            }
            continue;
        case 5:
            selectedMove = SelectMove(&board, &list, inputCoordinate);
            if (selectedMove < 1)
            {
                std::cout << std::endl;
                step = 3;
            }
            else
            {
                board.PerformMove(inputCoordinate, &list.at(selectedMove - 1));
                std::cout << std::endl;
                step = 6;
            }
            continue;
        case 6:
            highlight1 = inputCoordinate;
            highlight2 = &list.at(selectedMove - 1);
            if (board.PlayerHasWon(player))
            {
                step = 7;
            }
            else
            {
                auto playerList = board.GetPlayerList();
                int i = player->Id() < playerList->size() ? player->Id() : 0;
                while (i != player->Id() - 1)
                {
                    if (playerList->at(i).Active())
                    {
                        player = &playerList->at(i);
                        break;
                    }
                    else
                    {
                        i = i + 1 < playerList->size() ? i + 1 : 0;
                    }
                }
                step = 2;
            }
            continue;
        case 7:
            std::cout << board.GetBoardStr(highlight1, highlight2) << std::endl;
            std::cout << "Player " << player->Number() << " has won!!!!" << std::endl;
            std::cout << "Congratulations!!" << std::endl;
            std::this_thread::sleep_for(std::chrono::seconds(3));
            std::cout << "Press Enter to start a new game..." << std::endl;
            std::cin.ignore();
            step = 1;
            continue;
        }
    }
}

int main(int argc, char* args[])
{
    auto game = Game();
    game.Run();
    return 0;
}