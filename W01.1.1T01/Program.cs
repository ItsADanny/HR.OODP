String str_lastname;
Char char_firstletter;

Console.WriteLine("Hello. Please enter your last name.");
str_lastname = Console.ReadLine();
Console.WriteLine("What is the initial of your first name?");
char_firstletter = Convert.ToChar(Console.ReadLine());
Console.WriteLine("Welcome to the course, " + char_firstletter + " " + str_lastname + ". We will watch your career with great interest.");