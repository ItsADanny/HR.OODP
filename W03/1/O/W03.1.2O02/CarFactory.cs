//We then create a class called CarFactory which will be producing our cars
class CarFactory {
    //We create an integer that is readonly so that when a factory is created it can only produce cars up to
    //The amount we assigned to that factory object when we created the factory
    public readonly int AllowedCarAmount;

    //In the constructor of the factory we assign the amount of cars the factory is allowed to create
    public CarFactory (int car_amount) {
        AllowedCarAmount = car_amount;
    }

    //We then make a method which we can use to produce a Limited Edition Car
    //After creation we return our new Limited Edition Car
    public LimitedEditionCar ProduceLimitedEditionCar() {
        //We check if we have reached the amount of cars we are allowed to produce
        if (AllowedCarAmount != LimitedEditionCar.Counter) {
            //If we haven't reaced that amount then we produce a new car and return it
            return new LimitedEditionCar();
        }
        //If we aren't allowed to produce anymore cars then we return a null value
        return null;
     }

}