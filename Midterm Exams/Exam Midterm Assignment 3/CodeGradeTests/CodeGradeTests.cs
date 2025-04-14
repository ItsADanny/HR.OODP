// Do not modify this file

static class CodeGradeTests
{
    static void Main(string[] args)
    {
        switch (args[1])
        {
            case "Interface": TestInterface(); return;
            case "Abstract": TestAbstract(); return;
            case "ImplPassword": TestImplPassword(); return;
            case "ImplAccount": TestImplAccount(); return;
            case "ImplBankAccount": TestImplBankAccount(); return;
            default: throw new ArgumentException($"{args[1]}", $"Unexpected args value: {args[1]}");
        }
    }

    public static void TestInterface()
    {
        Type interfaceType = typeof(ICredential);
        Type implementingType = typeof(Password);

        TestUtils.PrintIsInterface(interfaceType);
        TestUtils.PrintIsInterfaceImplementedBy(interfaceType, implementingType);

        TestUtils.PrintIsPropertySignatureCorrect(interfaceType, "Expected", typeof(string), true, false);
        TestUtils.PrintIsPropertySignatureCorrect(interfaceType, "Actual", typeof(string), true, false);
        TestUtils.PrintIsMethodSignatureCorrect(interfaceType, "EnterCredential", typeof(void), typeof(string));
        TestUtils.PrintIsMethodSignatureCorrect(interfaceType, "IsEnteredCredentialCorrect", typeof(bool), []);
    }

    public static void TestAbstract()
    {
        Type baseClass = typeof(Account);
        TestUtils.PrintIsAbstractClass(baseClass);
        TestUtils.PrintIsAbstractMethod(baseClass, "Authenticate");
        TestUtils.PrintIsAbstractMethod(baseClass, "PrintInfo");

        Type derivedClass = typeof(BankAccount);
        TestUtils.PrintDoesClassInheritFrom(baseClass, derivedClass);
    }

    public static void TestImplPassword()
    {
        Password password1 = new("123");
        Password password2 = new("abcd");
        Console.WriteLine("Is the entered password correct? " + password1.IsEnteredCredentialCorrect());
        Console.WriteLine("Is the entered password correct? " + password2.IsEnteredCredentialCorrect());
        Console.WriteLine();

        password1.EnterCredential("abcd");
        password2.EnterCredential("abcd");
        Console.WriteLine("Is the entered password correct? " + password1.IsEnteredCredentialCorrect());
        Console.WriteLine("Is the entered password correct? " + password2.IsEnteredCredentialCorrect());
        Console.WriteLine();

        password1.EnterCredential("123");
        password2.EnterCredential("123");
        Console.WriteLine("Is the entered password correct? " + password1.IsEnteredCredentialCorrect());
        Console.WriteLine("Is the entered password correct? " + password2.IsEnteredCredentialCorrect());
    }

    public static void TestImplAccount()
    {
        Account acc = new BankAccount("Bruce Wayne", "ThomasMartha");
        Console.WriteLine("Expected: " + acc.MyPassword.Actual);
        Console.WriteLine("Actual: " + acc.MyPassword.Actual);
        Console.WriteLine("Authenticated: " + acc.IsAuthenticated);
        Console.WriteLine();

        acc.PasswordLogin("Bruce Wayne", "Parents");
        Console.WriteLine("Expected: " + acc.MyPassword.Actual);
        Console.WriteLine("Actual: " + acc.MyPassword.Actual);
        Console.WriteLine("Authenticated: " + acc.IsAuthenticated);
        Console.WriteLine();

        acc.PasswordLogin("Selina Kyle", "ThomasMartha");
        Console.WriteLine("Expected: " + acc.MyPassword.Actual);
        Console.WriteLine("Actual: " + acc.MyPassword.Actual);
        Console.WriteLine("Authenticated: " + acc.IsAuthenticated);
        Console.WriteLine();

        acc.PasswordLogin("Bruce Wayne", "ThomasMartha");
        Console.WriteLine("Expected: " + acc.MyPassword.Actual);
        Console.WriteLine("Actual: " + acc.MyPassword.Actual);
        Console.WriteLine("Authenticated: " + acc.IsAuthenticated);
        Console.WriteLine();

    // Encapsulation
        string methodName = "Authenticate";
        TestUtils.PrintAccessModMethodCorrect(typeof(Account), methodName, "Family");
    }

    public static void TestImplBankAccount()
    {
        BankAccount bacc = new("Tony Stark", "IronManRox");
        bacc.Deposit(1_000_000);

        // Not yet authenticated
        Console.WriteLine($"Entered password: {bacc.MyPassword.Actual}");
        int withdrawn = bacc.Withdraw(1000);
        Console.WriteLine($"Withdrawn: {withdrawn}");
        bacc.PrintInfo();
        Console.WriteLine();

        // Authenticated
        bacc.PasswordLogin("Tony Stark", "IronManRox");
        Console.WriteLine($"Entered password: {bacc.MyPassword.Actual}");
        withdrawn = bacc.Withdraw(1000);
        Console.WriteLine($"Withdrawn: {withdrawn}");
        bacc.PrintInfo();
    }
}