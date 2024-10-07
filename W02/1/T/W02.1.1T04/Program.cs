//ORIGINAL CODE
//=========================================================================
// class Program
// {
//     public static void Main()
//     {
//         int maxHP = 10;
//         int currHP = 5;

//         currHP = DrinkPotion(currHP, maxHP);
//         DisplayStatus(currHP);

//         currHP = TakeDamage(currHP, 15);
//         DisplayStatus(currHP);
//     }

//     public static string DisplayStatus(int currHP)
//     {
//         Console.WriteLine($"Current HP: {currHP}{(currHP <= 0 ? " (Dead)" : "")}");
//     }

//     public static void DrinkPotion(int currHP, int maxHP) => Minimum(currHP + 10, maxHP);
//     public static void TakeDamage(int currHP, int damage) => Maximum(currHP - damage, 0);

//     public static bool Minimum(int n1, int n2) => n1 < n2 ? n1 : n2;
//     public static bool Maximum(int n1, int n2) => n1 > n2 ? n1 : n2;
// }
//=========================================================================

class Program
{
    public static void Main()
    {
        int maxHP = 10;
        int currHP = 5;

        currHP = DrinkPotion(currHP, maxHP);
        DisplayStatus(currHP);

        currHP = TakeDamage(currHP, 15);
        DisplayStatus(currHP);
    }

    //Set DisplayStatus from string to void
    public static void DisplayStatus(int currHP)
    {
        Console.WriteLine($"Current HP: {currHP}{(currHP <= 0 ? " (Dead)" : "")}");
    }

    //Set both DrinkPotion and TakeDamage from void to int
    public static int DrinkPotion(int currHP, int maxHP) => Minimum(currHP + 10, maxHP);
    public static int TakeDamage(int currHP, int damage) => Maximum(currHP - damage, 0);

    //Set both Minimum and Maximum from bool to int
    public static int Minimum(int n1, int n2) => n1 < n2 ? n1 : n2;
    public static int Maximum(int n1, int n2) => n1 > n2 ? n1 : n2;
}