class Program {
    static void Main() {
        List<string> TaskList = new();

        PrintList(TaskList);

        TaskList.Add("Mow lawn");
        TaskList.Add("Pay taxes");

        PrintList(TaskList);

        TaskList.Remove("Mow lawn");
        TaskList.Add("Shopping");

        PrintList(TaskList);
    }

    //You can simply use the code inside to print it every time
    //But i wanted to use a function to make it look cleaner
    static void PrintList(List<string> listToPrint) {
        Console.WriteLine($"Amount of tasks: {listToPrint.Count()}");
        foreach (string item in listToPrint) {
            Console.WriteLine(item);
        }
    }
}