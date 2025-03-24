class CoolApplication
{
    public Button DoSomethingBtn;

    public CoolApplication()
    {
        CreateApplication();
        Popup welcome = new("Welcome to this awesome app!");
        welcome.Show();
    }

    //Set this method to private (from public)
    private void CreateApplication()
    {
        DoSomethingBtn = new Button("Do something cool!", this, sender => HandleConfirm());
    }

    //Set this method to private (from public)
    private void HandleConfirm()
    {
        ConfirmPopup confirmPopup = new ConfirmPopup(this);
        Console.WriteLine(confirmPopup.Message);

        string input;
        do
        {
            input = Console.ReadLine().ToLower();
        }
        while (input != "y" && input != "n");
        if (input == "n")
            confirmPopup.CancelBtn.Press();
        else
            confirmPopup.OkBtn.Press();
    }

    public void CancelButtonPressed()
    {
        Console.WriteLine("Operation cancelled.");
    }

    public void ConfirmButtonPressed()
    {
        Console.WriteLine("Operation confirmed.");
        FormatHardDrive();
    }

    //Set this method to private (from public)
    private void FormatHardDrive()
    {
        ProgressPopup progressPopup = new("Formatting hard drive...");
        int hardDiskVolumePercentage = 100;
        int percentageChange = 15;

        while (hardDiskVolumePercentage > 0)
        {
            hardDiskVolumePercentage -= percentageChange;
            progressPopup.IncreaseProgress(percentageChange);
        }
    }
}
