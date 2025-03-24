class ProgressPopup : Popup
{
    private int _progress = 0;
    private string _progressBar = "";

    public ProgressPopup(string message) : base(message) => Display();

    public void IncreaseProgress(int amount) {
        if ((amount + _progress) <= 100) {
            _progress += amount;
        } else {
            _progress = 100;
        }

        Display();
    }

    public override void Display()
    {
        base.Display();
        
        int progressAmount = (int) Convert.ToDouble(_progress) % 10;
        _progressBar = "";
        for (int i = 0; i != progressAmount; i++) {
            _progressBar += "|";
        }
        Console.WriteLine($"{_progress}%\t{_progressBar}");
    }
}
