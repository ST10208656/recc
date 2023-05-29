using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;


namespace recc
{
    
    public class IngredientCopy//This class is a copy for the ingredients in a recipe that will come in useful when resetting to default values
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

    }
    
    // Recipe class
    
    public class RecipeCopy//This class is a copy for the ingredients in a recipe that will come in useful when resetting to default values
    {
        //It contains the same properties for the original recipe and above the same properties for the ingredients
        public string Name { get; set; }
        public List<IngredientCopy> Ingredient2 { get; set; }
      
    }

    public class Program
    {
        public static void Main()
        {
          
            RecipeManager app = new RecipeManager();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\tWELCOME TO THE COOKBOOK APP");
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press Enter to continue or any other key to exit...");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            //The prompt uses a key to continue to enter recipe
            if (keyInfo.Key == ConsoleKey.Enter)
            {
                //In order to not overload the code a clear method is used that will also help the console to appear better
                Console.Clear();
                //when user presses enter it immediately takes them to enter recipe
                app.EnterRecipe();
             
               
            }
            else
            {
                System.Environment.Exit(0);
                //The application will exit when the user presses any other key
            }
            bool running = true;
            while (running)//this displays the menu while the software is running
            {
                
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("----------------------------------------------------");
                Console.WriteLine("\t\tMAIN MENU");
                Console.WriteLine("----------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("1. Add more recipes");
                Console.WriteLine("2. Display all recipes");
                Console.WriteLine("3. Scale the quantity of the ingredients or reset the quantity");
                Console.WriteLine("4. Clear data of a recipe");
                Console.WriteLine("5. Exit");
            
                Console.WriteLine("Enter your choice:");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        app.EnterRecipe();
                        break;
                    case "2":
                        app.DisplayAllRecipes();
                       
                        break;
                    case "3":
                        app.AlterQuantity();
                        break;
                    case "4":
                       
                        app.DeleteRecipe();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}
    