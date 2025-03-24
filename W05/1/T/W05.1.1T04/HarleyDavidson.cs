public class HarleyDavidson : Cruiser {
    public HarleyDavidson(string model, int year) : base("Harley Davidson", model, year, 68) { }

    public override string Ride()
    {
        return base.Ride() + " and with pride.";
    }
}