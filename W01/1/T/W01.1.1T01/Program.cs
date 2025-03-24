static class Program
{
    /* 
    'static void Main': your program starts here.
    The Python equivalnt is:
    if __name__ == '__main__':
        main()
    */

    static void Main()
    {
        Console.WriteLine("Hello. Please enter your last name.");
        string str_lastname = Console.ReadLine();
         Console.WriteLine("What is the initial of your first name?");
        char char_firstletter = Convert.ToChar(Console.ReadLine());
         Console.WriteLine("Welcome to the course, " + char_firstletter + " " + str_lastname + ". We will watch your career with great interest.");
    }
}