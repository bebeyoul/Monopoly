using System;
using System.Collections.Generic;

namespace Monopoly
{
    class Program
    {
        static void Main(string[] args)
        {
            int nb_Lab = 2; //nb_Lab
            GameMaster gameMaster = new GameMaster(nb_Lab);
            
            Console.WriteLine("The first player to do {0} laps win the game !", nb_Lab);
            gameMaster.Showing_Board();

            while(!gameMaster.IsEnded){
                gameMaster.Playing();
            }
        }
    }
}

