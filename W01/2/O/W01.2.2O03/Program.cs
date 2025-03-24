//ORIGINAL TEMPLATE
//==================================================================================================
// using System;

// class Program
// {
//     public static void Main()
//     {
//         Fighter you = new Fighter();
//         Fighter enemy = new Fighter();

//         //Correct the code below
//         for (int turnsTaken = 0; turnsTaken < 3; turnsTaken++)
//         {
//             enemy.Health -= you.Attack();
//         }
//         //Correct the code above

//         /*
//          * How many turns did it take you to defeat the enemy?
//          * HINT: variable `i` is not in this scope;
//          * can you change the code, so that it stays in scope?
//          * There's also various other methods to fix this; any method is fine!
//          */
//         Console.WriteLine($"The enemy's HP was reduced to {enemy.Health}");
//         Console.WriteLine($"It took you {turnsTaken} to defeat the enemy");
//     }
// }
//==================================================================================================

using System;

class Program
{
    public static void Main()
    {
        //To fix this code we are going to put our turnsTaken variable outside of the scope.
        //This is so that we can use the amount of turns it took outside of our times need to fight
        int turnsTaken = 0;
        Fighter you = new Fighter();
        Fighter enemy = new Fighter();

        //Now that we have done that we can leave the first part empty of our for-loop and the program will work as intended without any errors
        for (; turnsTaken < 3; turnsTaken++)
        {
            enemy.Health -= you.Attack();
        }
        //Correct the code above

        /*
         * How many turns did it take you to defeat the enemy?
         * HINT: variable `i` is not in this scope;
         * can you change the code, so that it stays in scope?
         * There's also various other methods to fix this; any method is fine!
         */
        Console.WriteLine($"The enemy's HP was reduced to {enemy.Health}");
        Console.WriteLine($"It took you {turnsTaken} to defeat the enemy");
    }
}