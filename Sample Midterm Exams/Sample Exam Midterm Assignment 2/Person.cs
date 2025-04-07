class Person
{
    public virtual string Name {get;}
    private int _age = 0;
    public int Age 
    {
        get
        {
            return _age;
        }
        private set 
        {
            if (value > 0) {
                _age = value;
            }  
        }
    }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void GrowOlder() => Age++;

    public override string ToString() => $"Name: {Name}\nAge: {Age}";
}