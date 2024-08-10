using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Game1.Models;
using Game1.Exceptions;

namespace Game1.Repository
{
    internal static class GameManager
    {
        public static List<Player> players = new List<Player> { new Player(1), new Player(2) };
        public static List<List<string>> gameGrid;
        public static List<string> temp;

        public static void InitGrid() // sets all the values of the 3X3 grid to be " " <-- spaces
        {
            gameGrid = new List<List<string>>();
            for (int row = 0; row < Game.NumberOfRows; row++)
            {
                temp = new List<string>();

                for (int col = 0; col < Game.NumberOfColumns; col++)
                {
                    temp.Add(" ");
                }
                gameGrid.Add(temp);
            }

        }

        public static void SetPlayerMark(string choice, int i) // <---- gives user choice to pick their mark an X or O, it also checks
                                                               // if the correct letter was entered and that the previous player hasnt picked it 
        {
            if ((choice != "X" && choice != "O") || choice == players[0].PlayerMark)
            {
                i -= 1;
                throw new EnterValidOptionException("Please Enter a valid option !");
            }
            players[i - 1].PlayerMark = choice;
        }


        public static void UpdateGrid(Player player, int row, int col)//after user says where to put the mark, this handles exceptions
                                                                      //and sets the mark at the given row and column
        {
            if (row > 2 || col > 2)
                throw new IndexOutOfRangeException();

            if (gameGrid[row][col] == "X" || gameGrid[row][col] == "O")
                throw new MarkAlreadyPresentException("That cell is occupied ! Try another Cell !");

            gameGrid[row][col] = player.PlayerMark;

        }



        public static string ShowGrid() // this is to display the 3X3 grid for ease of understanding the game.
        {
            return ($"\n" +
                    $"\t\t\t\t     Columns\n\n" +
                    $"\t\t\t0\t\t1\t\t2\n\n" +
                    $"\t\t\t|\t\t|\t\t|\n" +
                    $"\t\t\t|\t\t|\t\t|\n" +
                    $"\t\t\tV\t\tV\t\tV\n\n" +
                    $"\t\t\t \t|\t \t|\n" +
                    $"\t     0---->\t{gameGrid[0][0]}\t|\t{gameGrid[0][1]}\t|\t{gameGrid[0][2]}\n" +
                    $"\t\t\t \t|\t \t|\n" +
                    $"\t\t     -----------------------------------------\n" +
                    $"\t\t \t\t|\t \t|\n" +
                    $" Rows---->   1---->\t{gameGrid[1][0]}\t|\t{gameGrid[1][1]}\t|\t{gameGrid[1][2]}\n" +
                    $"\t \t\t\t|\t \t|\n" +
                    $"\t\t     -----------------------------------------\n" +
                    $"\t\t\t\t|\t \t|\n" +
                    $"\t     2---->\t{gameGrid[2][0]}\t|\t{gameGrid[2][1]}\t|\t{gameGrid[2][2]}\n" +
                    $"\t \t\t\t|\t \t|\n");
        }


        public static bool CheckWin()// Checks all possibilities of winning the game, Min moves to start winning: 4.
        {
            bool won;
            //checking row wise wins
            for (int row = 0; row < Game.NumberOfRows; row++)
            {
                won = true;
                for (int col = 0; col < Game.NumberOfColumns - 1; col++)
                {
                    if ((gameGrid[row][col] == "X" && gameGrid[row][col + 1] == "X") || (gameGrid[row][col] == "O" && gameGrid[row][col + 1] == "O"))
                    {
                        won &= true;
                    }
                    else
                        won &= false;

                }
                if (won)
                {
                    return won;
                }
            }
            //Check column wise win
            for (int col = 0; col < Game.NumberOfRows; col++)
            {
                won = true;
                for (int row = 0; row < Game.NumberOfColumns - 1; row++)
                {
                    if ((gameGrid[row][col] == "X" && gameGrid[row + 1][col] == "X") || (gameGrid[row][col] == "O" && gameGrid[row + 1][col] == "O"))
                    {
                        won &= true;
                    }
                    else
                        won &= false;
                }
                if (won)
                {
                    return won;
                }
            }
            //check diagnol "\" win
            won = true;
            for (int i = 0; i < Game.NumberOfColumns - 1; i++)
            {
                if ((gameGrid[i][i] == "X" && gameGrid[i + 1][i + 1] == "X") || (gameGrid[i][i] == "O" && gameGrid[i + 1][i + 1] == "O"))
                {
                    won &= true;
                }
                else
                    won &= false;
            }
            if (won)
            {
                return won;
            }
            // check diagnol "/" win
            won = true;
            for (int i = 0; i < Game.NumberOfColumns - 1; i++)
            {
                if ((gameGrid[Game.NumberOfRows - i - 1][i] == "X" && gameGrid[Game.NumberOfRows - i - 2][i + 1] == "X") || (gameGrid[Game.NumberOfRows - i - 1][i] == "O" && gameGrid[Game.NumberOfRows - i - 2][i + 1] == "O"))
                {
                    won &= true;
                }
                else
                    won &= false;
            }

            return won;
        }

        public static int TurnsPlayed()//Just to be used in the controller class
        {
            return Game.MovesPlayed;
        }

        public static int MaxTurns()
        {
            return Game.MAX_TURNS;
        }
    }
}
