using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace RubiksCubeSolver
{
    public partial class App : Application
    {
        public App()
        {
            MainPage = new NavigationPage(new MainPage());
        }
    }
}
