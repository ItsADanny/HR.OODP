class Person
{
    //ORIGINAL PART OF THE TEMPLATE, THIS WOULDN'T WORK WITH THE Program.cs BECAUSE IT USES .Introduce STILL
    public string GetIntroduction() => $"I am {FirstName} {LastName}";

    public string FirstName;
    public string LastName;

    public Person(string firstname, string lastname)
    {
        FirstName = firstname;
        LastName = lastname;
    }

    //Program.cs STILL CALLS THIS VERSION OF THE METHOD AND NOT THE ONE REQUIRED BY THE AUTO-CHECK FUNCTION OF CODEGRADE
    public string Introduce() => $"I am {FirstName} {LastName}";
}