using System;
using System.Collections.Generic;


// In order to launch the program, you need to enter 
// the following command : dotnet run
// Be sure to execute the command in the appropriate directory :
// the following should be the one : C:\Users\julie\OneDrive\Documents\ESILV\DesignPattern\Monopoly>
// If it is not already the correct path, use the command 'cd C:\Users\julie\OneDrive\Documents\ESILV\DesignPattern\Monopoly'

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

