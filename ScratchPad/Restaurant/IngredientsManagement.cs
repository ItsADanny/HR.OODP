using System;
using System.Collections.Generic;
using System.Linq;

    public static class IngredientsManagement
    {
        static IngredientsLogic _ingredientsLogic = new();
        static AllergenLogic _allergenLogic = new();

        private static void DrawMenu(string title, List<string> options, int selectedIndex)
        {
            Console.Clear();
            int width = 64;
            int maxVisibleItems = 8;
            int startIndex = Math.Max(0, Math.Min(selectedIndex - maxVisibleItems / 2, options.Count - maxVisibleItems));
            int endIndex = Math.Min(startIndex + maxVisibleItems, options.Count);

            string topBorder = "╔" + new string('═', width - 2) + "╗";
            string bottomBorder = "╚" + new string('═', width - 2) + "╝";
            string separator = "╠" + new string('═', width - 2) + "╣";
            string emptyLine = "║" + new string(' ', width - 2) + "║";

            Console.WriteLine(topBorder);
            Console.WriteLine($"║ {title.PadRight(width - 4)} ║");
            Console.WriteLine(separator);
            Console.WriteLine(emptyLine);

            if (startIndex > 0)
            {
                Console.WriteLine($"║   {"↑ More items above".PadRight(width - 6)} ║");
            }

            for (int i = startIndex; i < endIndex; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"║ ► {options[i].PadRight(width - 6)} ║");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"║   {options[i].PadRight(width - 6)} ║");
                }
            }

            if (endIndex < options.Count)
            {
                Console.WriteLine($"║   {"↓ More items below".PadRight(width - 6)} ║");
            }

            Console.WriteLine(emptyLine);
            Console.WriteLine(bottomBorder);
            Console.WriteLine("\nUse ↑↓ arrows to navigate, Enter to select, 'q' to quit");
        }

        private static void DrawBox(string title, string content)
        {
            Console.Clear();
            int width = 64;
            string topBorder = "╔" + new string('═', width - 2) + "╗";
            string bottomBorder = "╚" + new string('═', width - 2) + "╝";
            string separator = "╠" + new string('═', width - 2) + "╣";
            string emptyLine = "║" + new string(' ', width - 2) + "║";

            Console.WriteLine(topBorder);
            Console.WriteLine($"║ {title.PadRight(width - 4)} ║");
            Console.WriteLine(separator);
            Console.WriteLine(emptyLine);

            string[] lines = content.Split('\n');
            foreach (string line in lines)
            {
                int remainingLength = line.Length;
                int currentPosition = 0;
                while (remainingLength > 0)
                {
                    int length = Math.Min(remainingLength, width - 6);
                    string subLine = line.Substring(currentPosition, length);
                    Console.WriteLine($"║   {subLine.PadRight(width - 6)} ║");
                    remainingLength -= length;
                    currentPosition += length;
                }
            }

            Console.WriteLine(emptyLine);
            Console.WriteLine(bottomBorder);
        }

        public static void Start()
        {
            var options = new List<string>
            {
                "Create ingredient",
                "Edit ingredient",
                "Delete ingredient",
                "Create allergen",
                "Edit allergen",
                "Delete allergen",
                "Quit"
            };

            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                DrawMenu("Ingredients Management", options, selectedIndex);

                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = (selectedIndex - 1 + options.Count) % options.Count;
                        break;
                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Count;
                        break;
                    case ConsoleKey.Enter:
                        switch (selectedIndex)
                        {
                            case 0:
                                Console.Clear();
                                CreateIngredient();
                                Console.Clear();
                                break;
                            case 1:
                                Console.Clear();
                                while (Select(_ingredientsLogic.All(), x => Edit(x), "edit")) { }
                                Console.Clear();
                                break;
                            case 2:
                                Console.Clear();
                                while (Select(_ingredientsLogic.All(), x => Delete(x), "delete")) { }
                                Console.Clear();
                                break;
                            case 3:
                                Console.Clear();
                                CreateAllergen();
                                Console.Clear();
                                break;
                            case 4:
                                Console.Clear();
                                while (SelectAllergen(_allergenLogic.AllAllergen(), x => EditAllergen(x), "edit")) { }
                                Console.Clear();
                                break;
                            case 5:
                                Console.Clear();
                                while (SelectAllergen(_allergenLogic.AllAllergen(), x => DeleteAllergen(x), "delete")) { }
                                Console.Clear();
                                break;
                            case 6:
                                Console.Clear();
                                Console.WriteLine("Are you sure you want to quit! (Y: Sure, Other: Keep me here)");
                                if (Console.ReadKey().Key == ConsoleKey.Y)
                                {
                                    Console.Clear();
                                    running = false;
                                }
                                break;
                        }
                        break;
                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to leave! (Y: Sure, Other: Keep me here)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            running = false;
                        }
                        break;
                }
            }
        }

        public static bool Select(List<IngredientModel> ing, Action<IngredientModel> onSelect, string kind)
        {
            bool running = true;
            int selected = 0;
            int scrollOffset = 0;

            List<IngredientModel> ingredients = ing;

            while (running)
            {
                Console.Clear();

                int visibleCount = Math.Min(8, ingredients.Count - scrollOffset);
                List<IngredientModel> visibleIngredients = ingredients.Skip(scrollOffset).Take(visibleCount).ToList();

                Console.WriteLine($"Select one of the ingredients using arrow up (↑) and arrow down (↓), press enter to {kind} them. Press 'q' to leave.");
                DrawAccount(selected - scrollOffset, visibleIngredients);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                        {
                            selected--;
                            if (selected < scrollOffset)
                            {
                                scrollOffset--;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected < ingredients.Count - 1)
                        {
                            selected++;
                            if (selected >= scrollOffset + 8)
                            {
                                scrollOffset++;
                            }
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (ingredients.Count > 0)
                        {
                            onSelect(ingredients[selected]);
                            Console.Clear();
                            return true;
                        }
                        break;

                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to leave! (Y: Sure, Other: Keep me here)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            return false;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, please choose one of the options. Press any key to continue.");
                        Console.ReadKey(true);
                        break;
                }
            }
            return false;
        }

        public static void DrawAccount(int selected, List<IngredientModel> ingredients)
        {
            for (int i = 0; i < ingredients.Count; i++)
            {
                IngredientModel ingredient = ingredients[i];
                Console.ResetColor();
                if (i == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(ingredient.ToString());
                    continue;
                }
                Console.WriteLine(ingredient.ToString());
            }
            Console.ResetColor();
        }

        public static void CreateIngredient()
        {
            Console.WriteLine("Ingredient name: ");
            string? ingredientName = Console.ReadLine();
            while (!_ingredientsLogic.ValidName(ingredientName))
            {
                Console.WriteLine("Invalid ingredient name, please try again.");
                ingredientName = Console.ReadLine();
            }
            _ingredientsLogic.Create(ingredientName!);
            DrawBox("Success", "Thank you for adding a new ingredient!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void Edit(IngredientModel ingredient)
        {
            DrawBox("Edit Ingredient", $"Do you wish to change the ingredient name (y: Yes, Other: No) (current: {ingredient.Name}): ");
            string? ingredientName = null;
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("New name: ");
                ingredientName = Console.ReadLine();
                while (!_ingredientsLogic.ValidName(ingredientName))
                {
                    Console.WriteLine("Invalid ingredient name, please try again.");
                    ingredientName = Console.ReadLine();
                }
            }

            long allergenId = 0;
            Console.WriteLine($"Do you wish to link an allergen to this ingredient (y: Yes, Other: No)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                Console.WriteLine("Allergen to link: ");
                FoodAllergenModel? allergen = _ingredientsLogic.Allergen(ingredient);

                List<FoodAllergenModel> allergens = _allergenLogic.AllAllergen();
                if (allergen is not null)
                {
                    allergenId = allergen.Id;
                }

                Console.WriteLine($"Current allergen ({(allergen is not null ? allergen.Name : "None")})");
                foreach (var alrgen in allergens)
                {
                    Console.WriteLine($"{alrgen.Id}. {alrgen.Name}");
                }

                Console.WriteLine("Please enter the id for the allergen to link to the ingredient");
                while (true)
                {
                    string? aller = Console.ReadLine();
                    if (int.TryParse(aller, out int id))
                    {
                        FoodAllergenModel? allergenFood = allergens.Find(x => x.Id == id);
                        if (allergenFood is not null)
                        {
                            allergenId = allergenFood.Id;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number");
                    }
                }

                _ingredientsLogic.Update(ingredient, ingredientName, allergenId);
                DrawBox("Success", "Ingredient updated successfully!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void Delete(IngredientModel ingredient)
        {
            DrawBox("Delete Ingredient", $"Are you sure you want to delete {ingredient.Name}? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                _ingredientsLogic.Delete(ingredient);
                DrawBox("Success", "Ingredient deleted successfully!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void CreateAllergen()
        {
            DrawBox("Create Allergen", "Enter allergen details:");
            Console.Write("Name: ");
            string? allergenName = Console.ReadLine();
            if (string.IsNullOrEmpty(allergenName))
            {
                DrawBox("Error", "Allergen name cannot be empty!");
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
                return;
            }

            _allergenLogic.Create(allergenName);
            DrawBox("Success", "Thank you for adding a new allergen!");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        public static bool SelectAllergen(List<FoodAllergenModel> allergens, Action<FoodAllergenModel> onSelect, string kind)
        {
            bool running = true;
            int selected = 0;
            int scrollOffset = 0;

            while (running)
            {
                Console.Clear();

                int visibleCount = Math.Min(8, allergens.Count - scrollOffset);
                List<FoodAllergenModel> visibleAllergens = allergens.Skip(scrollOffset).Take(visibleCount).ToList();

                Console.WriteLine($"Select one of the allergens using arrow up (↑) and arrow down (↓), press enter to {kind} them. Press 'q' to leave.");
                DrawAllergen(selected - scrollOffset, visibleAllergens);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        if (selected > 0)
                        {
                            selected--;
                            if (selected < scrollOffset)
                            {
                                scrollOffset--;
                            }
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (selected < allergens.Count - 1)
                        {
                            selected++;
                            if (selected >= scrollOffset + 8)
                            {
                                scrollOffset++;
                            }
                        }
                        break;

                    case ConsoleKey.Enter:
                        if (allergens.Count > 0)
                        {
                            onSelect(allergens[selected]);
                            Console.Clear();
                            return true;
                        }
                        break;

                    case ConsoleKey.Q:
                        Console.Clear();
                        Console.WriteLine("Are you sure you want to leave! (Y: Sure, Other: Keep me here)");
                        if (Console.ReadKey(true).Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            return false;
                        }
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Invalid input, please choose one of the options. Press any key to continue.");
                        Console.ReadKey(true);
                        break;
                }
            }
            return false;
        }

        public static void DrawAllergen(int selected, List<FoodAllergenModel> allergens)
        {
            for (int i = 0; i < allergens.Count; i++)
            {
                FoodAllergenModel allergen = allergens[i];
                Console.ResetColor();
                if (i == selected)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{allergen.Id}. {allergen.Name}");
                    continue;
                }
                Console.WriteLine($"{allergen.Id}. {allergen.Name}");
            }
            Console.ResetColor();
        }

        private static void EditAllergen(FoodAllergenModel allergen)
        {
            DrawBox("Edit Allergen", $"Current name: {allergen.Name}\nEnter new name (or press Enter to keep current):");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                allergen.Name = newName;
                _allergenLogic.Update(allergen);
                DrawBox("Success", "Allergen updated successfully!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void DeleteAllergen(FoodAllergenModel allergen)
        {
            DrawBox("Delete Allergen", $"Are you sure you want to delete {allergen.Name}? (Y/N)");
            if (Console.ReadKey().Key == ConsoleKey.Y)
            {
                _allergenLogic.Delete(allergen);
                DrawBox("Success", "Allergen deleted successfully!");
            }
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }