using System;

public class Player{

    string name;
    int position;
    int nb_Lap; // nb_Lap
    bool being_In_Jail; //Being_In_Jail
    int nb_Throw; // nb_Throw

    public Player(){
        Console.Write("Choose a name : ");
        this.Name = Console.ReadLine();
        this.Position = 0;
        this.Nb_Lap = 0;
        this.Being_In_Jail = false;
        this.Nb_Throw = 0;
    }


    public Player(string name){
        this.Name = name;
        this.Position = 0;
        this.Nb_Lap = 0;
        this.Being_In_Jail = false;
        this.Nb_Throw = 0;
    }
    public string Name { get => name; set => name = value; }
    public int Position { get => position; set => position = value; }
    public int Nb_Lap { get => nb_Lap; set => nb_Lap = value; }
    public bool Being_In_Jail { get => being_In_Jail; set => being_In_Jail = value; }
    public int Nb_Throw { get => nb_Throw; set => nb_Throw = value; }

    public void Moving(int value){ //Move => Moving
        if(position + value <= 39 ){
            position += value;
        }
        
        else{
            position = (position + value) - 39;
            Nb_Lap++;
        }
    }
}