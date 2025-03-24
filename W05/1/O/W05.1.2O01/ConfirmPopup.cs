class ConfirmPopup : Popup
{
    public CoolApplication MyOwner;
    public Button CancelBtn;
    public Button OkBtn;

    public ConfirmPopup(CoolApplication application) : base("Are you sure? (y/n)") {
        MyOwner = application;
        CreateButtons();
    }

    private void CreateButtons()
    {
        CancelBtn = new Button("Cancel", this, sender => Console.WriteLine("Cancelled"));
        OkBtn = new Button("OK", this, sender => MyOwner.ConfirmButtonPressed());
    }

    public override void Display()
    {
        base.Display();
        Console.WriteLine($"{CancelBtn.Text} {OkBtn.Text}");
    }
}
