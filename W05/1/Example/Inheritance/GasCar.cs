class GasCar : Car {

    //Met private kan maak je een variable wat beschermder voor manupilatie van buiten af.
    //Met private maak je het namelijk zo dat je hem niet van buiten de class kan bereiken.
    public int GasLeft = 0;

    public GasCar(string make, string name) : base(make, name) {

    }

    public void Refuel () => GasLeft = 100;

    //Door override neer te zetten in de method geven wij aan dat hij een method 
    //kan overschrijven van de Class waarop deze Class gebaseerd is
    public override void Drive() {
        //Maar stel dat we alsnog de overschreven functie van de Class waarop deze gebasseerd is willen gebruiken
        //dan kan je met base. alsnog gebruik maken van de originele method
        base.Drive();
        if (GasLeft > 0) {
            GasLeft--;
        }
    }
}