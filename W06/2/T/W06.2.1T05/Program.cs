public class Program {
    static void Main() {
        Employee employee = new ("John", "Doe", "john.doe@example.com");
        Manager manager = new ("Jane", "Doe", "jane.doe@example.com", "Sales");
        SalesPerson salesPerson = new ("Bob", "Smith", "bob.smith@example.com", 100000);

        employee.PrintEmployeeInfo();
        (manager as Employee).PrintEmployeeInfo();
        (salesPerson as Employee).PrintEmployeeInfo();

        employee.PrintEmployeeInfo();
        manager.PrintEmployeeInfo();
        salesPerson.PrintEmployeeInfo();
    }
}