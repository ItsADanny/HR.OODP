using System.Reflection;

static class TestCrate
{
    public static void Where()
    {
        string methodName = "IsLootedBy";
        MethodInfo? methodInfo = typeof(Crate).GetMethod(methodName);
        Type[] genericArguments = methodInfo.GetGenericArguments();

        foreach (Type genericArgument in genericArguments)
        {
            Type[] constraints = genericArgument.GetGenericParameterConstraints();
            Console.WriteLine($"Method '{methodName}' constraints:");
            foreach (var constraint in constraints)
                Console.WriteLine($" - {constraint.Name}");
        }
    }
    
    public static void Functionality()
    {
        Crate crate1 = new(new Dictionary<ItemTypes, int>() {
            { ItemTypes.Potion, 2 },
            { ItemTypes.HighPotion, 1 }});

        Crate crate2 = new(new Dictionary<ItemTypes, int>() {
            { ItemTypes.Shuriken, 1 },
            { ItemTypes.FireScroll, 1 },
            { ItemTypes.Grenade, 2 }});

        Ninja ninja = new("Sneaky Shadowblade");
        ninja.Attack(crate1);
        crate1.IsLootedBy(ninja);

        ninja.Attack(crate2);
        crate2.IsLootedBy(ninja);

        Program.PrintStats(ninja, true);
    }
}
