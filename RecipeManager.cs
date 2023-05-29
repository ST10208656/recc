using System;
using System.Collections.Generic;
using System.Linq;



namespace recc
{

    public delegate void delDisplayNotification();//This is a delegate declared that will display a notification to the user when user exceeds 300 calories
    //The RecipeManager class is used to manage the recipe where you can modify recipes
    public class RecipeManager
    {

        public int calorie;


        private List<Recipe> recipes;//Creates a hidden list that repesents a field for the recipes list
        private List<RecipeCopy> copiedRecipes;//Creates a hidden copied list that repesents a field for the recipes list


        int choice = 0;




        public RecipeManager()
        {
            
            recipes = new List<Recipe>();//This creates a new instance of the recipes generic list
            copiedRecipes = new List<RecipeCopy>();//This creates a new instance of the copied recipes generic list

        }
        public static void DisplayNotification()//This method will be used to notify if user exceeds 300 calories 
        {
           Console.ForegroundColor= ConsoleColor.Red;
            Console.WriteLine("Warning!!! The recipe exceeds 300 calories!" + "\n" + "This means that the recipe is relatively high in calories compared to other recipes." + "\n" + "Please consider portion sizes and overall dietary balance when consuming high-calorie recipes");
            Console.ForegroundColor = ConsoleColor.White;
        }


        public void EnterRecipe()//method for when the user enters a recipe
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tENTER RECIPE");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;





           
            bool addingRecipe = false;

            while (addingRecipe == false)
            {
                Recipe recipe = new Recipe();
                RecipeCopy recipe2 = new RecipeCopy();




                bool isRecipeNameValid = false;
                while (isRecipeNameValid.Equals(false))//This will result in the user being constantly prompted to enter the appropriate value
                {
                    Console.WriteLine("Enter recipe name:");
                    recipe.Name = Console.ReadLine();
                    if (recipe.Name.Any(x => char.IsDigit(x)) || String.IsNullOrEmpty(recipe.Name))//This also applies to exception handling, these conditions need to be met for ingredient name which includes values not to be null/empty, should only contain letters
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("!Invalid input, Please Re-enter the name of recipe");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        isRecipeNameValid = true;
                        break;
                    }
                }
                recipe2.Name = recipe.Name;


                recipe.Ingredients = new List<Ingredient>();
                recipe2.Ingredient2 = new List<IngredientCopy>();
                recipe.Instructions = new List<Step>();



                bool addingIngredients = true;




