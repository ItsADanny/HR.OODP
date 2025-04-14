class AdminEmail : Email
{
    public static readonly List<string> LoggedEmails = [];

    // Finish the constructor (see the class diagram and the Description)
    public AdminEmail(string body, string subject, string to) : base(body, subject, "admin@hr.nl", to) { }

    public override bool Send() // Update the method declaration (see the class diagram)
    {
        User? user = null;
        foreach (User emailUser in EmailProvider.Users) {
            if (emailUser.EmailAddress == To) {
                user = emailUser;
            }
        }

        if (user is not null) {
            bool succesfull = user.ReceiveEmail(this);
            if (succesfull) {
                LoggedEmails.Add(this.ToString());
            }

            return succesfull;
        }
        return false;
    }
}