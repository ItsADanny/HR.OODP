public class Program {
    public static void Main() {
            SleepyTime.Main2();
    }
}

/*
Note: string indent = new string('\t', character);
indent will create a string containing '\t' `character` times, where '\t' is a tab. 
For example new string('\t', 3); would create the string "\t\t\t" (3 tabs)

    - What will the following program print?
    - What is the base case?
    - What will `character` be when the base case is reached?
    - Which line has the recursive call?
    - Do we need the following code? What would happen if we removed it?
    ```
        if(characters == null || characters.Length == 0 || character < 0 || character >= characters.Length)
        {
            return;
        }
    ```
*/
public static class SleepyTime
{
    public static void Main2()
    {
        string[] characters = { "child", "frog", "bear", "weasel" };
        SleepyTime.BedtimeStory(characters, 0);
    }
    public static void BedtimeStory(string[] characters, int character)
    {
        if (characters == null || characters.Length == 0 || character < 0 || character >= characters.Length)
        {
            return;
        }
        string indent = new string('\t', character);
        if (character < characters.Length - 1)
        {
            Console.WriteLine($"{indent}A {characters[character]} couldn't sleep, so her mother told her a story about a little {characters[character + 1]}:");
            BedtimeStory(characters, character + 1);
            Console.WriteLine($"{indent}...and the little {characters[character]} fell asleep;");
        }
        else
        {
            Console.WriteLine($"{indent}who fell asleep");
        }
    }
}