                while (addingIngredients)//This will result in the user being constantly prompted to enter the ingredients until user wishes to exit
                {
                    Ingredient ingredient = new Ingredient();//This creates a new instance of the Ingredient class
                    IngredientCopy ingredient2 = new IngredientCopy();//This creates a new instance of a copied Ingredient class 


                    Console.WriteLine("Enter ingredient name (or 'done' to finish):");
                    string ingredientName = Console.ReadLine();

                    //if the user chooses to to input done for the ingredient name it will move onto the instructions
                    if (ingredientName.ToLower().Equals("done"))
                    {
                        addingIngredients = false;
                        break;
                    }

                    ingredient.Name = ingredientName;//The prompt takes a string and assign it as the name of ingredient
                    ingredient2.Name = ingredientName;

                    bool isQuantityValid = false;//Applies to exception handling, this boolean checks to see that the unit selected as a number is a number and not any other invalid input
                    while (isQuantityValid.Equals(false))//This will result in the user being constantly prompted to enter the appropriate value

                    {
                        try//Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                        {
                            Console.WriteLine("Enter quantity:");//This is the quantity of ingredient
                            ingredient.Quantity = Convert.ToDouble(Console.ReadLine());
                            ingredient2.Quantity = ingredient.Quantity;
                            isQuantityValid = true;
                        }
                        catch (Exception ex)//Checks and catches any possible exceptions that will arise
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reenter quantities.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    bool isUnitValid = false;//Applies to exception handling, this boolean checks to see that the unit selected as a number is a number and not any other invalid input
                    while (isUnitValid.Equals(false))//This will result in the user being constantly prompted to enter the appropriate value

                    {
                        try//Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                        {
                            Console.WriteLine("Please select the unit of measurement:" + "\n" + "1. Pinch" + "\n" + "2. Teaspoon" + "\n" + "3. Tablespoon" + "\n" + "4. Cup" + "\n" + "5. Pint\n" + "6. Quarts");
                            int choice1 = Convert.ToInt32(Console.ReadLine());
                            if (choice1 == 1)
                            {
                                ingredient.UnitOfMeasurement = "Pinch";
                                ingredient2.UnitOfMeasurement = "Pinch";//for all these if statements below, when the user selects a unit of measurements, the selected value gets assigned to the unitMeasure property in the ingredients class
                            }

                            if (choice1 == 2)
                            {
                                ingredient.UnitOfMeasurement = "Teaspoon";
                                ingredient2.UnitOfMeasurement = "Teaspoon";
                            }
                            if (choice1 == 3)
                            {
                                ingredient.UnitOfMeasurement = "Tablespoon";
                                ingredient2.UnitOfMeasurement = "Tablespoon";

                            }
                            if (choice1 == 4)
                            {
                                ingredient.UnitOfMeasurement = "Cup";
                                ingredient2.UnitOfMeasurement = "Cup";
                            }
                            if (choice1 == 5)
                            {
                                ingredient.UnitOfMeasurement = "Pint";
                                ingredient2.UnitOfMeasurement = "Pint";
                            }
                            if (choice1 == 6)
                            {
                                ingredient.UnitOfMeasurement = "Quart";
                                ingredient2.UnitOfMeasurement = "Quart";
                            }
                            isUnitValid = true;
                        }
                        catch (Exception ex)//Checks and catches any possible exceptions that will arise
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reselect unit of measurement.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    bool isCaloriesValid = false;
                    while (isCaloriesValid.Equals(false))//This will result in the user being constantly prompted to enter the appropriate value
                    {
                        try//Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                        {
                            Console.WriteLine("Enter food calories:");//This is the calories for the ingredient
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                            Console.ForegroundColor = ConsoleColor.Yellow;

                            Console.WriteLine("This is the amount of energy released when your body breaks down the food you hve eaten. The more calories a food has, the more energy it can provide to your body throughout the day but when you eat more calories than you need, your body stores the extra calories as body fat" + "\n" + "So be careful of how many calories your recipe has.");

                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------");
                            Console.WriteLine("Enter food calories here:");
                            ingredient.Calories = Convert.ToInt32(Console.ReadLine());
                            isCaloriesValid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reenter calories.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    calorie = ingredient.Calories;
                    ingredient2.Calories = ingredient.Calories;

                    bool isFoodGroupValid = false;
                    while (isFoodGroupValid.Equals(false))//This will result in the user being constantly prompted to enter the appropriate value
                    {
                        try//Overall this will try the following prompts and if it catches an exception/error, it will display the appropriate message and will let the user re-enter the value
                        {
                            Console.WriteLine("Please select the food group:" + "\n" + "1. Starchy foods" + "\n" + "2. Vegetable and fruits" + "\n" + "3. Dry beans, peas, lentils and soya" + "\n" + "4. Chicken, fish, meat and eggs" + "\n" + "5. Milk and dairy products" + "\n" + "6. Fats and oil" + "\n" + "7. Water");
                            int choice3 = Convert.ToInt32(Console.ReadLine());

                            if (choice3 == 1)
                            {
                                ingredient.FoodGroup = "Starchy foods";//for all these if statements below, when the user selects a food group, the selected value gets assigned to the food group property
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }

                            if (choice3 == 2)
                            {
                                ingredient.FoodGroup = "Vegetable and fruits";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 3)
                            {
                                ingredient.FoodGroup = "Dry beans, peas, lentils and soya";

                            }
                            if (choice3 == 4)
                            {
                                ingredient.FoodGroup = "Chicken, fish, meat and eggs";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 5)
                            {
                                ingredient.FoodGroup = "Milk and dairy products";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            if (choice3 == 6)
                            {
                                ingredient.FoodGroup = "Fats and oil";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }

                            if (choice3 == 7)
                            {
                                ingredient.FoodGroup = "Water";
                                ingredient2.FoodGroup = ingredient.FoodGroup;
                            }
                            isFoodGroupValid = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please reselect food group.");
                            Console.ForegroundColor = ConsoleColor.White;
                        }

                    }
                    recipe.Ingredients.Add(ingredient);//It adds all the values for the ingredients class and adds them to the recipe
                    recipe2.Ingredient2.Add(ingredient2);
                    int totalCalories = CalculateTotalCalories(recipe.Ingredients);//Ater the user enters the caloris this method calculates it to add up the total calories and give the appropriate message


                }



                bool addingInstructions = true;
                while (addingInstructions)//will comstantly prompt the user to add instruction until the user wishes to exit
                {


                    Step instruction = new Step();//Creates a new instance for the step class so that it can take in values as instructions
                    bool isInstructionValid = false;//Applies to exception handling, this boolean checks to see that the number of instructions is a number and not any other invalid input


                    while (isInstructionValid.Equals(false))//results in users being constantly prompted to enter correct values
                    {
                        Console.WriteLine("Enter instructions or done to finish:");
                        string instructions = Console.ReadLine();
                        if (instructions.ToLower().Equals("done"))
                        {
                            addingInstructions = false;
                            break;
                        }
                        if (instructions.Any(x => char.IsDigit(x)) || String.IsNullOrEmpty(instructions))//This also applies to exception handling, these conditions need to be met for ingredient name which includes values not to be null/empty, should only contain letters
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid input, Please Re-enter the instructions ");
                            Console.ForegroundColor = ConsoleColor.White;
                            isInstructionValid = true;
                        }
                        else
                        {
                            isInstructionValid = true;
                            break;
                        }

                        instruction.Steps = instructions;//Takes the string used and assigns it to the instruction method
                        recipe.Instructions.Add(instruction);//After assigned it gets added to the recipe class

                    }
                }

                recipes.Add(recipe);
                copiedRecipes.Add(recipe2);
                recipes.Sort((r1, r2) => string.Compare(r1.Name, r2.Name, StringComparison.OrdinalIgnoreCase));//Used to sort the recipe names in alphabetical order


              

                Console.WriteLine("INGREDIENTS ENTERED CRRECTLY");

                Console.WriteLine("Press 1 to enter another recipe or any key to continue to main menu");
                string choice4 = Console.ReadLine();

                if (choice4.Equals("1"))
                {
                    addingRecipe = false;
                    addingInstructions = true;
                    addingIngredients = true;
                }
                else
                {
                    addingRecipe = true;
                    addingInstructions = false;
                    addingIngredients = false;
                }

            }







        }
        public int CalculateTotalCalories(List<Ingredient> ingredients)
        {
            delDisplayNotification printDelegate = new delDisplayNotification(DisplayNotification);

            int total = 0;
            foreach (Ingredient ingredient in ingredients)
            {
                total += ingredient.Calories;
            }

            if (total > 300)
            {

                printDelegate();

            }



            return total;
        }

