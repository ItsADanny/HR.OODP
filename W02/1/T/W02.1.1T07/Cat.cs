class Cat
{
    public string Name;

    //ORIGINAL CONSTRUCTOR
    //==================================================
    // public Cat(string Name)
    // {
    //     Name = Name;
    // }
    //==================================================

    //You can solve this two ways.
    //By using this.Name
    // public Cat(string Name)
    // {
    //     this.Name = Name;
    // }

    //Or by setting the name in between the N in the brackets to
    //a lower case n and set the Name in the method to name
    public Cat(string name)
    {
        Name = name;
    }

    
}