//TEST PROGRAM FOR THE GameTools class

bool CoinFlip_with_ReturnCount = false;
bool CoinFlip_without_ReturnCount = false;
bool DiceRoll_with_ReturnCount = false;
bool DiceRoll_without_ReturnCount = false;

if (CoinFlip_with_ReturnCount) {
    printPart("CoinFlip with ReturnCount", 0);
    Console.WriteLine(GameTools.CoinFlip(50));
    printPart("CoinFlip with ReturnCount", 1);
}

if (CoinFlip_without_ReturnCount) {
    printPart("CoinFlip without ReturnCount", 0);
    GameTools.ReturnCount = false;
    Console.WriteLine(GameTools.CoinFlip(50));
    printPart("CoinFlip without ReturnCount", 1);
}

if (DiceRoll_with_ReturnCount) {
    printPart("DiceRoll with ReturnCount", 0);
    printPart("DiceRoll with ReturnCount", 1);
}

if (DiceRoll_without_ReturnCount) {
    printPart("DiceRoll without ReturnCount", 0);
    printPart("DiceRoll without ReturnCount", 1);
}

void printPart(string test_name, int type) {
    string type_barrier;
    if (type == 0) {
        type_barrier = "=BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN===BEGIN=";
    } else {
        type_barrier = "=END===END===END===END===END===END===END===END===END===END===END===END===END===END===END===END=";
    }
    Console.WriteLine(type_barrier);
    Console.WriteLine($"Test: {test_name}");
    Console.WriteLine(type_barrier);
}