using MyRecipes.Views;
using Xamarin.Forms;

namespace MyRecipes
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(AddRecipePage), typeof(AddRecipePage));
        }
    }
}