using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TikTakToe
{
    class Verify
    {
        const string EMPTY_CELL = " ";

        public static bool IfCellEmpty(string[,] gameBoard, boardCoordinate coordinates)
        {
            bool isCellEmpty = (gameBoard[coordinates.row, coordinates.column] == EMPTY_CELL);
            
            if(!isCellEmpty)
            {
                Console.WriteLine("\n  This cell is already occupied. Please try again.");
            }
            else
            {
                isCellEmpty = true;
            }
            
            return isCellEmpty;
        }

        public static bool CheckCoordinates(string rawCoordinates)
        {
            bool isCoordinates = Regex.Match(rawCoordinates, @"[012][\D][012]").Success;

            if (!isCoordinates)
            {
                Console.WriteLine("Wrong format or range of the move. Please try again.");
            }
            return isCoordinates;
        }

        public static bool IfGameOver(string[,] gameBoard, int numberOfTurnsMade)
        {
            const int MAX_NUMBER_OF_TURNS = 9; //3 rows by 3 columns

            if (CheckHorizontal(gameBoard))
            {
                return true;
            }

            if (CheckVertical(gameBoard))
            {
                return true;
            }

            if (CheckDiagonals(gameBoard))
            {
                return true;
            }

            if (numberOfTurnsMade >= MAX_NUMBER_OF_TURNS)
            {
                Console.WriteLine("\n   Game over! Nobody won.\n");
                return true;
            }

            else return false;
        }

        static bool CheckVertical(string[,] gameBoard)
        {
            bool isGameOver = false;

            for (int i = 0; i <= 2; i++)
            {
                if (gameBoard[0, i] != " " &&
                    gameBoard[0, i] == gameBoard[1, i] &&
                    gameBoard[0, i] == gameBoard[2, i])
                {
                    Console.WriteLine("\n   Player {0} won!", gameBoard[0, i]);
                    isGameOver = true;
                }
            }

            return isGameOver;
        }

        static bool CheckHorizontal(string[,] gameBoard)
        {
            bool isGameOver = false; 

            for (int i = 0; i <= 2; i++)
            {
                if (gameBoard[i, 0] != " " &&
                    gameBoard[i, 0] == gameBoard[i, 1] &&
                    gameBoard[i, 0] == gameBoard[i, 2])
                {
                    Console.WriteLine("\n   Player {0} won!", gameBoard[i, 0]);
                    isGameOver = true;
                }
                
            }

            return isGameOver;
        }

        static bool CheckDiagonals(string[,] gameBoard)
        {
            bool isGameOver = false;

            if (gameBoard[0, 0] != " " &&
                gameBoard[0, 0] == gameBoard[1, 1] &&
                gameBoard[0, 0] == gameBoard[2, 2])
            {
                Console.WriteLine("\n   Player {0} won!", gameBoard[0, 0]);
                isGameOver = true;
            }

            if (gameBoard[0, 2] != " " &&
                gameBoard[0, 2] == gameBoard[1, 1] &&
                gameBoard[0, 2] == gameBoard[2, 0])
            {
                Console.WriteLine("\n   Player {0} won!", gameBoard[0, 2]);
                isGameOver = true;
            }

            return isGameOver;
        }


    }
}
