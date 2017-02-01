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

                string rawCoordinates = "";
                bool isRightFormat = false; //Format of coordinate imput
                bool isEmpty = false; //If current cell is empty

                //Print prompt and receive coordinates of the turn
                while (!isEmpty)
                {
                    do
                    {
                        rawCoordinates = ReceiveCoordinates(currentSign);
                        isRightFormat = Verify.CheckCoordinates(rawCoordinates);
                    }
                    while (!isRightFormat);

                    boardCoordinate coordinates = ParseCoordinates(rawCoordinates);

                    isEmpty = Verify.IfCellEmpty(gameBoard, coordinates);
                    if (!isEmpty)
                    {
                        Console.WriteLine("\n  This cell is already occupied. Please try again.");
                    }
                    else
                    {
                        gameBoard[coordinates.row, coordinates.column] = currentSign.ToString();
                    }
                    
                }
                               
                Draw.CurrentGameBoard(gameBoard);
                ChangeCurrentSign();
            }
        }

        static string ReceiveCoordinates(sign currentSign)
        {            
            Console.Write("\n  Enter coordinates of your move. {0}: ", currentSign);
            string rawCoordinates = Console.ReadLine();
                       
            return rawCoordinates;
        }       

        static boardCoordinate ParseCoordinates(string rawCoordinates)
        {
            var coordinate = new boardCoordinate();

            const int COORD_X = 0; //First and third positions
            const int COORD_Y = 2; //of the input string respectively

            coordinate.row = int.Parse(rawCoordinates[COORD_X].ToString());
            coordinate.column = int.Parse(rawCoordinates[COORD_Y].ToString());

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
