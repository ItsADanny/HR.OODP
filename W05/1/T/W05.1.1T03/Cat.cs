//We create the class Cat, which inherits/is derived from the class Animal
public class Cat : Animal {

    //We set the name of our Dog using the base initializer from the Animal class
    public Cat(string name) : base(name) {
        //And we set the sound field to "Meow!" using the Cat initializer because
        //All Cats will make the sound "Meow!" (So this is something unique to all the Dog objects)
        Sound = "Meow!";
    }

    //We create a method called Climb() which is a unique method to the Dog class.
    //The method takes no parameters and just Writes a line to our Console/Terminal with the line:
    //"[NAME OF THE CAT] climbs the curtains"
    public void Climb() => Console.WriteLine($"{Name} climbs the curtains");
}