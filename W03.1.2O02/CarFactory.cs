class CarFactory {
    public readonly int AllowedCarAmount;


    public CarFactory (int car_amount) {
        AllowedCarAmount = car_amount;
    }

    public LimitedEditionCar ProduceLimitedEditionCar() {
        if (AllowedCarAmount != LimitedEditionCar.Counter) {
            return new LimitedEditionCar();
        }
        return null;
    }

}