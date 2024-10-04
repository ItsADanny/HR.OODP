class Account {

    //Making a field read only
    // public double Balance {get;};

    //Making a field write only
    // public double Balance {set;};

    //Making a field read and write
    // public double Balance {get; set;};

    //Making a field only readable from the class
    // public double Balance {private get;};

    //Making a field only writeable from the class
    // public double Balance {private set;};

    //Making a field read- and write-able from the class
    // public double Balance {private get; private set;};

    //Making a field 
    // public double Balance {protected get;};

    //Making a field 
    // public double Balance {protected set;};

    //Making a field 
    // public double Balance {protected get; protected set;};


    public double _balance; //Backing field

    //In this way we can make sure our value's can't go below 0 with Variable properties
    public double Balance {
        get { return _balance; }
        //With this we make sure our balance can't go lower than 0
        set { _balance = Math.Max(0, value); }
    }

    public Account (double balance) {
        Balance = balance;
    }

    public double GetBalance() => Balance;

    public void LowerBalance(int value) => Balance -= value;
}