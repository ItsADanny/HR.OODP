public class Program {
    public static void Main() {
        Directory directory = Directory.CreateDirectory();

        Console.WriteLine(directory.SearchFile("A") ? "File has been found" : "File has not been found");
        // directory.Print();
        // directory.PrintWithIndent();
    }
}



public class Directory
{
    public string Name { get; set; }
    public string[] Files { get; set; }
    public Directory[] Directories { get; set; }

    public Directory(string name, string[] files, Directory[] directories)
    {
        Name = name;
        Files = files;
        Directories = directories;
    }

    public static Directory CreateDirectory() {
        Directory Taxes = new ("Taxes", ["F","G","H"], [
            new ("2022", ["I"], []),
            new ("2023", ["J"], []),
            new ("2024", [], [])
        ]);
        Directory Music = new ("Music", ["K"], []);
        Directory Personal = new ("Personal", ["D","E"], [
            Taxes, Music
        ]);
        Directory Work = new ("Work", ["L", "M"], [new ("My Project", ["N", "O", "P", "Q"], [])]);
        return new Directory("My Documents", ["A","B","C"], [Personal, Work]);
    }

    //My Little Torture
    // public static Directory CreateDirectory() => new Directory("My Documents", ["A","B","C"], [new ("Personal", ["D","E"], [new ("Taxes", ["F","G","H"], [new ("2022", ["I"], []),new ("2023", ["J"], []),new ("2024", [], [])]), new ("Music", ["K"], [])]), new ("Work", ["L", "M"], [new ("My Project", ["N", "O", "P", "Q"], [])])]);
    
    /*
        Write a static method `CreateDirectory()` which generates the following Directory structure:

        My Documents
        -Files:A,B,C
        -Personal
        --Files:D,E
        --Taxes
        ---Files:F,G,H
        ---2022
        ----Files:I
        ---2023
        ----Files:J
        ---2024
        --Music
        ---Files:K
        -Work
        --Files:L,M
        --My Project
        ---Files:N,O,P,Q
    */

    /*
        Write a method SearchFile which takes in a string which is a file name
        and returns a bool which indicates whether the file is in the directory 
        or its subdirectories
    */
    public bool SearchFile(string fileName)
    {
        if (Files.Length != 0) {if (Files.Contains(fileName)) return true;}
        if (Directories.Length == 0) return false;
        foreach (Directory directory in Directories) {
            if(directory.SearchFile(fileName)) {
                return true;
            }
        }
        return false;
    }

    //No Indentations
    public void Print() {
        Console.WriteLine(Name);
        if (Files.Length != 0) {
            string row = "";
            foreach (string file in Files) {
                if (row != "") {
                    row += ",";
                }
                row += file;
            }
            Console.WriteLine($"Files: {row}");
        }
        if (Directories.Length != 0) {
            foreach (Directory directory in Directories) {
                directory.Print();
            }
        }
    }

    //With Indentations
    public void PrintWithIndent() => Console.WriteLine(_mPrintWithIndent());

    private string _mPrintWithIndent() {
        string returnValue = $"{Name}\n";
        if (Files.Length != 0) {
            string row = "";
            foreach (string file in Files) {
                if (row != "") {
                    row += ",";
                }
                row += file;
            }
            returnValue += $"-Files: {row}\n";
        }
        if (Directories.Length != 0) {
            foreach (Directory directory in Directories) {
                returnValue += $"-{directory._mPrintWithIndent()}";
            }
        }
        return returnValue;
    }

    /*
        Write a method to print all files and directory names in the directory
        For example
        ```
        My Documents
        Files:A,B,C
        Personal
        Files:D,E
        Taxes
        Files:F,G,H
        2022
        Files:I
        2023
        Files:J
        2024
        Music
        Files:K
        Work
        Files:L,M
        My Project
        Files:N,O,P,Q
        ```
        Can you modify your method so that it prints out with indentation? For example:
        ```
            My Documents
            -Files:A,B,C
            -Personal
            --Files:D,E
            --Taxes
            ---Files:F,G,H
            ---2022
            ----Files:I
            ---2023
            ----Files:J
            ---2024
            --Music
            ---Files:K
            -Work
            --Files:L,M
            --My Project
            ---Files:N,O,P,Q
        ```
    */
}