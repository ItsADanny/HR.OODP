public class Program
{
    public static void Main()
    {
        //An abstract class is a class from which no instances can be created on their own.
        //When the line below is uncommented you will get the following error:
        //"Cannot create an instance of the abstract type or interface 'Animal'"

        // Animal animal = new Animal();

        //However, you can make a List that can contain Animal based classes. Such as Dog and Cat
        List<Animal> animals = new List<Animal>();

        //We can create objects from classes based on our abstract Animal class
        Dog Sem = new Dog("Sem", 45);
        Cat Kroepie = new Cat("Kroepie");

        //And we can add them both to our List<Animal>
        animals.Add(Sem);
        animals.Add(Kroepie);

        //Now we can use Animals in a foreach loop to get our animals
        foreach (Animal animal in animals)
        {
            //We can perform checks on the object to see if its an Dog
            if (animal is Dog)
            {
                //We can cast our Animal object into Dog object
                Dog dog = (Dog)animal;

                //We can use the non-abstract methods we declared in our abstract class as normal
                dog.Define();
                //We can also use our overwriten method that we create based on the abstract method from the Animal class
                dog.MakeSound();
                //And finally our unique method from our Dog class
                dog.Run();
            }

            //We can perform checks on the object to see if its an Cat
            if (animal is Cat)
            {
                //We can cast our Animal object into Cat object
                Cat cat = (Cat)animal;

                //We can use the non-abstract methods we declared in our abstract class as normal
                cat.Define();
                //We can also use our overwriten method that we create based on the abstract method from the Animal class
                cat.MakeSound();
                //And finally our unique method from our cat class
                cat.Clean();
            }
        }
    }
}

//To define a abstract class we use "Abstract" infront of our "class"
public abstract class Animal
{
    //An abstract class can have its own values, which can hold data
    public string Name;
    public string Species;
    public string Sound;

    //We can define a initializer for an animal object, but we can't create an animal object directly
    public Animal(string name, string species, string sound)
    {
        Name = name;
        Species = species;
        Sound = sound;
    }

    //We can create an abstract method which needs to be overwriten in any class which derives/inherits from this class
    public abstract void MakeSound();

    //But we can also create standard methods which will work on any object which derives/inherits from this class
    public void Define()
    {
        Console.WriteLine($"Name: {Name}, Species: {Species}");
    }
}

public class Dog : Animal
{
    public int TopSpeed;

    public Dog(string name, int topSpeed) : base(name, "Dog", "Woof")
    {
        TopSpeed = topSpeed;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Sound}! {Sound}!");
    }

    public void Run()
    {
        Console.WriteLine($"{Name}, is running at his/her top speed of {TopSpeed}");
    }
}

public class Cat : Animal
{
    public Cat(string name) : base(name, "Cat", "Meow") { }

    public override void MakeSound()
    {
        Console.WriteLine(Sound);
    }

    public void Clean()
    {
        Console.WriteLine($"{Name} is cleaning his/her -self");
    }
}