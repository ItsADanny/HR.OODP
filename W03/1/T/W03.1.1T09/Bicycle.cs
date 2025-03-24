class Bicycle
{
    public string OwnerName;
    //The FrameNumber must be readonly, because a FrameNumber must always be unique to the bike.
    //Everything else can change but a frame will always be the same number from creation until it is scraped
    public readonly string FrameNumber;
    public string PaintColor;
    public int CurrentGear = 1;

    public Bicycle(string ownerName, string frameNumber, string paintColor)
    {
        OwnerName = ownerName;
        FrameNumber = frameNumber;
        PaintColor = paintColor;
    }

    public void ChangeOwner(string ownerName) => OwnerName = ownerName;
    public void ChangePaintColor(string paintColor) => PaintColor = paintColor;
    public void ChangeGear(int gear) => CurrentGear = gear;
}