// Make this class implement the interface and its methods

class Password : ICredential
{
    public const int MinPasswordLength = 3;
    public string Expected { get; }
    public string Actual { get; private set; } = "";

    public Password(string expected)
    {
        ArgumentNullException.ThrowIfNull(expected);
        if (expected.Length < MinPasswordLength)
            throw new ArgumentException("Password must be at least 8 characters long");

        Expected = expected;
    }

    public void EnterCredential(string credential) => Actual = credential;

    public bool IsEnteredCredentialCorrect() {
        if (Actual == Expected) {
            return true;
        }
        return false;
    }
}