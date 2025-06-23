public class Program
{
    public static void Main()
    {
        //!IMPORTANT!
        //First read the part about Interfaces below in the interface IAnimal and then move on to the classes below it.
        //Then come back here for a little more information and how you can use interfaces in a List or Array

        //You can use interfaces to define a array in which all the objects that implemented your interface can be stored into
        IAnimal[] animalShelter = [
            new Bird("Twitter"),
            new Bird("Big Red"),
            new Bird("Klaus"),
            new Cat("Harry the Magical Wizard"),
            new Cat("Kroepie"),
            new Cat("Beer")
        ];

        List<IAnimal> PetsAtHome = [
            new Bird("Boring"),
            new Bird("Jochem"),
            new Dog("Sem"),
            new Cat("Mini Mo"),
            new Cat("Whiskas"),
            new Cat("Lappie"),
            new Cat("Beer")
        ];

        Console.WriteLine("At our home we have:");
        //We can the also use it to store a object that has implemented our interface class
        foreach (IAnimal animal in PetsAtHome)
        {
            //Since we used an interface we can just call the method that is defined in our interface and it will 
            //result in the unique methods for each of our classes that used our interface
            animal.MakeSound();
        }
    }
}

public interface IAnimal
{
    //An interface is a contract with declerations which a class that must implement.
    //any classes that use this interface must implement all of its declerations.

    public String Name { get; set; }
    public String Sound { get; }

    public void MakeSound();
}

//When you uncomment the lines below you will see that for the implementation of IAnimal we will need to declare its properties and its method
// public class Camal : IAnimal
// {

// }

//When implmenting an interface to a class, it is required that you implement it exactly as i is layed out in the interface class.
//Otherwise you will receive an error message with the message that the item hasn't been implemented. You can see this by uncommeting to lines below
// public class Snake : IAnimal
// {
//     public String Name { get; set; }
//     public String Sound;
// }

public class Dog : IAnimal
{
    //When you implemented everything as it should then you will receive now warnings or error and can use the class as intended
    public String Name { get; set; }
    public String Sound { get; set; }

    public Dog(string name, string sound = "Woof")
    {
        Name = name;
        Sound = sound;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} the dog says: {Sound}! {Sound}! to the mailman");
    }
}

public class Cat : IAnimal
{
    //When you implemented everything as it should then you will receive now warnings or error and can use the class as intended
    public String Name { get; set; }
    public String Sound { get; set; }

    public Cat(string name, string sound = "Meow")
    {
        Name = name;
        Sound = sound;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} the cat says: {Sound}");
    }
}

public class Bird : IAnimal
{
    public String Name { get; set; }
    public String Sound { get; set; }

    public Bird(string name, string sound = "Chirp")
    {
        Name = name;
        Sound = sound;
    }

    public void MakeSound()
    {
        Console.WriteLine($"{Name} the bird: {Sound} {Sound}");
    }
}

