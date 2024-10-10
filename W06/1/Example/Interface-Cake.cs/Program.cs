class Food {

}

// class Sweet : Food {

// }

interface ISweet {
    int HowMuchSugar { get; }
}

// class Savory : Food {

// }

interface ISavory {
    int HowMuchSalt { get; }
}

//Its not possible to inplement two classes in a tree structure
// class Quiche : Sweet, Savory {
// }

//But it is possible to have multiple interfaces
class Quiche : ISweet, ISavory {
    public int HowMuchSugar { get; }
    public int HowMuchSalt { get; }
}