        public void AlterQuantity()//This method is to amend the quantity of ingredients by scaling, converting units of measurement
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tSCALE QUANTITY");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("----------------------------------------------------");
            Console.Clear();
            Console.WriteLine("List of recipes:");
            int recipeIndex = 1;

            foreach (Recipe recipe in recipes)
            {

                Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                recipeIndex++;
            }

            Console.Write("Select a recipe (enter the corresponding number): ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int selectedRecipeIndex))
            {
                if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)
                {

                    Recipe recipeToScale = recipes[selectedRecipeIndex - 1];//inds the recipe based on the index requested
                    double comma;
                    foreach (Ingredient ingredient in recipeToScale.Ingredients)
                    {
                        Console.WriteLine("Please select if you wish to:" + "\n" + "1. Half the quantity" + "\n" + "2. Double the quantity" + "\n" + "3. Triple the quantity" + "\n" + "4. Reset to defaut values");
                        choice = Convert.ToInt32(Console.ReadLine());

                        if (choice == 1)
                        {

                            ingredient.Quantity = ingredient.Quantity * 0.5;//if user chooses 1 to half the ingredients, the quanity of the ingredient will be halfed with this arithemtic operation

                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            Console.Clear();
                            Console.WriteLine("Recipe scaled successfully");


                            
                            return;
                        }

                        if (choice == 2)
                        {

                            ingredient.Quantity = ingredient.Quantity * 2;//if user chooses 1 to half the ingredients, the quanity of the ingredient will be halfed with this arithemtic operation


                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                           
                        }
                        if (choice == 3)
                        {

                            ingredient.Quantity = ingredient.Quantity * 3;//if user chooses 1 to half the ingredients, the quanity of the ingredient will be halfed with this arithemtic operation


                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Pinch"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";


                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pinch";
                            }
                            if (ingredient.Quantity >= 3 && ingredient.UnitOfMeasurement.Equals("Teaspoon"))
                            {
                                comma = ingredient.Quantity / 3;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity * 3;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Teaspoon";
                            }
                            if (ingredient.Quantity >= 16 && ingredient.UnitOfMeasurement.Equals("Tablespoon"))
                            {
                                comma = ingredient.Quantity / 16;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";

                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity * 16;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Tablespoon";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Cup"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }
                            if ((ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Pint")))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Cup";
                            }
                            if (ingredient.Quantity >= 2 && ingredient.UnitOfMeasurement.Equals("Pint"))
                            {
                                comma = ingredient.Quantity / 2;//This will divide the quantity if program is converting up automatically and will change the unit of measurement to the one you converted up to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Quart";
                            }
                            if (ingredient.Quantity <= 1 && ingredient.UnitOfMeasurement.Equals("Quart"))
                            {
                                comma = ingredient.Quantity * 2;//This will multiply the quantity if program is converting down automatically and will change the unit of measurement to the one you converted down to
                                ingredient.Quantity = comma;
                                ingredient.UnitOfMeasurement = "Pint";
                            }

                            Console.Clear();
                            Console.WriteLine("Recipe scaled successfully");


                            return;
                        


                        }

                        if (choice == 4)//This will reset the values of the ingredients to its original value
                        {
                            if (selectedRecipeIndex > 0 && selectedRecipeIndex <= copiedRecipes.Count)
                            {
                                Recipe recipeToReset = recipes[selectedRecipeIndex - 1];//gets the index of the recipe to reset
                                RecipeCopy recipe2 = copiedRecipes[selectedRecipeIndex - 1];//gets the index of the recipe that will provide the original values
                                foreach (Ingredient ingredient1 in recipeToReset.Ingredients)
                                    recipeToReset.Ingredients = recipe2.Ingredient2.Select(Ingredient2 => new Ingredient
                                    {
                                        Name = Ingredient2.Name,
                                        Quantity = Ingredient2.Quantity,
                                        UnitOfMeasurement = Ingredient2.UnitOfMeasurement,
                                        Calories = Ingredient2.Calories,
                                        FoodGroup = Ingredient2.FoodGroup,
                                    }).ToList();//Assigns the copied recipe that has the original values therefore resetting it
                            }
                            Console.Clear();
                            Console.WriteLine("Recipe reset successfully");


                           
                            return;
                        }
                     
                    }
                    Console.Clear();
                    Console.WriteLine("Recipe scaled successfully");



                    return;
                }
            }


