using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TikTakToe
{
    //Custom helper types
    enum sign { X, O };
    struct boardCoordinate { public int row; public int column; }

    class Game
    {
        //Initial values for the gameplay
        static string[,] gameBoard = new string[3, 3];
        static sign currentSign = sign.X;
        static int numberOfTurnsMade = 0;

        //The gameplay method
        public static void Start()
        {
            Draw.InitialGameBoard(gameBoard);

            while (!Verify.IfGameOver(gameBoard, numberOfTurnsMade))
            {
                numberOfTurnsMade ++;

                //Print prompt and receive coordinates of the turn
                boardCoordinate coordinates = ReceiveCoordinates(currentSign);                
                gameBoard[coordinates.row, coordinates.column] = currentSign.ToString();

                Draw.CurrentGameBoard(gameBoard);
                ChangeCurrentSign();
            }
        }

        static boardCoordinate ReceiveCoordinates(sign currentSign)
        {
            string rawCoordinates;
            boardCoordinate coordinates;
            bool isRightFormat = false;

            do
            {
                Console.Write("\n  Enter coordinates of your move. {0}: ", currentSign);
                rawCoordinates = Console.ReadLine();
                isRightFormat = Verify.CheckCoordinates(rawCoordinates);
            }
            while (!isRightFormat);

            coordinates = ParseCoordinates(rawCoordinates);

            bool isEmpty = Verify.IfCellEmpty(gameBoard, coordinates);

            if (!isEmpty)
            {
                ReceiveCoordinates(currentSign);
            }
                        
            return coordinates;
        }       

        static boardCoordinate ParseCoordinates(string rawCoordinates)
        {
            var coordinate = new boardCoordinate();

            coordinate.row = int.Parse(rawCoordinates[0].ToString());
            coordinate.column = int.Parse(rawCoordinates[2].ToString());

            return coordinate;
        }        

        static void ChangeCurrentSign()
        {
            if (currentSign == sign.X)
            {
                currentSign = sign.O;
            }
            else
            {
                currentSign = sign.X;
            }
                
        }
    }
}
