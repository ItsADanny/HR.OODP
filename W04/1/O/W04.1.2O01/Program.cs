class Program
{
    public static void Main()
    {
        //Create a new company object and set it in the variable called "company".
        var company = new Company();
        //Create a new list for Employee objects and set it in the variable called "people".
        //In this list we are going to add 4 new employees with different salaries and distances to the company.
        var people = new List<Employee>()
        {
            new Employee(3000, 10),
            new Employee(2500, 20),
            new Employee(3500, 15),
            new Employee(3000, 20),
        };
        //Loop through the list with Employee objects and "Hire" them at the company.
        foreach (var person in people)
        {
            company.Hire(person);
        }

        //Run the function to calculate the employees monthly salary.
        company.PayMonthlySalary();
        //Loop through the list with Employee objects that the company object contains and print their earned salaries.
        foreach (var employee in company.Employees)
        {
            Console.WriteLine($"Employee has earned {employee.SalaryEarned}");
        }
    }
}