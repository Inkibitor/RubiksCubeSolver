using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using CubeXdotNET;
using Kociemba;

namespace RubiksCubeSolver
{
    public partial class ShowSolutionPage : ContentPage
    {
        private SolutionsViewModel ViewModel { get; set; }
        private CancellationTokenSource _cancellationTokenSource;

        public ShowSolutionPage(string FridrichCube, string KociembaCube)
        {
            InitializeComponent();
            ViewModel = new SolutionsViewModel();
            BindingContext = ViewModel;
            ViewModel.InitialFridrichCube = FridrichCube;
            ViewModel.InitialKociembaCube = KociembaCube;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _cancellationTokenSource = new CancellationTokenSource();
            _ = LoadSolutionsAsync(); // Ignoring the task to avoid warning
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
        }

        public async Task LoadSolutionsAsync()
        {
            await ViewModel.LoadSolutionsAsync(this, _cancellationTokenSource.Token);
        }

        private void OnSolutionButtonClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var solution = button?.CommandParameter as Solution;
            if (solution != null)
            {
                // Сохранение выбранного решения в ViewModel для дальнейшего использования
                ViewModel.SelectedSolution = solution;
                ReadyLayout.IsVisible = true;
            }
        }

        private async void OnReadyButtonClicked(object sender, EventArgs e)
        {
            ReadyLayout.IsVisible = false;

            // Использование выбранного решения из ViewModel
            var solution = ViewModel.SelectedSolution;
            if (solution != null)
            {
                await Navigation.PushAsync(new SolutionPage(solution.Steps, solution.InitialCubeState));
            }
        }

        private void OnCancelButtonClicked(object sender, EventArgs e)
        {
            ReadyLayout.IsVisible = false;
        }

        public class Solution
        {
            public string Description { get; set; }
            public List<string> Steps { get; set; }
            public string InitialCubeState { get; set; }

            public string StepsCount => $"Steps count: {Steps.Count}";
        }

        public class SolutionsViewModel : INotifyPropertyChanged
        {
            private ObservableCollection<Solution> solutions;
            private bool isLoading;
            private Solution selectedSolution;

            public string InitialFridrichCube { get; set; }
            public string InitialKociembaCube { get; set; }

            public ObservableCollection<Solution> Solutions
            {
                get { return solutions; }
                set
                {
                    solutions = value;
                    OnPropertyChanged(nameof(Solutions));
                }
            }

            public bool IsLoading
            {
                get { return isLoading; }
                set
                {
                    isLoading = value;
                    OnPropertyChanged(nameof(IsLoading));
                }
            }

            // Добавляем свойство для хранения выбранного решения
            public Solution SelectedSolution
            {
                get { return selectedSolution; }
                set
                {
                    selectedSolution = value;
                    OnPropertyChanged(nameof(SelectedSolution));
                }
            }

            public SolutionsViewModel()
            {
                Solutions = new ObservableCollection<Solution>();
            }

            public async Task LoadSolutionsAsync(BindableObject bindableObject, CancellationToken cancellationToken)
            {
                IsLoading = true;

                try
                {
                    await foreach (var solution in GetSolutions(InitialFridrichCube, InitialKociembaCube, cancellationToken))
                    {
                        bindableObject.Dispatcher.Dispatch(() =>
                        {
                            if (!Solutions.Any(s => s.Steps.SequenceEqual(solution.Steps)))
                            {
                                Solutions.Add(solution);
                            }
                        });

                        if (solution.Steps.Count == 1)
                        {
                            break;
                        }

                        await Task.Delay(500);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Handle the cancellation if needed
                }
                finally
                {
                    IsLoading = false;
                }
            }

            private async IAsyncEnumerable<Solution> GetSolutions(string FridrichCube, string KociembaCube, [System.Runtime.CompilerServices.EnumeratorCancellation] CancellationToken cancellationToken)
            {
                var FridrichState = FridrichCube;
                var KociembaState = KociembaCube;

                var potentialSolutions = new List<Func<Task<Solution>>>
                {
                    async () => new Solution
                    {
                        Description = "Fridrich (CFOP) method",
                        Steps = await Task.Run(() => CFOPsolver(FridrichState)),
                        InitialCubeState = FridrichState
                    }
                };

                for (int i = 22; i <= 23; i += 2)
                {
                    int index = i;
                    potentialSolutions.Add(async () => new Solution
                    {
                        Description = "Optimal solution",
                        Steps = await Task.Run(() => KociembaCubeSolver(RubiksCube.ConvertForKociemba(KociembaState), index)
                            .Split(' ')
                            .Where(step => !string.IsNullOrWhiteSpace(step))
                            .ToList()),
                        InitialCubeState = FridrichCube
                    });
                }

                potentialSolutions.Add(async () => new Solution
                {
                    Description = "Optimal solution",
                    Steps = await Task.Run(() => KociembaCubeSolver(RubiksCube.ConvertForKociemba(KociembaState), 21)
                        .Split(' ')
                        .Where(step => !string.IsNullOrWhiteSpace(step))
                        .ToList()),
                    InitialCubeState = FridrichCube
                });

                for (int i = 19; i <= 20; i++)
                {
                    int index = i;
                    potentialSolutions.Add(async () => new Solution
                    {
                        Description = "Optimal solution",
                        Steps = await Task.Run(() => KociembaCubeSolver(RubiksCube.ConvertForKociemba(KociembaState), index)
                            .Split(' ')
                            .Where(step => !string.IsNullOrWhiteSpace(step))
                            .ToList()),
                        InitialCubeState = FridrichCube
                    });
                }

                for (int i = 17; i <= 18; i++)
                {
                    int index = i;
                    potentialSolutions.Add(async () => new Solution
                    {
                        Description = "Optimal solution",
                        Steps = await Task.Run(() => KociembaCubeSolver(RubiksCube.ConvertForKociemba(KociembaState), index)
                            .Split(' ')
                            .Where(step => !string.IsNullOrWhiteSpace(step))
                            .ToList()),
                        InitialCubeState = FridrichCube
                    });
                }

                foreach (var getSolution in potentialSolutions)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        yield break;
                    }

                    var solution = await getSolution();
                    if (!Solutions.Any(s => s.Steps.SequenceEqual(solution.Steps)))
                    {
                        yield return solution;

                        if (solution.Steps.Count == 1)
                        {
                            yield break;
                        }
                    }
                }
            }


            public static string KociembaCubeSolver(string cubeState, int depth)
            {
                string info = "";
                string solution = Search.solution(cubeState, out info, depth);
                return solution;
            }

            private List<string> CFOPsolver(string FridrichState)
            {
                var solver = new FridrichSolver(FridrichState);
                solver.Solve();
                var solution = solver.Solution.Split(' ').ToList();
                return solution;
            }

            public event PropertyChangedEventHandler PropertyChanged;

            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
