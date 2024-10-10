interface IRental {
    int RentalId { get; }
    bool IsRentedOut { get; }
    void RentMe();
    void ReturnMe();
}