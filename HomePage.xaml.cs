using Microsoft.Maui.Controls;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            InitializePage();
        }

        private async void InitializePage()
        {
            // Выполнение тяжелых задач
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            // Например, загрузка данных из сети или базы данных
            await Task.Delay(1000); // Симуляция задержки
        }

        private void OnEnterCubeColorsClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }

        private void OnInfoClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new InfoPage());
        }
    }
}
