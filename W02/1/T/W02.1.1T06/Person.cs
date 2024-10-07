class Person
{
    public string FirstName;
    public string LastName;

    public Person(string firstname, string lastname)
    {
        FirstName = firstname;
        LastName = lastname;
    }

    public string Introduce() => $"I am {FirstName} {LastName}";
}