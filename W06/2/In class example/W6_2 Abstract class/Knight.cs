public class Knight {
    public string Name {get;}
    public int X {get; private set;}
    public int Y {get; private set;}
    public string CurrentPosition {get { return $"({X}, {Y})";}}
    public string Ascii
    {
        get {
            if (CurrentHitPoints > 0) {
                return "{._.} -{---";
            }
            return "{-_-}";
        }
    }
    private readonly int _maximumHitPoints;
    private int _currentHitPoints;
    public int CurrentHitPoints {
        get {
            return _currentHitPoints;
        }
        private set {
            if (value >= 0 && value <= _maximumHitPoints) {
                _currentHitPoints = value;
            }
        }
    }
    public Weapon EquippedWeapon;
    private static Random _randomGenerator {get {return new Random();}}

    public Knight(string name, int maximumHitPoints, Weapon equippedWeapon) {
        Name = name;
        _maximumHitPoints = maximumHitPoints;
        CurrentHitPoints = _maximumHitPoints;
        EquippedWeapon = equippedWeapon;
    }

    public void MoveLeft(int amount) => X -= amount;
    public void MoveRight(int amount) => X += amount;
    public int Attack() => _randomGenerator.Next(EquippedWeapon.Strength) + 1;
    public void Defend(int damageAmount) {
        if(_randomGenerator.Next(1, 2) == 1) {
            CurrentHitPoints -= damageAmount;
        }
    }
}