class Fighter
{
    public int Health;
    private int _attack;

    public Fighter()
    {
        Health = 30;
        _attack = 10;
    }

    public int Attack() => _attack;
}