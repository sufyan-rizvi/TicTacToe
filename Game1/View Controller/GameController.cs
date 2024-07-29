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
            Console.WriteLine("Game created by: Mohammed Sufyan Rizvi !");

            PlayerMark();
            InitGrid();
            ShowGame();
            GameLoop();

        }

        static void GameLoop()
        {
            Player currentPlayer = GameManager.players[0];
            while (GameManager.TurnsPlayed() <= 9)
            {
                try
                {

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
            for (int i = 1; i <= 2; i++)
            {
                Console.Write($"Player {i} choose your mark (X or O): ");
                try
                {
                    string choice = Console.ReadLine().ToUpper();
                    GameManager.SetPlayerMark(choice, i);
                }
                catch (Exception e)
                {
                    i -= 1;
                    Console.WriteLine(e.Message);
                }
            }
        }


    }
}
