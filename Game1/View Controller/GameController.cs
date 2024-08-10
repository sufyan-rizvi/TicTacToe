using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game1.Exceptions;
using Game1.Models;
using Game1.Repository;

namespace Game1.View_Controller
{
    internal class GameController
    {
        static bool won;
        public static void PlayGame()
        {
            bool continueGame = true;
            Console.WriteLine("Game created by: Mohammed Sufyan Rizvi !");

            PlayerMark();
            int num = 0;
            while (continueGame)
            {
                num = num + 1;
                GameLoop();
                Console.WriteLine("Do you wish to continue, Y/N? ");
                switch (Console.ReadLine().ToLower())
                {
                    case "y":
                        continueGame = true;
                        break;
                    case "n":
                        continueGame= false;
                        break;
                    default:
                        Console.WriteLine("Enter a Valid Choice !");
                        break;
                }
                    
            }

        }

        static void GameLoop()// Contains the main try and except which catches exceptions without incrementing turn
        {
            InitGrid();
            ShowGame();
            Player currentPlayer = GameManager.players[0];
            while (GameManager.TurnsPlayed() <= GameManager.MaxTurns())
            {
                try
                {

                    int a = Game.MovesPlayed;
                    UpdateGame(currentPlayer);
                    ShowGame();
                    won = GameManager.CheckWin();

                    if (won)
                    {
                        Console.WriteLine($"Player{currentPlayer.PlayerId} has won !");
                        break;
                    }

                    currentPlayer = (currentPlayer == GameManager.players[0]) ?
                        GameManager.players[1] : GameManager.players[0];
                    Game.MovesPlayed++;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }              

            }

            if(!won)
                Console.WriteLine("It's a DRAW !!");


        }



        static void UpdateGame(Player player)
        {

            Console.Write($"Player{player.PlayerId} in which row do you want to put your mark in: ");
            int row = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Player{player.PlayerId} in which column do you want to put your mark in: ");
            int col = Convert.ToInt32(Console.ReadLine());

            GameManager.UpdateGrid(player, row, col);

        }

        static void ShowGame()
        {
            Console.WriteLine(GameManager.ShowGrid());
        }

        static void InitGrid()
        {
            GameManager.InitGrid();
        }

        static void PlayerMark()
        {
            for (int playerNumber = 1; playerNumber <= 2; playerNumber++)
            {
                Console.Write($"Player {playerNumber} choose your mark (X or O): ");
                try
                {
                    string choice = Console.ReadLine().ToUpper();
                    GameManager.SetPlayerMark(choice, playerNumber);
                }
                catch (Exception e)
                {
                    playerNumber -= 1;// this is done to not increment the player in case of an exception
                    Console.WriteLine(e.Message);
                }
            }
        }


    }
}
