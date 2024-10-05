class Ventilator
{
    public int Speed;
    public List<Button> Buttons;

    public Ventilator() => Buttons = new List<Button>()
        { new Button(), new Button(), new Button(), new Button() };

    public void PressButton(int number)
    {
        //We then need to make a small change to our PressButton method
        //We begin by checking to see if our current number is higher or equal to 0
        if (number >= 0) {
            //If it is Higer or equal to four
            //We check to see if the number is lower then 4
            if (number < 4) {
                //If its lower then four then we can use the Loop below to change the speed
                for (int i = 0; i < Buttons.Count; i++)
                {
                    Buttons[number].IsPressed = number != i || number == 0;
                    Speed = number;
                }
            }
        } else {
            //If its not then we exit this method by using return
            return;
        }
    }

    public string Blow() => Speed switch
    {
        <= 0 => "Off",
        1 => "~~~",
        2 => "^^^",
        >= 3 => "===",
    };
}