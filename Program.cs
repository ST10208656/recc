using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recc
{
    
    public class Ingredient2
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string UnitOfMeasurement { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }

    }
    
    // Recipe class
    
    public class Recipe2
    {
        public string Name { get; set; }
        public List<Ingredient2> Ingredient2 { get; set; }
      
    }

    // RecipeApp class

    

    // Example usage
    public class Program
    {
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RecipeManager app = new RecipeManager();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\tWELCOME TO THE COOKBOOK APP");
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Press Enter to continue or any other key to exit...");

            ConsoleKeyInfo keyInfo = Console.ReadKey();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                app.EnterRecipe();
                // Add your code for what happens when the user presses Enter
               
            }
            else
            {
                System.Environment.Exit(0);
                // Add your code for what happens when the user presses any other key
            }
            bool running = true;
            while (running)
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
    