using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Text;
using Kociemba;

namespace RubiksCubeSolver
{
    public partial class App : Application
    {
        private const string FirstRunKey = "IsFirstRun";

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new HomePage());
        }
        protected override void OnStart()
        {
            base.OnStart();

            if (IsFirstRun())
            {
                InstallFiles();
                SetFirstRunFlag();
            }
        }
        private bool IsFirstRun()
        {
            return Preferences.Get(FirstRunKey, true);
        }

        private void SetFirstRunFlag()
        {
            Preferences.Set(FirstRunKey, false);
        }

        private void InstallFiles()
        {
            string info = "";
            string solution = SearchRunTime.solution("UUUUUUUUUBBBRRRRRRRRRFFFFFFDDDDDDDDDFFFLLLLLLLLLBBBBBB", out info, 20, 6000, false, true);
        }
    }
}
