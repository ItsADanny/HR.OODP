public static class Hospital {
    public const string Name;
    public static readonly List<Doctor> Doctors = [];
    public static readonly List<Patient> UnassignedPatients = [];
    public static readonly List<string> Departments = ["Cardiology", "Neurology", "Oncology"];

    //Doctor methods
    public static void AddDoctor (Doctor doctor) => Doctors.Add(doctor);

    public static void RemoveDoctor (string id) {

    }

    //Patient methods
    public static void AddPatient (Patient patient) => UnassignedPatients.Add(patient);

    public static void RemovePatient (string id) {

    }

    //This method assigns a Doctor to a patient
    public static void AssignDoctorToPatient (string doctorId, string patientId) {

    }

    //This method assigns a Supervisee to a Supervisor
    public static void AssignSuperviseeToSupervisor (string superviseeId, string supervisorId) {

    }
}