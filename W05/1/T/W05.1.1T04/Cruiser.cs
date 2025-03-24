public class Cruiser : Motorcycle {
    public int SeatHeight;

    public Cruiser(string make, string model, int year, int seatHeight) : base(make, model, year){
        SeatHeight = seatHeight;
    }

    public override string Ride()
    {
        return base.Ride() + $" with a seat height of {SeatHeight} cm";
    }
}