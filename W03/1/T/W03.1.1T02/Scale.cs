//Create the class Scale
class Scale {
    //Then create a field that will be initialized as true
    public bool UseKg = true;

    //A constructor will not be needed because we won't do anything
    //in it but we will still write it just incase
    public Scale() { }

    //Now create a method that will return an inputted double and
    //return it but then with a multiplier of 2.2
    public static double ConvertKgToLbs(double weight) => weight * 2.2;

    //Now create a method that will return a string with the weight based on the bool UseKg variable
    public string DisplayWeight(double weight) {
        if (UseKg) {
            return $"{weight} kg";
        } else {
            return $"{ConvertKgToLbs(weight)} lbs";
        }
    }
}