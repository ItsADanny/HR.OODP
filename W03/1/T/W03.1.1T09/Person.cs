class Person
{
    //Name is a readonly field because names don't normally change
    public readonly string Name;
    public int Age;

    public Person(string name)
    {
        Name = name;
        Age = 0;
    }

    public void GrowOlder() => Age++;
}