// Do not modify this class

static class CodeGradeTests
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Constructors": TestConstructors(); return;
            case "Inheritance": TestInheritance(); return;
            case "Encapsulation": TestEncapsulation(); return;
            case "TrimSubject": TestTrimSubject(); return;
            case "SendRegular": TestSendRegularEmail(); return;
            case "Reply": TestReply(); return;
            case "SendAdmin": TestSendAdminEmail(); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestConstructors()
    {
        // This is part polymorphism (overloading), part encapsulation (access modifiers)
        TestUtils.CheckConstructorsCorrect(typeof(Email));
        Console.WriteLine();
        TestUtils.CheckConstructorsCorrect(typeof(AdminEmail));
    }

    public static void TestEncapsulation()
    {
        Type clsType = typeof(Email);
        TestUtils.PrintAreAccessModFieldCorrect(clsType, "_replySeparator", "Private");
        TestUtils.PrintAreAccessModsPropertyCorrect(clsType, "Body", "Public", "Public");
        TestUtils.PrintAreAccessModsPropertyCorrect(clsType, "Subject", "Public", "Private");
        TestUtils.PrintAreAccessModsPropertyCorrect(clsType, "From", "Public", null!);
        TestUtils.PrintAreAccessModsPropertyCorrect(clsType, "To", "Public", null!);
    }

    public static void TestInheritance()
    {
        TestUtils.PrintDoesClassInheritFrom(typeof(Email), typeof(AdminEmail));
        TestUtils.PrintIsMethodOverridden(typeof(Email), typeof(AdminEmail), "Send");
        TestUtils.PrintIsMethodOverridden(typeof(object), typeof(Email), "ToString");
    }

    public static void TestTrimSubject()
    {
        List<Email> emails = [
            new("", "NoSpaces", "", ""),
            new("", "No leading or trailing white-space characters", "", ""),
            new("", "  Spaces_Left", "", ""),
            new("", "Spaces_Right    ", "", ""),
            new("", "   Spaces_LeftAndRight  ", "", ""),
        ];

        foreach (var email in emails)
        {
            Console.WriteLine(email.Subject);
        }
    }

    public static void TestSendRegularEmail()
    {
        User john = EmailProvider.Users[0];
        User jane = EmailProvider.Users[1];
        User jack = EmailProvider.Users[2];
        User jill = EmailProvider.Users[3];

        Console.WriteLine("John sends email to Jane");
        Email email = new("Was thinking of you!", "Hi!",
            john.EmailAddress, jane.EmailAddress);
        PrintIfEmailSent(true, email.Send());

        Console.WriteLine("\nJack sends email to Jill");
        email = new("Wanna catch up?", "Hey!",
            jane.EmailAddress, jill.EmailAddress);
        PrintIfEmailSent(true, email.Send());

        Console.WriteLine("\nJohn sends email to Jack");
        email = new("Can I borrow your chainsaw?", "Yo!",
            john.EmailAddress, jack.EmailAddress);
        PrintIfEmailSent(true, email.Send());

        Console.WriteLine("\nJohn sends email to Jack who blocked him");
        jack.BlockEmailAddress(john.EmailAddress);
        email = new("I haven't heard back from you.", "Hey?",
            john.EmailAddress, jack.EmailAddress);
        bool sent = email.Send();
        PrintIfEmailSent(false, sent);
        if (sent)
        {
            Console.WriteLine(" - ReceiveEmail in Class User should return false because John is in the _blockedEmailAddresses list");
        }

        Console.WriteLine("\nJack sends email to non-existing user");
        email = new("Long time no see!", "Hello!",
            jack.EmailAddress, "jace@hr.nl");
        sent = email.Send();
        PrintIfEmailSent(false, sent);
        if (sent)
        {
            Console.WriteLine(" - No email should be sent, because the recipient doesn't exist");
        }

        Console.WriteLine("\n=== Printing each user's inbox ===");
        foreach (User user in EmailProvider.Users)
        {
            Console.WriteLine($" - User: {user.Name}");
            user.PrintInbox();
        }
    }

    public static void TestReply()
    {
        User john = EmailProvider.Users[0];
        User jane = EmailProvider.Users[1];
        User jack = EmailProvider.Users[2];
        User jill = EmailProvider.Users[3];

        Console.WriteLine("Jane replies to John");
        Email email = new("Was thinking of you!", "Hi!",
            john.EmailAddress, jane.EmailAddress);
        Email reply = Email.CreateReply("Me too! How are you?", email);
        PrintEmail(reply);

        Console.WriteLine("Jill replies to Jane");
        email = new("Wanna catch up?", "Hey!",
            jane.EmailAddress, jill.EmailAddress);
        reply = Email.CreateReply("Sure! Tomorrow?", email);
        PrintEmail(reply);

        Console.WriteLine("Jack replies to John");
        email = new("Can I borrow your chainsaw?", "Yo!",
            john.EmailAddress, jack.EmailAddress);
        reply = Email.CreateReply("No.", email);
        PrintEmail(reply);

        Console.WriteLine("John replies to Jack");
        Email rereply = Email.CreateReply("OK.", reply);
        PrintEmail(rereply);
    }

    public static void TestSendAdminEmail()
    {
        User john = EmailProvider.Users[0];
        User jane = EmailProvider.Users[1];
        User jill = EmailProvider.Users[3];

        Console.WriteLine("Admin sends email to John");
        AdminEmail adminEmail = new("Legal stuff", "Terms of Service updated",
            john.EmailAddress);
        PrintIfEmailSent(adminEmail.Send(), true);

        Console.WriteLine("\nAdmin sends email to Jill");
        adminEmail = new("Be careful for suspicious email", "Tip to avoid scams",
            jane.EmailAddress);
        PrintIfEmailSent(adminEmail.Send(), true);

        Console.WriteLine("\nAdmin sends email to Jill who blocked admin (whose AdminMessage cannot be blocked)");
        jill.BlockEmailAddress("admin@hr.nl");
        adminEmail = new("Be very careful for suspicious email", "Another tip to avoid scams",
            jane.EmailAddress);
        PrintIfEmailSent(adminEmail.Send(), true);

        Console.WriteLine("\nAdmin sends email to non-existing user");
        adminEmail = new("Be very careful for suspicious email", "Another tip to avoid scams",
            "doesntexist@hr.nl");
        bool sent = adminEmail.Send();
        PrintIfEmailSent(false, sent);
        if (sent)
        {
            Console.WriteLine(" - Reason: ReceiveEmail in Class User should return false because John is in the _blockedEmailAddresses list");
        }

        Console.WriteLine("\n=== Printing each user's inbox ===");
        foreach (User user in EmailProvider.Users)
        {
            Console.WriteLine($" - User: {user.Name}");
            user.PrintInbox();
        }

        Console.WriteLine("=== Logged emails ===");
        foreach (string emailToString in AdminEmail.LoggedEmails)
        {
            Console.WriteLine(emailToString + "\n");
        }
    }

    private static void PrintEmail(Email email)
    {
        Console.WriteLine(
            "--------------------\n" +
            $"From: {email.From}\n" +
            $"To: {email.To}\n" +
            $"Subject: {email.Subject}\n" +
            "--------------------\n" +
            $"Body:\n{email.Body}\n" +
            "--------------------\n");
    }

    private static void PrintIfEmailSent(bool expected, bool actual) => Console.WriteLine($"Email sent: {actual}. Expected: {expected}.");
}