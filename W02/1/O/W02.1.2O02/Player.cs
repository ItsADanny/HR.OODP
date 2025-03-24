class Player
{
    public Location CurrentLocation;
    public Player(Location startLocation) => CurrentLocation = startLocation;

    public bool TryMoveTo(Location newLocation)
    {
        if (newLocation == null) { return false; }

        CurrentLocation = newLocation;
        return true;
    }
}