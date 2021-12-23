using System;
using System.Collections.Generic;

public class GameMaster{
    Dice dice;
    GameBoard board;
    int playerNumber;
    List<Player> playerList;
    int winning_Lap; //Winning_Lap => winning_Lap
    bool isEnded; // isEnded

    public GameMaster(int winning_Lap){
        this.winning_Lap = winning_Lap;
        this.Dice = new Dice();
        this.Board = new GameBoard();
        this.PlayerList = new List<Player>();
        this.IsEnded = false;
        playerNumber = 0;

        while(playerNumber < 2){
            Console.Write("\nChoose the number of player : ");
            
            while (!int.TryParse(Console.ReadLine(), out playerNumber))
            {
                Console.WriteLine("Input is not valid. Enter a positive number.");
                Console.Write("\nChoose the number of player : ");
            }
        }


        for (int i = 0; i < PlayerNumber; i++){
            this.PlayerList.Add(new Player());
        }

        List<Player> playerTemp = new List<Player>();
        foreach(Player player in playerList){
            playerTemp.Add(player); // playerTemp contient l'ensemble des joueurs
        }

        this.board.Board[0] = playerTemp; //We put every player on the 1st case
    }

    public Dice Dice { get => dice; set => dice = value; }
    public GameBoard Board { get => board; set => board = value; }
    public int PlayerNumber { get => playerNumber; set => playerNumber = value; }
    public List<Player> PlayerList { get => playerList; set => playerList = value; }
    public bool IsEnded { get => isEnded; set => isEnded = value; }

    public void Playing(){  //Playing
        for (int i = 0; i < playerNumber; i++){
            if(!isEnded){ // !isEnded
                Managing_Turn(playerList[i]);
                //Only test if the player can go in jail if he is not already in it
                if(!playerList[i].Being_In_Jail){
                    Being_In_Jail(playerList[i]);
                }
                Showing_Board();
                Console.ReadKey();
            }
            if(playerList[i].Nb_Lap >= winning_Lap){
                End_Game(playerList[i]);
            }
        }
    }
    
    // Discute avec le joueur, lui dit quoi faire et donne son résultat
    public void Throwing_Player(Player player){ 
        dice.Throw_Dice();
        
        Console.Write("\n" + player.Name + " need to play.");
        Console.Write("\nRoll dice...[press ENTER]");
        Console.ReadKey();

        Console.Write("\nFirst dice : {0} \tSecond dice : {1}", dice.First_Dice, dice.Second_Dice);
        Console.Write("\n{0} move of {1} square(s)\n", player.Name, dice.First_Dice + dice.Second_Dice);
    }

    public void Being_In_Jail(Player player){ 
        if(player.Position == 30 || player.Being_In_Jail == true){
            board.Board[player.Position].Remove(player);
            player.Position = 10;
            board.Board[player.Position].Add(player);
            player.Being_In_Jail = true;
            Console.WriteLine(player.Name + " is now in jail.\nIn order to go out the player need to land the same value for both dice OR fail to do so three times...");
        }
    }

    // Gère le tour d'un joueur (plusieurs lancé de dés potentiel)
    public void Managing_Turn(Player player){
        if(player.Being_In_Jail){
            Throwing_Player(player);
            // Si 3 tours sans faire de double, tu sors
            //Si tu fais un double, tu sors
            if(dice.First_Dice == dice.Second_Dice || player.Nb_Throw >= 3){
                player.Being_In_Jail = false;
                player.Nb_Throw = 0;
                Console.WriteLine("You are free to go now...");
                Moving_Player_On_Board(player);
            }else{
                player.Nb_Throw++;
            }
            // Si tu n'es pas en prison:
        }else{
            Throwing_Player(player); 
            Moving_Player_On_Board(player); 
            // On va regarder combien de fois il arrive a faire des doubles d'affiler
            // Si tu as fait des doubles 3 fois d'affiler, tu vas en prison
            if(dice.First_Dice != dice.Second_Dice){
                player.Nb_Throw = 0;
            }

            if(dice.First_Dice == dice.Second_Dice && player.Nb_Throw < 3){
                Showing_Board(); 
                Console.Write(player.Name + " throw the same value!! The player can play again !\n");
                Throwing_Player(player); 
                Moving_Player_On_Board(player); 
                player.Nb_Throw++;

            }else if(dice.First_Dice == dice.Second_Dice && player.Nb_Throw >= 3){
                player.Being_In_Jail = true;
                player.Nb_Throw = 0;
                Console.WriteLine(player.Name + " has throw the same value for the two dice three times in a row. The player will now go to jail... [press ENTER]");
                Console.ReadKey();
                Being_In_Jail(player); 
                Showing_Board();
            }
        }
        
    }


    public void Moving_Player_On_Board(Player player){ 
        int preced_Position = player.Position;
        player.Moving(dice.First_Dice + dice.Second_Dice);
        board.Board[preced_Position].Remove(player);
        board.Board[player.Position].Add(player);
    } 



    public void Showing_Board(){
        foreach (KeyValuePair<int, List<Player>> key in this.board.Board)
        {
            if(key.Key == 30){
                Console.ForegroundColor = ConsoleColor.DarkRed; //DarkRed
                Console.Write("--GO TO JAIL--\n");
                Console.ResetColor();
            }
            if(key.Key == 10){
                Console.ForegroundColor = ConsoleColor.Yellow; //jaune
                Console.Write("--VISIT ONLY / IN JAIL--\n");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Gray; //Gray
            Console.Write("Position : {0}", key.Key);
            Console.ForegroundColor = ConsoleColor.DarkBlue; //Rose
            Console.Write("\tPlayer : ");
            Console.ResetColor();


            if (key.Value != null)
            {
                foreach (Player player in key.Value)
                {
                    if(player.Being_In_Jail){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(player.Name + "[Lap :" + player.Nb_Lap + "]" + " // ");
                        Console.ResetColor();
                    }else{
                        Console.Write(player.Name + "[Lap :" + player.Nb_Lap + "]" + " // ");
                    }
                }
            }
            if (key.Key == 30){
                Console.ForegroundColor = ConsoleColor.DarkRed; //DarkRed
                Console.Write("\n--GO TO JAIL--");
                Console.ResetColor();
            }
            if (key.Key == 10){
                Console.ForegroundColor = ConsoleColor.Yellow; //jaune
                Console.Write("\n--VISIT ONLY / IN JAIL--");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine("[press ENTER]");
    }



    public void End_Game(Player player){
        Console.WriteLine("\nCongratulations !!\n{0} WON THE GAME !!", player.Name);
        this.IsEnded = true;
    }
}