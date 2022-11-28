using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MyRecipes;
using MyRecipes.Models;
using Xamarin.Forms;

namespace MyRecipes .Views
{
    public partial class RecipesPage : ContentPage
    {
        public RecipesPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            collectionView.ItemsSource = await App.Database.GetRecipeAsync();
        }

        async void OnAddRecipeClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync(nameof(AddRecipePage));
        }

        async void OnRecipeItemSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null)
            {
                Recipe recipe = (Recipe)e.CurrentSelection.FirstOrDefault();
                await Shell.Current.GoToAsync($"{nameof(AddRecipePage)}?{nameof(AddRecipePage.RecipeId)}={recipe.ID.ToString()}");
            }
        }
    }
}
