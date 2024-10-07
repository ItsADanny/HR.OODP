//Create the Person class
class Person {
    //Create 2 field:
    //1 for the name of the person
    //1 for the dayjob of the person, this field will start as a null
    //so that we can use it to see if our person object has a job
    public string Name;
    public Job DayJob = null;

    //Create an Constructor for the class the requires an name and a job
    public Person(string name, Job dayJob) {
        //And assign these to our objects Name and DayJob fields
        Name = name;
        DayJob = dayJob;
    }

    //Create a method that will return the Job the person is preforming
    //If the person doesn't have a job then it will return that the person
    //is between jobs
    public string Info() {
        if (DayJob != null) {
            return $"{Name} works as a {DayJob.Name}";
        }
        return $"{Name} is in between jobs";
    }
}