class Bicycle
{
    public Person Owner;
    //The FrameNumber must be readonly, because a FrameNumber must always be unique to the bike.
    //Everything else can change but a frame will always be the same number from creation until it is scraped
    public readonly string FrameNumber;
    public int CurrentGear;
    public string Color;

    public Bicycle(Person owner, string number, string color)
    {
        Owner = owner;
        FrameNumber = number;
        Color = color;
        CurrentGear = 1;
    }

    public void ChangeOwner(Person newOwner) => Owner = newOwner;
    public void ChangeGear(int gear) => CurrentGear = gear;
    public void Paint(string color) => Color = color;
}