            else
            {
                Console.WriteLine("Recipe not found.");
            }
        }

        public void DisplayAllRecipes()//This method displays all the recipes
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("\t\t\tDISPLAY RECIPE");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("----------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            string input = null;
            foreach (Recipe recipe in recipes)//It gets the recipe instance in the recipe class to view the recipe
            {
                if (recipe.Name.Equals(null))
                {

                    break;

                }

                else
                {
                    int recipeIndex = 1;
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine("List of recipes:");

                    Console.WriteLine($"{recipeIndex}. {recipe.Name}");//Displays the list of recipes in alphabetical order
                    recipeIndex++;
                    Console.WriteLine("----------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Select a recipe (enter the corresponding number): ");//Use a number to slect the recipes displayed
                    input = Console.ReadLine();
                }
            }



            if (int.TryParse(input, out int selectedRecipeIndex))
            {
                if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)//Checks to see if the recipe is identified and exists
                {

                    Recipe selectedRecipe = recipes[selectedRecipeIndex - 1];//Fetches the recipe based its position searched for
                    int totalCalories = CalculateTotalCalories(selectedRecipe.Ingredients);
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Clear();    
                    Console.WriteLine("----------------------------------------------------");
                    Console.WriteLine($"\t\t\tRecipe: {selectedRecipe.Name.ToUpper()}");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("----------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("INGREDIENTS:");
                    Console.ForegroundColor = ConsoleColor.White;

                    foreach (Ingredient ingredient in selectedRecipe.Ingredients)
                    {
                        if (ingredient.Quantity > 1 && ingredient.UnitOfMeasurement.EndsWith("ch"))//This is string manipulation where I see if the unit measure is a plural and then i manipulate the text so that it represents a plural, this is for pinches
                        {
                            Console.WriteLine(ingredient.Quantity + " " + ingredient.UnitOfMeasurement + "es " + "of " + ingredient.Name);
                        }
                        else if (ingredient.Quantity > 1)//This is string manipulation where if the unit measure is a plural and then i manipulate the text so that it represents a plural, this is for the rest of the ingredients
                        {

                            Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.UnitOfMeasurement + "s " + "of " + ingredient.Name);


                        }
                        else if (ingredient.Quantity <= 1)//This is string manipulation where I see if the unit measure is a plural and then i manipulate the text so that it represents a plural, this is for pinches
                        {


                            Console.WriteLine("- " + ingredient.Quantity + " " + ingredient.UnitOfMeasurement + " of " + ingredient.Name);

                        }



                    }
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("INSTRUCTIONS:");
                    Console.ForegroundColor = ConsoleColor.White;
                    int index = 1;

                    foreach (Step instruction in selectedRecipe.Instructions)
                    {
                        index++;
                        Console.WriteLine("Step " + index + " " + instruction.Steps);
                    }
                    Console.WriteLine("Total calories is: " + totalCalories);//Uses a total calories variable that was assigned the total calories method to determine the calorie range for the total calories

                    if (totalCalories < 100)
                    {
                        Console.WriteLine("Calorie Range: Low (< 100)");
                    }
                    else if (totalCalories >= 100 && totalCalories < 300)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Calorie Range: Medium (100 - 299)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (totalCalories >= 300 && totalCalories < 500)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("Calorie Range: High (300 - 499)");//displays calorie range
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (totalCalories >= 500)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Calorie Range: Very High (500 or more)");
                        Console.ForegroundColor = ConsoleColor.White;
                    }


                    Console.WriteLine("Press ENTER to continue to main menu");

                    ConsoleKeyInfo keyInfo = Console.ReadKey();

                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        return;//when user presses enter the application returns to the main menu screen
                       

                    }

                }

                else
                {
                    Console.WriteLine("Invalid recipe selection.");
                }
            }
            else
            {
                Console.WriteLine("Recipe not found, please enter recipe from the main menu.");
            }



        }

        public void DeleteRecipe()
        {
            Console.Clear();
            Console.WriteLine("List of recipes:");
            int recipeIndex = 1;

            foreach (Recipe recipe in recipes)
            {

                Console.WriteLine($"{recipeIndex}. {recipe.Name}");
                recipeIndex++;
            }

            Console.Write("Select a recipe (enter the corresponding number): ");
            string input = Console.ReadLine();//selects the recipe from the list of recipes to delete

            if (int.TryParse(input, out int selectedRecipeIndex))
            {
                if (selectedRecipeIndex > 0 && selectedRecipeIndex <= recipes.Count)//uses to see if the recipe exist
                {

                    Recipe recipeToRemove = recipes[selectedRecipeIndex - 1];//fetches the variable by the requested position
                    Console.WriteLine("Are you sure you want to remove recipe??" + "\n" + "Press 1 for yes and 2 for no");
                    int choice3 = Convert.ToInt32(Console.ReadLine());

                    if (choice3 > 1)
                    {
                        recipes.Remove(recipeToRemove);//Once user is asked are you sure the recipes gets removed from the recipes list
                        Console.Clear();

                        Console.WriteLine("Recipe cleared successfully.");
                        return;
                    }
                    if (choice3 > 1)
                    {
                        return;
                    }
                }
            }
        }
    }
}
