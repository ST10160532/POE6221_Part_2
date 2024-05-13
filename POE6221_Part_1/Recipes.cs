using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static POE6221_Part_1.Ingredients;

namespace POE6221_Part_1
{
    public class Recipes
    {
        private List<string> myrecipes;
        private Ingredients[] ingredients;
        private Formula[] formulas;

        public List<string> Myrecipes
        {
            get { return myrecipes; }
            set { myrecipes = value; }
        }
        public Ingredients[] Ingreds
        {
            get { return ingredients; }
            set { ingredients = value; }
        }
        public Formula[] Formula
        {
            get { return formulas; }
            set { formulas = value; }
        }

        public Recipes()
        {
            myrecipes = new List<string>();

        }



        public Recipes(Ingredients[] ingredients)
        {
            this.ingredients = ingredients;
            this.formulas = formulas;
        }

       
        


        public static void RecipeMenuOpt(List<string> myrecipes, int NumOfIngreds, Ingredients[] ingredient)
        {
            Ingredients ingredients = new Ingredients();

            // infinite new recipe menu with its ingredisnts
            for (; ; )
            {

                Console.WriteLine();
                Console.WriteLine("====================================================");
                Console.WriteLine("Recipe Menu:" +
                    "\n 1. Add a recipe" +
                    "\n 2. Diplay a recipe" +
                    "\n 3. Display all recipes");
                int recipeMenu = int.Parse(Console.ReadLine());

                switch (recipeMenu)
                {
                    case 1:
                        Console.Write("Enter recipe name: ");
                        myrecipes.Add(Console.ReadLine());

                        try
                        {
                            Console.Write("Enter number of ingridients for your recipe: ");
                            NumOfIngreds = int.Parse(Console.ReadLine());

                            for (int i = 0; i < NumOfIngreds; i++)
                            {
                                string ingredName;


                                //input
                                //number of ingredients to enter
                                if (NumOfIngreds <= 1)
                                {
                                    Console.Write("Enter ingredient name: ");
                                    ingredName = Console.ReadLine();
                                }
                                else
                                {
                                    Console.Write($"Enter ingredient name {i + 1}: ");
                                    ingredName = Console.ReadLine();

                                }
                                Console.Write("Food Group: ");
                                string foodGroup = Console.ReadLine();

                                Console.Write("Number of calories: ");
                              int calories = int.Parse(Console.ReadLine());

                                //input
                                try
                                {
                                    Console.Write("Ingredient quantity: ");
                                    int ingredQuantity = int.Parse(Console.ReadLine());

                                    Console.Write("Ingredient in measurement: ");
                                    string ingredMeasurement = Console.ReadLine();


                                    //steps
                                    int numOfSteps;
                                    try
                                    {
                                        Console.Write("Enter number of steps for the recipe: ");
                                        numOfSteps = int.Parse(Console.ReadLine());

                                        //instatntiation : Steps Array
                                        Formula[] formula = new Formula[numOfSteps];

                                        for (int j = 0; j < numOfSteps; j++)
                                        {
                                            formula[j] = new Formula();
                                            Console.Write($"Step {j + 1} : ");
                                            formula[j].IngredInstruction = Console.ReadLine();
                                            Console.WriteLine();
                                        }

                                        ingredient[i] = new Ingredients(formula, ingredMeasurement, ingredQuantity, ingredName, calories, foodGroup);

                                    }

                                    catch (Exception ex)
                                    {

                                        Console.WriteLine(ex.Message);
                                    }
                                }

                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                            }
                            Recipes.RecipeMenuOpt(myrecipes, NumOfIngreds, ingredient);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }

                        break;

                    case 2:
                        DisplaySpecificRecipe(myrecipes, ingredient);
                        NotifyCalories_specificRecipe(ingredient);
                        break;

                    case 3:
                        DisplayRecipeInroder(myrecipes, ingredient);
                        NotifyCalories_recipeOrder(ingredient);


                        break;

                }
            }
         }


        //Display a specific Recipe Method
        public static void DisplaySpecificRecipe(List<string> myrecipes, Ingredients[] ingredients)
        {
            Ingredients ingreds = new Ingredients();
            Console.Write("Enter the number of the recipes you want to display: ");//A specific recipe to display
            int recipeNum = int.Parse(Console.ReadLine()) - 1; // subtract 1 because list indices start at 0

            if (recipeNum >= 0 && recipeNum < myrecipes.Count)
            {
                string selectedRecipe = myrecipes[recipeNum];
                Console.WriteLine($" {selectedRecipe} {Ingredients.CalcCalories(ingredients)} Calories");
            }
            else
            {
                Console.WriteLine("Invalid recipe number");
            }
        }


        //Notitfication meessage method
        public static void NotificationMessage(string message)
        {
            Console.WriteLine(message);
        }

       


        //Specific Recipe message condition
        public static void NotifyCalories_specificRecipe(Ingredients[] ingredients )
        {

            Ingredients ingreds = new Ingredients();    
            CaloriesNotifier caloriesNotifier = new CaloriesNotifier(NotificationMessage);
            if (Ingredients.CalcCalories(ingredients) > 300)
            {
                caloriesNotifier("Note: Calories have exceeded 300!");
            }
            

        }



        //Display all recipes in order
        public static void DisplayRecipeInroder(List<string> myrecipes, Ingredients[] ingredients)
        {
            Ingredients ingreds = new Ingredients();
          

            var sortedRecipe = myrecipes.OrderBy(x => x).ToList();

            foreach (var Names in sortedRecipe)
            {

                Console.WriteLine($"{Names} {Ingredients.CalcCalories(ingredients)}   Calories");
            }

        }

        //Calories inOrder message condition
        public static void NotifyCalories_recipeOrder( Ingredients[] ingredients)
        {
            Ingredients ingreds = new Ingredients();

            CaloriesNotifier caloriesNotifier = new CaloriesNotifier(NotificationMessage);
            if (Ingredients.CalcCalories(ingredients) > 300)
            {
                caloriesNotifier("Note: Calories have exceeded 300!");
            }
           

        }
    }
        } 
