class Bird : Creature, IFly
{
    public int Altitude {get; set;} = 0;
    private static readonly List<string> _foodsILike = ["Worm", "Seed", "Insect"];
    private int _weight = 0;
    public override int Weight // Change to a property (see the class diagram and description)
    {
        get {
            return _weight;
        }
        protected set {
            _weight = Math.Clamp(value, 0, 20);
        }
    } 

    public void Fly() {
        Altitude++;
    }

    public void Land() {
        Altitude = 0;
    }

    public Bird(int weight) : base(weight)
    {
        Weight = weight;
    }

    public override void Grow()
    {
        Weight+=3;
    }

    public override bool Eat(string food)
    {
        if (_foodsILike.Contains(food)) {
            Grow();
            return true;
        }
        return false;
    }
    
    public static void Sing()
    {
        Console.WriteLine("Chirp chirp");
    }
}