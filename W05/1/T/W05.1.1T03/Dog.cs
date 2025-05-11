//We create the class Dog, which inherits/is derived from the class Animal
public class Dog : Animal {

    //We set the name of our Dog using the base initializer from the Animal class
    public Dog(string name) : base(name) {
        //And we set the sound field to "Woof!" using the Dog initializer because
        //All Dogs will make the sound "Woof!" (So this is something unique to all the Dog objects)
        Sound = "Woof!";
    }

    //We create a method called Fetch() which is a unique method to the Dog class.
    //The method takes no parameters and just Writes a line to our Console/Terminal with the line:
    //"[NAME OF THE DOG] fetches the stick"
    public void Fetch() => Console.WriteLine($"{Name} fetches the stick");
}