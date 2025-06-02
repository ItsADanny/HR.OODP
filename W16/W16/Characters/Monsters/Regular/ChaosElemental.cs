class ChaosElemental : Monster
{
    public int ElementalRotation = 0;
    public override int ResistFire => ElementalRotation % 3 == 0 ? 100 : 0;
    public override int ResistCold => ElementalRotation % 3 == 1 ? 100 : 0;
    public override int ResistLightning => ElementalRotation % 3 == 2 ? 100 : 0;

    public ChaosElemental() : base("Chaos Elemental", 10, 0, 0) { }

    public override void Attack(ITargetable target)
    {
        SpellTypes spellType = ElementalRotation switch
        {
            0 => SpellTypes.FireBolt,
            1 => SpellTypes.IceBolt,
            2 => SpellTypes.ChargedBolt,
            _=> throw new InvalidOperationException("Unexpected ElementalRotation value")
        };

        Spell? spell = SpellFactory.GetSpell(spellType);
        spell?.CastMe(this, target);
        ElementalRotation = (ElementalRotation + 1) % 3;
    }
}
