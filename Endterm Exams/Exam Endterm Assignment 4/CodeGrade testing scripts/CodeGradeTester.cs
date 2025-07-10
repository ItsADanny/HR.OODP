// Do not modify this file

// static class CodeGradeTester
// {
//     private readonly static Random _random = new(0);

//     static void Main(string[] args)
//     {
//         switch (args[1])
//         {
//             case "Van_Capacity": Test_VanCapacity(); return;
//             case "StackType": Test_StackType(); return;
//             case "Van_Constructor": Test_Van_Constructor(); return;
//             case "Van_ToString": Test_Van_ToString(); return;
//             case "Van_Load": Test_Van_Load(); return;
//             case "Van_Unload": Test_Van_Unload(); return;
//             case "House_TotalInsuredValue": Test_House_TotalInsuredValue(); return;
//             case "House_GetFurnitureAboveValue": Test_House_GetFurnitureAboveValue(); return;
//             default: throw new ArgumentOutOfRangeException($"{args[1]}", $"Unexpected args value: {args[1]}");
//         }
//     }

//     public static void Test_VanCapacity()
//     {
//         System.Console.WriteLine("Checking VanCapacity is implemented correctly");
//         foreach (VanCapacity vanCapacity in Enum.GetValues<VanCapacity>())
//         {
//             Console.WriteLine(" - {0}: capacity {1:D} cubic meters", vanCapacity, vanCapacity);
//         }
//         Console.WriteLine();
//     }

//     public static void Test_StackType()
//     {
//         TestUtils.PrintPropertyType(typeof(Van), "Contents");
//     }

//     public static void Test_Van_Constructor()
//     {
//         Console.WriteLine("Testing VanCapacity is initialized correctly");
//         Van van = new(VanCapacity.Small);
//         Console.WriteLine($"VanCapacity is set correctly? {van.Capacity == VanCapacity.Small}");
//         Console.WriteLine();

//         Console.WriteLine("Testing stack is initialized correctly");
//         Console.WriteLine($"Stack is empty? {van.Contents.Count == 0}");
//         Console.WriteLine();

//         Console.WriteLine($"UsedVolume is 0? {van.UsedVolume == 0}");
//         Console.WriteLine();
//     }

//     public static void Test_Van_ToString()
//     {
//         Van van = new(VanCapacity.Large);
//         Console.WriteLine("Testing ToString on initialization");
//         Console.WriteLine(van);
//         Console.WriteLine();

//         var furniture = GenerateFurnitureList(5);
//         foreach (var item in furniture)
//         {
//             van.Load(item);
//         }
//         Console.WriteLine("Testing ToString after loading");
//         Console.WriteLine(van);
//         Console.WriteLine();
//     }

//     public static void Test_Van_Load()
//     {
//         Console.WriteLine("Testing Loading");
//         int furnitureCount = 10;
//         foreach (VanCapacity capacity in Enum.GetValues<VanCapacity>())
//         {
//             Van van = new(capacity);
//             Console.WriteLine("Testing van with capacity: {0:D}", capacity);

//             var furniture = GenerateFurnitureList(furnitureCount--);
//             foreach (var item in furniture)
//             {
//                 bool itemLoaded = van.Load(item);
//                 Console.WriteLine($"Attempting to load {item.Name} with volume {item.Volume}. Successful? {itemLoaded}");
//                 if (itemLoaded)
//                 {
//                     Console.WriteLine(van);
//                 }
//             }
//             Console.WriteLine();
//         }
//         Console.WriteLine();
//     }

//     public static void Test_Van_Unload()
//     {
//         for (int i = 2; i <= 8; i += 3)
//         {
//             Console.WriteLine($"Testing with {i} items of furniture");
//             Console.WriteLine($"------------------------------------");

//             Van van = new(VanCapacity.Large);

//             var furniture = GenerateFurnitureList(i);
//             foreach (var item in furniture)
//             {
//                 van.Load(item);
//             }

//             Console.WriteLine("Loaded Van details:");
//             Console.WriteLine(van);

//             List<Furniture> unloadedFurniture = van.Unload();

//             string unloadedFurnitureNames = string.Join(" ", unloadedFurniture.Select(f => f.Name));
//             Console.WriteLine($"\nUnloaded furniture: {unloadedFurnitureNames}");

//             Console.WriteLine("\nVan details after unloading:");
//             Console.WriteLine(van);
//             Console.WriteLine();
//         }
//         Console.WriteLine();
//     }

//     public static void Test_House_TotalInsuredValue()
//     {
//         Console.WriteLine("Testing TotalInsuredValue");
//         for (int i = 3; i <= 13; i += 5)
//         {
//             var furniture = GenerateFurnitureList(i);
//             House home = new(i + ", Fake street", furniture);
//             Console.WriteLine($"Total cost of insured furniture items: {home.TotalInsuredValue()}");
//             Console.WriteLine($"All furniture at {home.Address}: ");
//             Console.WriteLine(string.Join("\n", home.FurnitureList));
//             Console.WriteLine();
//         }
//     }

//     public static void Test_House_GetFurnitureAboveValue()
//     {
//         Console.WriteLine("Testing GetFurnitureAboveValue");
//         for (int i = 5; i <= 15; i += 5)
//         {
//             var furniture = GenerateFurnitureList(i);
//             furniture.Add(new Furniture("Cupboard", 9, i * 50, true));
//             House home = new(i + ", Fake street", furniture);
//             Console.WriteLine($"Items above {i * 50} at {home.Address}:");
//             Console.WriteLine($"{string.Join("\n", home.GetFurnitureAboveValue(i * 50))}");

//             Console.WriteLine($"\nAll furniture at {home.Address}: ");
//             Console.WriteLine(string.Join("\n", home.FurnitureList));
//             Console.WriteLine("----------------------------------------------------------");
//         }
//     }

//     private static List<Furniture> GenerateFurnitureList(int count)
//     {
//         string[] names = ["Chair", "Table", "Sofa", "Bed", "Cabinet", "Desk", "Computer", "TV", "Lamp", "Fridge" ];

//         List<Furniture> furnitureList = [];
//         for (int i = 0; i < count; i++)
//         {
//             string name = names[_random.Next(names.Length)];
//             int volume = _random.Next(1, 7); // Random volume between 1 and 30 cubic meters
//             int value = _random.Next(100, 1000); // Random value between 50 and 1000 euros
//             bool isInsured = _random.Next(2) == 0; // Randomly true or false

//             furnitureList.Add(new Furniture(name, volume, value, isInsured));
//         }

//         return furnitureList;
//     }
// }
