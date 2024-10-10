public class RentalBoat : IRental {
    public int RentalId { get; }
    public bool IsRentedOut { get; private set; } = false;
    public bool IsEngineOn { get; private set; } = false;

    public RentalBoat(int rentalId) {
        RentalId = rentalId;
    }
    
    public void RentMe() {
        IsRentedOut = true;
    }

    public void ReturnMe() {
        IsRentedOut = false;
    }
}