bool run_taskTest = true;
bool run_TodoTest = false;

if (run_taskTest) {
    

    printTestHeader("Class Task");
    Console.WriteLine("Task T1 - Created");
    Console.WriteLine("===============================");
    Task TestTask_T1 = new Task("T1");
    Console.WriteLine(TestTask_T1.Info());
    console.WriteLine(" ");
    Console.WriteLine("Task T1 - IsDone update");
    Console.WriteLine("===============================");
    TestTask_T1.Done();
    Console.WriteLine(TestTask_T1.Info());
}

if (run_TodoTest) {

}

void printTestHeader(string str_testname) {
    Console.WriteLine("-------------------------------------------");
    Console.WriteLine($"Test: {str_testname}");
    Console.WriteLine("-------------------------------------------");
}