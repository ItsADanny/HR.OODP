public interface ICredential {
    public string Expected {get;}
    public string Actual {get;}

    public void EnterCredential(string credential);
    public bool IsEnteredCredentialCorrect();
}