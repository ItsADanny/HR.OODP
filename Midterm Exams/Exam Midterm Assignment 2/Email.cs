class Email
{
    // Change all fields (except _replySeparator) to properties (see the class diagram)
    public string Body {get; set;}
    private string _subject = "";
    public string Subject {
        get {
            return _subject;
        }
        private set {
            _subject = value.Trim();
        }
    }
    public string From {get;}
    public string To {get;}
    private const string _replySeparator = "\nForwarded message:\n";
   
    public Email(string body, string subject, string from, string to)
    {
        Body = body;
        Subject = subject;
        From = from;
        To = to;
    }

    // Overload the constructor (see the class diagram and the Description)
    private Email(string body, Email replyToEmail)
    {
        Body = body + _replySeparator + replyToEmail.Body;
        Subject = "Re: " + replyToEmail.Subject;
        From = replyToEmail.To;
        To = replyToEmail.From;
    }
    
	public virtual bool Send() // Update the method declaration (see the class diagram)
	{
        User? user = null;
        foreach (User emailUser in EmailProvider.Users) {
            if (emailUser.EmailAddress == To) {
                user = emailUser;
            }
        }

        if (user is not null) {
            return user.ReceiveEmail(this);
        }
        return false;
	}

    // Update the method declaration (see the class diagram)
    public static Email CreateReply(string body, Email replyToEmail) => new Email(body, replyToEmail);

    public override string ToString() // Update the method declaration (see the class diagram)
    {
        return
            $"From: {From}\n" +
            $"To: {To}\n" +
            $"Subject: {Subject}\n" +
            $"Body: {Body}";
    }
}