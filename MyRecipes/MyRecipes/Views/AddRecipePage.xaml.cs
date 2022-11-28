using System;
using System.IO;
using MyRecipes.Models;
using Xamarin.Forms;

namespace MyRecipes.Views
{
    [QueryProperty(nameof(RecipeId), nameof(RecipeId))]
    public partial class AddRecipePage : ContentPage
    {
        public string RecipeId
        {
            set
            {
                LoadRecipe(value);
            }
        }

        // Set the binding context to a new Recipe.
        public AddRecipePage()
        {
            InitializeComponent();
            BindingContext = new Recipe();
        }

        async void LoadRecipe(string recipeId)
        {
            try
            {
                int id = Convert.ToInt32(recipeId);
                // Retrieve the note and set it as the BindingContext of the page.
                Recipe recipe = await App.Database.GetRecipeAsync(id);
                BindingContext = recipe;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to load recipe.");
            }
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            if (recipe != null)
            {
                await App.Database.SaveRecipeAsync(recipe);
            }

            // Return to the main page.
            await Shell.Current.GoToAsync("..");
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);

            // Return to the main page.
            await Shell.Current.GoToAsync("..");
        }
    }
}