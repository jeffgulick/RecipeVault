using Microsoft.EntityFrameworkCore;
using RecipeVault.Models;

namespace RecipeVault.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new AppDbContext(serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>());

        if (context.Recipes.Any()) 
        {
            return;
        }

        var categories = new Category[]
        {
            new Category { CategoryName = "Desserts" },
            new Category { CategoryName = "Main Courses" },
            new Category { CategoryName = "Appetizers" },
            new Category { CategoryName = "Beverages" },
            new Category { CategoryName = "Salads" },
            new Category { CategoryName = "Soups" },
            new Category { CategoryName = "Breakfast" }
        };

        var ingredients = new Ingredient[]
        {
            new Ingredient { IngredientName = "Sugar" },
            new Ingredient { IngredientName = "Salt" },
            new Ingredient { IngredientName = "Butter" },
            new Ingredient { IngredientName = "Flour" },
            new Ingredient { IngredientName = "Eggs" },
            new Ingredient { IngredientName = "Milk" },
            new Ingredient { IngredientName = "Chicken" },
            new Ingredient { IngredientName = "Garlic" },
            new Ingredient { IngredientName = "Olive Oil" },
            new Ingredient { IngredientName = "Tomatoes" },
            new Ingredient { IngredientName = "Lettuce" },
            new Ingredient { IngredientName = "Lemon" },
            new Ingredient { IngredientName = "Vanilla Extract" },
            new Ingredient { IngredientName = "Baking Powder" },
            new Ingredient { IngredientName = "Baking Soda" },
            new Ingredient { IngredientName = "Cocoa Powder" },
            new Ingredient { IngredientName = "Brown Sugar" },
            new Ingredient { IngredientName = "Honey" },
            new Ingredient { IngredientName = "Cinnamon" },
            new Ingredient { IngredientName = "Nutmeg" },
            new Ingredient { IngredientName = "Ginger" },
            new Ingredient { IngredientName = "Onion" },
            new Ingredient { IngredientName = "Bell Pepper" },
            new Ingredient { IngredientName = "Carrot" },
            new Ingredient { IngredientName = "Celery" },
            new Ingredient { IngredientName = "Potato" },
            new Ingredient { IngredientName = "Cheese" },
            new Ingredient { IngredientName = "Yogurt" },
            new Ingredient { IngredientName = "Spinach" },
            new Ingredient { IngredientName = "Broccoli" },
            new Ingredient { IngredientName = "Bacon" },
            new Ingredient { IngredientName = "Maple Syrup" },
            new Ingredient { IngredientName = "Oats" },
            new Ingredient { IngredientName = "Blueberries" },
            new Ingredient { IngredientName = "Strawberries" },
            new Ingredient { IngredientName = "Banana" },
            new Ingredient { IngredientName = "Pasta" },
            new Ingredient { IngredientName = "Ground Beef" },
            new Ingredient { IngredientName = "Parmesan Cheese" },
            new Ingredient { IngredientName = "Basil" },
            new Ingredient { IngredientName = "Mozzarella Cheese" },
            new Ingredient { IngredientName = "Bread" },
            new Ingredient { IngredientName = "Rice" },
            new Ingredient { IngredientName = "Soy Sauce" },
            new Ingredient { IngredientName = "Peanut Butter" },
            new Ingredient { IngredientName = "Jelly" }
        };

        context.Categories.AddRange(categories);
        context.Ingredients.AddRange(ingredients);

        context.Recipes.AddRange(
            new Recipe
            {
                RecipeName = "Chocolate Cake",
                Description = "A delicious chocolate cake",
                Instructions = "Mix ingredients and bake",
                CookTime = new TimeSpan(0, 45, 0),
                ImageURL = "img/CarouselOne.jpg",
                Category = categories[0],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[0] }, // Sugar
                    new RecipeIngredient { Ingredient = ingredients[2] }, // Butter
                    new RecipeIngredient { Ingredient = ingredients[3] }, // Flour
                    new RecipeIngredient { Ingredient = ingredients[4] }, // Eggs
                    new RecipeIngredient { Ingredient = ingredients[5] }, // Milk
                    new RecipeIngredient { Ingredient = ingredients[12] }, // Vanilla Extract
                    new RecipeIngredient { Ingredient = ingredients[13] }, // Baking Powder
                    new RecipeIngredient { Ingredient = ingredients[14] }, // Baking Soda
                    new RecipeIngredient { Ingredient = ingredients[15] }  // Cocoa Powder
                }
            },
            new Recipe
            {
                RecipeName = "Grilled Chicken",
                Description = "Juicy grilled chicken",
                Instructions = "Grill the chicken with spices",
                CookTime = new TimeSpan(0, 30, 0),
                ImageURL = "img/CarouselTwo.jpg",
                Category = categories[1],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[6] }, // Chicken
                    new RecipeIngredient { Ingredient = ingredients[1] }, // Salt
                    new RecipeIngredient { Ingredient = ingredients[7] }, // Garlic
                    new RecipeIngredient { Ingredient = ingredients[8] }  // Olive Oil
                }
            },
            new Recipe
            {
                RecipeName = "Garlic Bread",
                Description = "Crispy garlic bread",
                Instructions = "Bake the bread with garlic butter",
                CookTime = new TimeSpan(0, 20, 0),
                ImageURL = "img/CarouselThree.jpg",
                Category = categories[2],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[2] }, // Butter
                    new RecipeIngredient { Ingredient = ingredients[7] }, // Garlic
                    new RecipeIngredient { Ingredient = ingredients[3] }  // Flour
                }
            },
            new Recipe
            {
                RecipeName = "Lemonade",
                Description = "Refreshing lemonade",
                Instructions = "Mix lemon juice with water and sugar",
                CookTime = new TimeSpan(0, 10, 0),
                ImageURL = "img/CarouselFour.jpg",
                Category = categories[3],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[0] }, // Sugar
                    new RecipeIngredient { Ingredient = ingredients[11] } // Lemon
                }
            },
            new Recipe
            {
                RecipeName = "Caesar Salad",
                Description = "Classic Caesar salad",
                Instructions = "Mix lettuce with Caesar dressing",
                CookTime = new TimeSpan(0, 15, 0),
                ImageURL = "img/CarouselFive.jpg",
                Category = categories[4],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[10] }, // Lettuce
                    new RecipeIngredient { Ingredient = ingredients[8] },  // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[1] }   // Salt
                }
            },
            new Recipe
            {
                RecipeName = "Pancakes",
                Description = "Fluffy pancakes",
                Instructions = "Mix ingredients and cook on griddle",
                CookTime = new TimeSpan(0, 20, 0),
                ImageURL = "img/CarouselSix.jpg",
                Category = categories[6],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[0] }, // Sugar
                    new RecipeIngredient { Ingredient = ingredients[2] }, // Butter
                    new RecipeIngredient { Ingredient = ingredients[3] }, // Flour
                    new RecipeIngredient { Ingredient = ingredients[4] }, // Eggs
                    new RecipeIngredient { Ingredient = ingredients[5] }, // Milk
                    new RecipeIngredient { Ingredient = ingredients[13] }, // Baking Powder
                    new RecipeIngredient { Ingredient = ingredients[34] }  // Maple Syrup
                }
            },
            new Recipe
            {
                RecipeName = "Spaghetti Bolognese",
                Description = "Classic Italian pasta dish",
                Instructions = "Cook pasta and mix with sauce",
                CookTime = new TimeSpan(0, 40, 0),
                ImageURL = "img/CarouselSeven.jpg",
                Category = categories[1],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[36] }, // Pasta
                    new RecipeIngredient { Ingredient = ingredients[37] }, // Ground Beef
                    new RecipeIngredient { Ingredient = ingredients[9] },  // Tomatoes
                    new RecipeIngredient { Ingredient = ingredients[8] },  // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[1] }   // Salt
                }
            },
            new Recipe
            {
                RecipeName = "Tomato Soup",
                Description = "Warm and comforting tomato soup",
                Instructions = "Cook tomatoes and blend",
                CookTime = new TimeSpan(0, 30, 0),
                ImageURL = "img/CarouselEight.jpg",
                Category = categories[5],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[9] },  // Tomatoes
                    new RecipeIngredient { Ingredient = ingredients[8] },  // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[1] },  // Salt
                    new RecipeIngredient { Ingredient = ingredients[22] }  // Onion
                }
            },
            new Recipe
            {
                RecipeName = "Fruit Salad",
                Description = "Fresh and healthy fruit salad",
                Instructions = "Mix all fruits together",
                CookTime = new TimeSpan(0, 10, 0),
                ImageURL = "img/CarouselNine.jpg",
                Category = categories[4],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[35] }, // Blueberries
                    new RecipeIngredient { Ingredient = ingredients[36] }, // Strawberries
                    new RecipeIngredient { Ingredient = ingredients[37] }  // Banana
                }
            },
            new Recipe
            {
                RecipeName = "Beef Stew",
                Description = "Hearty beef stew",
                Instructions = "Cook beef and vegetables together",
                CookTime = new TimeSpan(1, 30, 0),
                ImageURL = "img/CarouselTen.jpg",
                Category = categories[1],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[37] }, // Ground Beef
                    new RecipeIngredient { Ingredient = ingredients[22] }, // Onion
                    new RecipeIngredient { Ingredient = ingredients[23] }, // Bell Pepper
                    new RecipeIngredient { Ingredient = ingredients[24] }, // Carrot
                    new RecipeIngredient { Ingredient = ingredients[25] }  // Celery
                }
            },
            new Recipe
            {
                RecipeName = "Chicken Alfredo",
                Description = "Creamy chicken alfredo pasta",
                Instructions = "Cook pasta and mix with alfredo sauce and chicken",
                CookTime = new TimeSpan(0, 30, 0),
                ImageURL = "img/CarouselEleven.jpg",
                Category = categories[1],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[6] }, // Chicken
                    new RecipeIngredient { Ingredient = ingredients[2] }, // Butter
                    new RecipeIngredient { Ingredient = ingredients[8] }, // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[5] }  // Milk
                }
            },
            new Recipe
            {
                RecipeName = "Vegetable Stir Fry",
                Description = "Quick and easy vegetable stir fry",
                Instructions = "Stir fry vegetables with soy sauce",
                CookTime = new TimeSpan(0, 20, 0),
                ImageURL = "img/CarouselTwelve.jpg",
                Category = categories[1],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[22] }, // Onion
                    new RecipeIngredient { Ingredient = ingredients[23] }, // Bell Pepper
                    new RecipeIngredient { Ingredient = ingredients[24] }, // Carrot
                    new RecipeIngredient { Ingredient = ingredients[25] }, // Celery
                    new RecipeIngredient { Ingredient = ingredients[30] }  // Soy Sauce
                }
            },
            new Recipe
            {
                RecipeName = "Chocolate Chip Cookies",
                Description = "Delicious chocolate chip cookies",
                Instructions = "Mix ingredients and bake",
                CookTime = new TimeSpan(0, 15, 0),
                ImageURL = "img/CarouselThirteen.jpg",
                Category = categories[0],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[0] }, // Sugar
                    new RecipeIngredient { Ingredient = ingredients[2] }, // Butter
                    new RecipeIngredient { Ingredient = ingredients[3] }, // Flour
                    new RecipeIngredient { Ingredient = ingredients[4] }, // Eggs
                    new RecipeIngredient { Ingredient = ingredients[15] }  // Cocoa Powder
                }
            },
            new Recipe
            {
                RecipeName = "Greek Salad",
                Description = "Fresh and healthy Greek salad",
                Instructions = "Mix vegetables with olive oil and feta cheese",
                CookTime = new TimeSpan(0, 10, 0),
                ImageURL = "img/CarouselFourteen.jpg",
                Category = categories[4],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[10] }, // Lettuce
                    new RecipeIngredient { Ingredient = ingredients[22] }, // Onion
                    new RecipeIngredient { Ingredient = ingredients[23] }, // Bell Pepper
                    new RecipeIngredient { Ingredient = ingredients[8] },  // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[26] }  // Cheese
                }
            },
            new Recipe
            {
                RecipeName = "Tomato Basil Soup",
                Description = "Warm and comforting tomato basil soup",
                Instructions = "Cook tomatoes and basil together and blend",
                CookTime = new TimeSpan(0, 30, 0),
                ImageURL = "img/CarouselFifteen.jpg",
                Category = categories[5],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[9] },  // Tomatoes
                    new RecipeIngredient { Ingredient = ingredients[8] },  // Olive Oil
                    new RecipeIngredient { Ingredient = ingredients[1] },  // Salt
                    new RecipeIngredient { Ingredient = ingredients[27] }  // Basil
                }
            },
            new Recipe
            {
                RecipeName = "Vegetable Soup",
                Description = "Healthy vegetable soup",
                Instructions = "Cook vegetables in broth",
                CookTime = new TimeSpan(0, 45, 0),
                ImageURL = "img/CarouselSixteen.jpg",
                Category = categories[5],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[22] }, // Onion
                    new RecipeIngredient { Ingredient = ingredients[23] }, // Bell Pepper
                    new RecipeIngredient { Ingredient = ingredients[24] }, // Carrot
                    new RecipeIngredient { Ingredient = ingredients[25] }, // Celery
                    new RecipeIngredient { Ingredient = ingredients[9] }   // Tomatoes
                }
            },
            new Recipe
            {
                RecipeName = "Fruit Smoothie",
                Description = "Refreshing fruit smoothie",
                Instructions = "Blend fruits with yogurt",
                CookTime = new TimeSpan(0, 10, 0),
                ImageURL = "img/CarouselOne.jpg",
                Category = categories[3],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[35] }, // Blueberries
                    new RecipeIngredient { Ingredient = ingredients[36] }, // Strawberries
                    new RecipeIngredient { Ingredient = ingredients[37] }, // Banana
                    new RecipeIngredient { Ingredient = ingredients[28] }  // Yogurt
                }
            },
            new Recipe
            {
                RecipeName = "Grilled Cheese Sandwich",
                Description = "Classic grilled cheese sandwich",
                Instructions = "Grill bread with cheese",
                CookTime = new TimeSpan(0, 15, 0),
                ImageURL = "img/CarouselTwo.jpg",
                Category = categories[2],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[3] },  // Flour
                    new RecipeIngredient { Ingredient = ingredients[2] },  // Butter
                    new RecipeIngredient { Ingredient = ingredients[26] }  // Cheese
                }
            },
            new Recipe
            {
                RecipeName = "Oatmeal",
                Description = "Healthy oatmeal breakfast",
                Instructions = "Cook oats with milk and add fruits",
                CookTime = new TimeSpan(0, 10, 0),
                ImageURL = "img/CarouselThree.jpg",
                Category = categories[6],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[33] }, // Oats
                    new RecipeIngredient { Ingredient = ingredients[5] },  // Milk
                    new RecipeIngredient { Ingredient = ingredients[35] }, // Blueberries
                    new RecipeIngredient { Ingredient = ingredients[36] }  // Strawberries
                }
            },
            new Recipe
            {
                RecipeName = "Chicken Salad",
                Description = "Healthy chicken salad",
                Instructions = "Mix chicken with vegetables and dressing",
                CookTime = new TimeSpan(0, 20, 0),
                ImageURL = "img/CarouselOne.jpg",
                Category = categories[4],
                RecipeIngredients = new List<RecipeIngredient>
                {
                    new RecipeIngredient { Ingredient = ingredients[6] },  // Chicken
                    new RecipeIngredient { Ingredient = ingredients[10] }, // Lettuce
                    new RecipeIngredient { Ingredient = ingredients[22] }, // Onion
                    new RecipeIngredient { Ingredient = ingredients[23] }, // Bell Pepper
                    new RecipeIngredient { Ingredient = ingredients[8] }   // Olive Oil
                }
            }

        );

        context.SaveChanges();
    }
}