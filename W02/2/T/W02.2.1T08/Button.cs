//Create the class Button
class Button {
    //Create two field in the class button
    //1 boolean to indicate if the button is currently pressed
    //This will start with a default value of false
    public bool IsPressed = false;
    //1 int to indicate how many times the button has been pressed
    //This will start with a default value of 0
    public int TimesPressed = 0;

    //The constructor doesn't need to be written because it will do
    //Nothing but we will write it anyway
    public Button() { }

    //Create a method to press the button
    //This will switch the IsPressed value from false to true and vice versa
    //and increase the TimesPressed value by 1
    public void Press() {
        if (IsPressed) {
            IsPressed = false;
        } else {
            IsPressed = true;
        }

        TimesPressed++;
    }

    //Create a method that will return the state of the button
    //(If its pressed currently and how many times it has been pressed)
    public string Info() {
        string returnValue = "";
        if (IsPressed) {
            returnValue += "Button is pressed.\n";
        } else {
            returnValue += "Button is not pressed.\n";
        }
        returnValue += $"Pressed {TimesPressed} times.";
        return returnValue;
    }
}