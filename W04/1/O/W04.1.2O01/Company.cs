class Company
{
    public List<Employee> Employees;
    public int WhatIsConsideredDistant;
    public int ExtraTravelAllowanceBudget;
    public int MaxExtraTravelAllowance;
    public string LogLocation;

    //The company object initialiser
    public Company()
    {
        Employees = new List<Employee>();
        WhatIsConsideredDistant = 25;
        ExtraTravelAllowanceBudget = 300;
        MaxExtraTravelAllowance = 100;
        LogLocation = "./Log.txt";
    }

    //This function "Hires" employees to the company (In other words, adds them to the company objects list with Employee objects)
    public void Hire(Employee employee) => Employees.Add(employee);

    //This function Calculates their monthly salary and adds it to the SalaryEarned field in the Employee object.
    public void PayMonthlySalary()
    {
        //First, we retrieve how many distant employees we have
        int howManyDistantEmployees = HowManyDistantEmployees();
        //Secondly, we iterate through the Employees list and calculate per employee their monthly salary 
        //and add this to SalaryEarned Field for that employee.
        foreach (var employee in Employees)
        {
            int payout = employee.Salary + CalculateTravelAllowance(employee, howManyDistantEmployees);
            employee.SalaryEarned += payout;
        }
    }

    //This functions calculates the travel allowance, This calculation is specific to the employee objects distance from the company
    private int CalculateTravelAllowance(Employee employee, int howManyDistantEmployees)
    {
        var howManyCloseEmployees = Employees.Count - howManyDistantEmployees;
        var standardTravelAllowance = employee.DistanceFromCompany * 10;
        try
        {   
            var extraTravelAllowanceDistant = 0;
            if (howManyDistantEmployees > 0) {
                extraTravelAllowanceDistant = Math.Min(ExtraTravelAllowanceBudget / howManyDistantEmployees, MaxExtraTravelAllowance);
            } else {
                extraTravelAllowanceDistant = 0;
            }
            
            var extraTravelAllowanceClose = Math.Min((ExtraTravelAllowanceBudget - extraTravelAllowanceDistant * howManyDistantEmployees) / howManyCloseEmployees, 100);
            return standardTravelAllowance +
                (employee.DistanceFromCompany >= WhatIsConsideredDistant ?
                extraTravelAllowanceDistant : extraTravelAllowanceClose);
        }
        catch (DivideByZeroException ex)
        {
            string message = ex.Message;
            message =
                (howManyDistantEmployees == 0 ? "0 distant employees. " : "") +
                (howManyCloseEmployees == 0 ? "0 close employees. " : "") +
                message;
            LogException(message);
        }
        return 0;
    }

    //This function returns the amount of distant employees based on the variable (WhatIsConsideredDistant)
    private int HowManyDistantEmployees()
    {
        int howMany = 0;
        foreach (var employee in Employees)
        {
            //If an employee is further away or is the distance we have set as "distant" 
            //then we add them to our count of Distant employees
            if (employee.DistanceFromCompany >= WhatIsConsideredDistant)
                howMany++;
        }
        return howMany;
    }

    //This function logs our errors
    private void LogException(string message)
    {
        try
        {
            File.AppendAllText(LogLocation, DateTime.Now + "\n" + message + "\n");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}