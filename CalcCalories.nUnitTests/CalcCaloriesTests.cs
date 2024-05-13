using POE6221_Part_1;
namespace CalcCalories.nUnitTests
{
    public class Tests
    {

        [Test]
    public void CalcCalories_ValidIngredients_ReturnsTotalCalories()
    {
        // Arrange
        Ingredients[] ingredients = new Ingredients[]
        {
            new Ingredients { Calories = 100, IngredQuantity = 2 },
            new Ingredients { Calories = 50, IngredQuantity = 2 },
            new Ingredients { Calories = 200, IngredQuantity = 1 }
        };

        // Act
        double totalCalories = Ingredients.CalcCalories(ingredients);

        // Assert
        Assert.AreEqual(500, totalCalories);
    }

 

    [Test]
    public void CalcCalories_EmptyIngredients_ReturnsZero()
    {
        // Arrange
        Ingredients[] ingredients = new Ingredients[0];

        // Act
        double totalCalories = Ingredients.CalcCalories(ingredients);

        // Assert
        Assert.AreEqual(0, totalCalories);
    }
}
    }

    
