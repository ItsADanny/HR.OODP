class FlyControl
{
    public static readonly List<IFly> Flyables = [];
    //This had to be fixed because it used an older version of this assignments Interface class
    public static void AddFlyable(IFly flyable) => Flyables.Add(flyable);
    
    public static void CommandFly()
    {
        foreach (IFly flyingThing in Flyables) {
            flyingThing.Fly();
        }
    }

    public static void CommandLand()
    {
        foreach (IFly flyingThing in Flyables) {
            flyingThing.Land();
        }
    }
}