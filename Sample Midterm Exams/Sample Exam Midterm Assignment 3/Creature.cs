abstract class Creature
{
    private int _weight = 0;
    public virtual int Weight // Change to property (see the class diagram and description)
    {
        get {
            return _weight;
        }
        protected set {
            if (value > 0) {
                _weight = value;
            } else {
                _weight = 0;
            }
        }
    }
    public Creature(int weight) => Weight = weight;

    public virtual void Grow() => Weight++; // Update the method declaration (see the class diagram)

    // Method Eat goes here
    public abstract bool Eat(string food);
}