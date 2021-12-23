using System;
using System.Collections.Generic;



public class GameBoard{
    Dictionary<int, List<Player>> board; 


    public GameBoard(){
        this.Board = new Dictionary<int, List<Player>>();
        
        for (int position = 0; position <= 39; position++){ 
            this.Board.Add(position, new List<Player>());
        }
    }
    
    public Dictionary<int, List<Player>> Board { get => board; set => board = value; }
}