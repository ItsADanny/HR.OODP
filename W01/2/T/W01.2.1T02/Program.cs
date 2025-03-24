static class Program
{
    public static void Main()
    {
        var fileList = new List<string>() {
            "OODP assignment.docx",
            "Project Presentation.pptx",
            "TODO list.xlsx",
        };

        string whichFileToDelete = fileList[0];

        Console.WriteLine("File selected to delete: " + whichFileToDelete);

        bool exit = false;
        bool confirm = false;

        do {
            Console.WriteLine("Really delete this file? (y/n)");
            string input = Console.ReadLine();

            if (input == "y") {
                exit = true;
                confirm = true;
            } else if (input == "n") {
                exit = true;
            }
        } while (!exit);

        if (confirm) {
            fileList.Remove(whichFileToDelete);
            Console.WriteLine("File deleted");
        }
    }
}