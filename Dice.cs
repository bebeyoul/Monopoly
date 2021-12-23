using System;

public class Dice{
    int dice_1; // Dice_1 => dice_1
    int dice_2; // Dice_2 => dice_2

    public Dice(){}

    public int First_Dice { get => dice_1; set => dice_1 = value; } // First_Dice
    public int Second_Dice { get => dice_2; set => dice_2 = value; } // Second_Dice

    public int[] Throw_Dice(){ // Throwing_Dice
        Random random_value = new Random(); // random_value
        First_Dice = random_value.Next(1, 7);
        Second_Dice = random_value.Next(1, 7);
        int[] dice = { First_Dice, Second_Dice };
        return dice;
    }
}