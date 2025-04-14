// Do not modify this file

class User
{
    public readonly string Name;
    public readonly string EmailAddress;
    private readonly List<Email> _inbox = [];
    private readonly List<string> _blockedEmailAddresses = [];

    public User(string name, string emailAddress)
    {
        Name = name;
        EmailAddress = emailAddress;
    }

    public void BlockEmailAddress(string emailAddress) => _blockedEmailAddresses.Add(emailAddress);

    public bool ReceiveEmail(Email email)
    {
        if (_blockedEmailAddresses.Contains(email.From) && email is not AdminEmail)
            return false;

        _inbox.Add(email);
        return true;
    }

    public void PrintInbox()
    {
        if (_inbox.Count == 0)
        {
            Console.WriteLine("Inbox empty\n");
            return;
        }

        foreach (var email in _inbox)
        {
            Console.WriteLine($"From: {email.From}");
            Console.WriteLine($"Subject: {email.Subject}");
            Console.WriteLine($"Body: {email.Body}");
        }
        Console.WriteLine();
    }
}