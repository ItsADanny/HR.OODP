using static System.Formats.Asn1.AsnWriter;

public class Program
{
    public static void Main()
    {
        //Retrieving employees from a database or a file
        List<object> employees = new()
        {
            new Employee(1, "Miles Dyson", "Developer"),
            new Employee(2, "Coleman Reese", "Lawyer"),
            new Manager (3, "Bill Lumbergh", "Manager", 5),
            new Manager (4, "Michael Scott", "Manager", 10),
            new Dog("Owney the mascot dog") //Not an employee
        };
        ListDirectReports(employees);
    }

    public static void ListDirectReports(List<object> employees)
    {
        /*Your code goes here.
          Loop through the objects and use 'as' to cast them to a Manager.
          Then if not null, print (depending on the Manager's fields):
          "Manager Bill Lumbergh has 5 direct reports."
        */

        foreach (Employee person in employees) {
            // Manager manager;
            // try {
            //     if ((manager = person as Manager) != null) {
            //         Console.WriteLine($"{manager.Position} {manager.Name} has {manager.DirectReportsCount} direct reports.");
            //     }
            // } catch (Exception e) { }

            if (person as Manager != null) {
                Manager manager = (Manager) person;
                Console.WriteLine($"{manager.Position} {manager.Name} has {manager.DirectReportsCount} direct reports.");
            }
        }
    }
}