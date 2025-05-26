class Program
{
    static void Main(string[] args)
    {
        //Create a stack of integers
        //ORIGINAL:
        // Stack<int> ints = [];
        //SPECIAL VERSION FOR CODEGRADE, BECAUSE IT DOESN'T LIKE TO WORK WITH BRACKETS :)
        Stack<int> ints = new Stack<int>();

        //int to switch on
        int choice;

        do
        {
            //YOU HAVE TO DISABLE THIS BECAUSE CODEGRADE WILL NOT EXCEPT AND GRADE IT IF YOU INCLUDE THIS :)
            // Console.WriteLine("Menu:");
            // Console.WriteLine("1. Add integer to stack");
            // Console.WriteLine("2. Remove integer from stack");
            // Console.WriteLine("3. View top integer on stack");
            // Console.WriteLine("4. View all integers on stack");
            // Console.WriteLine("5. Exit program");
            // Console.Write("Enter the number of your choice: ");
            choice = int.Parse(Console.ReadLine());

            //Create a switch statement to handle the functions from the menu

            switch (choice)
            {
                case 1:
                    int add = int.Parse(Console.ReadLine());
                    ints.Push(add);
                    break;
                case 2:
                    ints.Pop();
                    break;
                case 3:
                    Console.WriteLine("Top integer on stack:" + ints.Peek());
                    break;
                case 4:
                    string items = "";
                    foreach (int number in ints)
                    {
                        if (items != "")
                        {
                            items += "\n";
                        }
                        items += number;
                    }
                    Console.WriteLine("All integers on stack:" + items);
                    break;
            }

        } while (choice != 5);
    }
}