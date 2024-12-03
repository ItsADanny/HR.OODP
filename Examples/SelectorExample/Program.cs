List<string> Timeslots = ["Monday 18 november - 10:00 / 12:00", "Monday 18 november - 10:00 / 12:00", "Monday 18 november - 12:00 / 14:00", "Monday 18 november - 14:00 / 16:00", "Monday 18 november - 16:00 / 18:00", "Monday 18 november - 18:00 / 20:00", "Monday 18 november - 20:00 / 22:00"];

string selectedString = null;
int pos = 0;

do {
    Console.Clear();
    for (int y = 0; y != Timeslots.Count(); y++) {
        string row = "";
        if (pos == y) {
            row += "\x1b[44m>";
        } else {
            row += " ";
        }

        row += $" {Timeslots[y]}";
        Console.WriteLine(row);
    }
    var input = Console.ReadKey();
    switch (input.Key) {
        case ConsoleKey.UpArrow:
            if (pos <= 0) {
                pos = Timeslots.Count() - 1;
            } else {
                pos -= 1;
            }
            break;
        case ConsoleKey.DownArrow:
            if (pos >= (Timeslots.Count() - 1)) {
                pos = 0;
            } else {
                pos += 1;
            }
            break;
        case ConsoleKey.Enter:
            selectedString = Timeslots[pos];
            break;
    }
} while (selectedString == null);

Console.WriteLine(selectedString);