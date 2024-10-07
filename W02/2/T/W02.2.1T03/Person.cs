using System;

class Person
{
    public string Name;
    public Animal Pet;

    public Person(string name, Animal pet)
    {
        Name = name;
        Pet = pet;
    }
    public string Info()
    {
        //Solution: Just invert the info's and set the if statement so that
        //it will only update the field if there is an pet
        var info = $"{Name} has no pet";
        if (Pet != null)
            info = $"{Name} has a pet that makes the sound {Pet.MakeSound()}";
        return info;
    }
}