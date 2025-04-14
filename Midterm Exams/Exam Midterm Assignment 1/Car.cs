public class Car {
    public readonly string Make;
    public readonly string Model;
    public string LicensePlate = null;
     public const int LicensePlateRequiredLength = 6;
    public readonly int ID;
    public static int Counter = 0;

    public Car(string make, string model) {
        Counter++;
        ID = Counter;
        Make = make;
        Model = model;
    }

    public bool SetLicensePlate(string licensePlate) {
        if (licensePlate.Length == LicensePlateRequiredLength) {
            LicensePlate = licensePlate;
            return true;
        }
        return false;
    }

    public string GetInfo() {
        if (LicensePlate is not null) {
            return $"{Make} {Model} [{LicensePlate}]";
        }
        return $"{Make} {Model} [None]";
    }
}