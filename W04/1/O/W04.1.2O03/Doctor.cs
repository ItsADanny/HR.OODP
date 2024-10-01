public class Doctor {
    public readonly string Id;
    public string Name;
    public string Department;
    public readonly List<Patient> AssignedPatients = [];
    public readonly List<Doctor> Supervisees = [];
    public const string DefaultSupervisorId = "-";

    public Doctor (string name, string department) {
        Name = name;
        Department = department;
    }
}