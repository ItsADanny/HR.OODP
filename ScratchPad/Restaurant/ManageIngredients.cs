using Project.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.Presentation
{
    class ManageIngredients
    {

        public static void Start()
        {
            while (true)
            {
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("                     Manage Ingredients                  ");
                Console.WriteLine("---------------------------------------------------------");

                Console.WriteLine("1. View all ingredients ");
                Console.WriteLine("2. Match ingredient to menu item");
                Console.WriteLine("3. Create new ingredient");
                Console.WriteLine("4. View all allergens");
                Console.WriteLine("5. Match allergen to ingredient");
                Console.WriteLine("6. Edit allergens");
                Console.WriteLine("7. Quit");

                Console.WriteLine("Enter the number: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1: ViewAllIngredients(); break;
                        case 2: IngredientMatchFoodItem(); break;
                        case 3: CreateNewIngredient(); break;
                        case 4: ViewAllAllergens(); break;
                        case 5: IngredientMatchAllergen(); break;
                        case 6: EditAllergens(); break;
                        case 7: return;
                        default: Console.WriteLine("Invalid choice."); break;
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a number between 1 and 7.");
                    Console.ReadKey();
                }

            }
        }
        public static void ViewAllIngredients()
        {
            List<string> names = IngredientLogic.GetAllIngredientNames();

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                   View all ingredients                  ");
            Console.WriteLine("---------------------------------------------------------");

            //for (int i = 0; names.Count < 0; i++)
            //{
            //    Console.WriteLine($"{i + 1}. {names[i]}");
            //}

            int rows = 15;
            int columns = (names.Count + rows - 1) / rows;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int index = row + col * rows;
                    if (index < names.Count)
                    {
                        Console.WriteLine($"{index + 1}. {names[index],-15}");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public static void IngredientMatchFoodItem()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                 add ingredient to menu item                  ");
            Console.WriteLine("---------------------------------------------------------");

            List<FoodItemModel> fooditems = FoodItemLogic.AllFoodItem();
            Console.WriteLine("menu items: ");
            for (int i = 0; i < fooditems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {fooditems[i].Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Select food item by number: ");
            if (!int.TryParse(Console.ReadLine(), out int foodItemChoice) || foodItemChoice < 1 || foodItemChoice > fooditems.Count)
            {
                Console.WriteLine("invalid food item");
                return;
            }

            int foodItemId = fooditems[foodItemChoice - 1].Id;

            List<IngredientModel> ingredients = IngredientLogic.GetAllIngredients();
            Console.WriteLine("ingredients: ");
            for (int i = 0; i < ingredients.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ingredients[i].Name}");
            }
            Console.WriteLine();
            Console.WriteLine("Select food item by number: ");
            if (!int.TryParse(Console.ReadLine(), out int ingredientchoice) || ingredientchoice < 1 || ingredientchoice > ingredients.Count)
            {
                Console.WriteLine("invalid ingredient");
                return;
            }

            int ingredientId = ingredients[ingredientchoice - 1].Id;

            IngredientFoodItemAccess link = new IngredientFoodItemModel
            {
                Food_Item_id = foodItemId,
                Ingredient_id = ingredientId
            };
            IngredientFoodItemAccess

        }

        public static void CreateNewIngredient()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                 create new ingredients                  ");
            Console.WriteLine("---------------------------------------------------------");

            
            string? ingredientName;
            do
            {
                Console.Write("Enter the name of the new ingredient: ");
                ingredientName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredientName))
                {
                    Console.WriteLine("Must enter a name");
                }
            } while (string.IsNullOrWhiteSpace(ingredientName));


               
            //string? name;
            //do
            //{
            //    Console.Write("Name: ");
            //    name = Console.ReadLine();
            //    if (string.IsNullOrWhiteSpace(name))
            //        Console.WriteLine("Name is required.");
            //} while (string.IsNullOrWhiteSpace(name));

        }
        public static void ViewAllAllergens()
        {
            List<string> names = AllergenLogic.GetAllergenNames();

            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("                       allergens                         ");
            Console.WriteLine("---------------------------------------------------------");

            int rows = 6;
            int columns = (names.Count + rows - 1) / rows;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    int index = row + col * rows;
                    if (index < names.Count)
                    {
                        Console.WriteLine($"{index + 1}. {names[index],-15}");
                    }
                    Console.WriteLine();
                }
            }

        }

        //for (int i = 0; i < names.Count; i++)
        //{
        //    Console.WriteLine($"{i + 1}. {names[i]}");
        //}

        public static void IngredientMatchAllergen()
        {
            Console.WriteLine("---------------------------------------------------------");
            Console.WriteLine("             match ingredient to allergens               ");
            Console.WriteLine("---------------------------------------------------------");

        }
        public static void EditAllergens()
        {

        }

    }
}

