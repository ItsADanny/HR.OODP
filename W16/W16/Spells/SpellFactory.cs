enum SpellTypes
{
    Heal,
    Blizzard,
    ChargedBolt,
    CrystalShards,
    Drain,
    EarthSlide,
    FireBolt,
    IceBolt,
    Meteor,
    Vortex,
    Teleport
}

static class SpellFactory
{
    public static Spell? GetSpell(SpellTypes spellType) => spellType switch
    {
        SpellTypes.Heal => new Heal(),
        SpellTypes.Blizzard => new Blizzard(),
        SpellTypes.ChargedBolt => new ChargedBolt(),
        SpellTypes.CrystalShards => new CrystalShards(),
        SpellTypes.Drain => new Drain(),
        SpellTypes.EarthSlide => new EarthSlide(),
        SpellTypes.FireBolt => new FireBolt(),
        SpellTypes.IceBolt => new IceBolt(),
        SpellTypes.Meteor => new Meteor(),
        SpellTypes.Vortex => new Vortex(),
        SpellTypes.Teleport => new Teleport(),
        _ => throw new ArgumentException($"Unknown spell: {spellType}"),
    };
}
