public abstract class Account
{
    public readonly string HolderName;
    public readonly Password MyPassword;
    public string EnteredHolderName { get; private set; } = "";
    public bool IsAuthenticated { get; protected set; } = false;

    protected Account(string holderName, string password)
    {
        HolderName = holderName;
        MyPassword = new(password);
    }

    public void PasswordLogin(string enteredHolderName, string enteredPassword)
    {
        EnteredHolderName = enteredHolderName;
        MyPassword.EnterCredential(enteredPassword);

        Authenticate();
    }

    // Add methods Authenticate and PrintInfo
    protected abstract void Authenticate();

    public abstract void PrintInfo();
}