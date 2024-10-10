class RentalSailboat : IRental {
    public int RentalId { get; }
    public bool IsRentedOut { get; private set; } = false;

    public RentalSailboat(int rentalId) {
        RentalId = rentalId;
    }

    public void RentMe() {
        IsRentedOut = true;
    }

    public void ReturnMe() {
        IsRentedOut = false;
    }
}