using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using MyRecipes.Models;

namespace MyRecipes.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public RecipeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Recipe>().Wait();
        }

        //Loads recipes
        public Task<List<Recipe>> GetRecipeAsync()
        {
            return database.Table<Recipe>().ToListAsync();
        }

        //Loads a specific recipe
        public Task<Recipe> GetRecipeAsync(int id)
        {
            return database.Table<Recipe>()
                            .Where(i => i.ID == id)
                            .FirstOrDefaultAsync();
        }

        //Updates a recipe or adds a new one
        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.ID != 0)
            {
                return database.UpdateAsync(recipe);
            }
            else
            {
                return database.InsertAsync(recipe);
            }
        }

        //Deletes a recipe
        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return database.DeleteAsync(recipe);
        }
    }
}
