using System;

public class Dice{
    int dice_1; 
    int dice_2; 

    public Dice(){}

    public int First_Dice { get => dice_1; set => dice_1 = value; } 
    public int Second_Dice { get => dice_2; set => dice_2 = value; } 

    public int[] Throw_Dice(){ 
        Random random_value = new Random();
        First_Dice = random_value.Next(1, 7);
        Second_Dice = random_value.Next(1, 7);
        int[] dice = { First_Dice, Second_Dice };
        return dice;
    }
}
