List<string> Options = ["Popcorn", "Cola", "Nacho's", "Ice cream scoop (strawberry)", "Ice cream scoop (vanilla)", "Ice cream scoop (lemon sorbet)"];
List<bool> Selected = [false, false, false, false, false, false];

bool done = false;
int pos = 0;

do {
    Console.Clear();
    for (int y = 0; y != Options.Count(); y++) {
        string row = "";
        if (pos == y) {
            row += "\x1b[44m>";
        } else {
            row += " ";
        }

        if (Selected[y]) {
            row += " [X] ";
        } else {
            row += " [ ] ";
        }

        row += $" {Options[y]}\x1b[49m";
        Console.WriteLine(row);
    }
    var input = Console.ReadKey();
    switch (input.Key) {
        case ConsoleKey.UpArrow:
            if (pos <= 0) {
                pos = Options.Count() - 1;
            } else {
                pos -= 1;
            }
            break;
        case ConsoleKey.DownArrow:
            if (pos >= (Options.Count() - 1)) {
                pos = 0;
            } else {
                pos += 1;
            }
            break;
        case ConsoleKey.Spacebar:
            if (Selected[pos]) {
                Selected[pos] = false;
            } else {
                Selected[pos] = true;
            }
            break;
        case ConsoleKey.Enter:
            done = true;
            break;
    }
} while (!done);

int selectedPos = 0;
foreach (string option in Options) {
    Console.WriteLine($"{option} : {Selected[selectedPos]}");
    selectedPos++;
}