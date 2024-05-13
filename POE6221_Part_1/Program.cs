using POE6221_Part_1;
using System.Diagnostics.Metrics;
using System.Collections.Generic; 
using System.Threading.Channels;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        //declaration

        Recipes recipes = new Recipes();
     

        Console.Write("Enter recipe name: ");
       string recipeName = Console.ReadLine();
        recipes.Myrecipes.Add(recipeName);

        try
        {
            Console.Write("Enter number of ingridients for your recipe: ");
            int NumOfIngreds = int.Parse(Console.ReadLine());


            //instantiation :ingredients Array
            Ingredients[] ingredient = new Ingredients[NumOfIngreds];



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

                catch (Exception ex) { Console.WriteLine(ex.Message); }
            }



            //Recipe Menu List

            foreach (string recipe in recipes.Myrecipes)
            {

              Console.WriteLine();
              Console.WriteLine("=======================================");
              Console.WriteLine(recipe + " Steps :");

                for (int i = 0; i < NumOfIngreds; i++)
                {
                    Console.WriteLine();
                    // Formula formula = new Formula();    
                    Console.WriteLine($"Instruction {i + 1}: ");
                    ingredient[i].Display();
                    
                }
            }

            //Recipe Menu Method
            RecipeMenu(NumOfIngreds, ingredient, recipes);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        
    }




    //Recipe Menu
    public static void RecipeMenu(int NumOfIngreds, Ingredients[] ingredient, Recipes recipes)
    {

        for (int i = 0; i < NumOfIngreds; i++)
        {
            //Scale menu
            Console.WriteLine($"ingredint: {ingredient[i].IngredName} ");
            Console.WriteLine("Options: " +
              "\n 1. Add a scale factor to the recipe" +
              "\n 2. Reset ingredient quantity" +
              "\n 3. Clear all data" +
              "\n 4. Do not edit.");
            int menuOp = int.Parse(Console.ReadLine());

            //condition
            if (menuOp == 1)
            {

                Console.WriteLine("Measurement scale for ingredient : " +
                        "\n 1. 0.5" +
                        "\n 2. 2" +
                        "\n 3. 3" +
                        "\n 4. none");

                ingredient[i].ScaleCalc();

            }
            else if (menuOp == 2)
            {

                ingredient[i].ResetScale();
            }

            else if (menuOp == 3)
            {
                ingredient[i].ClearScale();
            }
        }
        Recipes.RecipeMenuOpt(recipes.Myrecipes, NumOfIngreds, ingredient);

    }
   

    }




 