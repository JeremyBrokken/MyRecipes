using System;
using SQLite;

namespace MyRecipes.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public string Ingredients { get; set; }
        public string Steps { get; set; }
    }
}
