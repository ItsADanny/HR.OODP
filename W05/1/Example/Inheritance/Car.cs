class Car {
    public readonly string Make;
    public readonly string Model;
    public bool HasFreshTires = true;

    public Car(string make, string model) {
        Make = make;
        Model = model;
    }

    //Normaal maken we een method die 
    // public void Drive() {
    //     HasFreshTires = false;
    // }

    //Met virtual kan je een method maken die overschreven kan worden door 
    //een nieuwe method in een class die gebaseerd is op deze class
    public virtual void Drive() {
        HasFreshTires = false;
    }

    public void PreformMaintance() {
        HasFreshTires = true;
    }

    //In python gebruiken je dit als je een overzicht wilt geven van wat een class
    //is inplaats van zijn plaats in het geheugen
    //def __str()__:
    //  return f"Make: {Make}; Model: {Model}"

    //Dit zelfde heb je ook in C#, Hierbij overschrijf je de standaard ToString voor deze class en vervang je hem
    //Met je eigen ToString method.
    public override string ToString()
    {
        return $"Make: {Make}; Model: {Model}";
    }
}