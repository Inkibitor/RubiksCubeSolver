using System;
using Microsoft.Maui.Controls;
using CubeXdotNET;

namespace RubiksCubeSolver
{
    public partial class MainPage : ContentPage
    {
        private RubiksCube _rubiksCube;
        private Button _selectedColorButton;

        public MainPage()
        {
            InitializeComponent();
            _rubiksCube = new RubiksCube();
            AddTapGestures();
        }

        private void AddTapGestures()
        {
            var grids = new[] { RedFace, OrangeFace, GreenFace, BlueFace, YellowFace, WhiteFace };
            foreach (var grid in grids)
            {
                foreach (var child in grid.Children)
                {
                    if (child is Frame frame)
                    {
                        int boxIndex = GetBoxIndex(frame);
                        if (boxIndex == 4 || boxIndex == 13 || boxIndex == 22 || boxIndex == 31 || boxIndex == 40 || boxIndex == 49)
                        {
                            continue;
                        }

                        var tapGesture = new TapGestureRecognizer();
                        tapGesture.Tapped += (s, e) => OnFrameTapped(frame);
                        frame.GestureRecognizers.Add(tapGesture);
                    }
                }
            }
        }

        private void OnFrameTapped(Frame frame)
        {
            if (_selectedColorButton == null)
                return;

            frame.BackgroundColor = _selectedColorButton.BackgroundColor;

            int boxIndex = GetBoxIndex(frame);
            if (boxIndex != -1)
            {
                var colorChars = new[] { 'r', 'g', 'b', 'y', 'o', 'w' };
                var colors = new[] { Colors.Red, Colors.Green, Colors.Blue, Colors.Yellow, Colors.Orange, Colors.White };
                var selectedColor = _selectedColorButton.BackgroundColor;
                var index = Array.IndexOf(colors, selectedColor);
                if (index != -1)
                {
                    _rubiksCube.UpdateColor(boxIndex, colorChars[index]);
                }
            }
        }

        private void OnColorButtonClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                SetSelectedColorButton(button);
            }
        }

        private void SetSelectedColorButton(Button button)
        {
            if (_selectedColorButton != null)
            {
                _selectedColorButton.Style = (Style)Resources["UnselectedButtonStyle"];
            }

            _selectedColorButton = button;
            _selectedColorButton.Style = (Style)Resources["SelectedButtonStyle"];
        }

        private int GetBoxIndex(Frame frame)
        {
            if (frame.Parent == RedFace) return GetIndexInGrid(RedFace, frame) + 27;
            if (frame.Parent == OrangeFace) return GetIndexInGrid(OrangeFace, frame) + 9;
            if (frame.Parent == GreenFace) return GetIndexInGrid(GreenFace, frame);
            if (frame.Parent == BlueFace) return GetIndexInGrid(BlueFace, frame) + 18;
            if (frame.Parent == YellowFace) return GetIndexInGrid(YellowFace, frame) + 36;
            if (frame.Parent == WhiteFace) return GetIndexInGrid(WhiteFace, frame) + 45;
            return -1;
        }

        private static int GetIndexInGrid(Grid grid, Frame frame)
        {
            int row = Grid.GetRow(frame);
            int column = Grid.GetColumn(frame);
            return row * 3 + column;
        }

        private bool HasEmptyCells()
        {
            var grids = new[] { RedFace, OrangeFace, GreenFace, BlueFace, YellowFace, WhiteFace };
            foreach (var grid in grids)
            {
                foreach (var child in grid.Children)
                {
                    if (child is Frame frame)
                    {
                        if (frame.BackgroundColor == Colors.Gray)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        private async void OnSolveCubeClicked(object sender, EventArgs e)
        {
            if (HasEmptyCells())
            {
                await DisplayAlert("Error", "This cube could not be solved, fix your colors", "OK");
                return;
            }

            if (_rubiksCube.FridrichGetCubeState() == "gggggggggooooooooobbbbbbbbbrrrrrrrrryyyyyyyyywwwwwwwww")
            {
                await DisplayAlert("Error", "This cube is already solved", "OK");
                return;
            }

            // Show a slight delay to give the user feedback of ongoing processing
            await Task.Delay(100);

            // Run the cube-solving logic asynchronously to avoid blocking the UI thread
            bool solved = await Task.Run(() => SolveCube());

            if (solved)
            {
                string FridrichCurrentState = _rubiksCube.FridrichGetCubeState();
                string KociembaCurrentState = _rubiksCube.KociembaGetCubeState();

                // Pre-initialize the next page
                var showSolutionPage = await Task.Run(() => new ShowSolutionPage(FridrichCurrentState, KociembaCurrentState));

                // Navigate to the pre-initialized page
                await Navigation.PushAsync(showSolutionPage);
            }
            else
            {
                await DisplayAlert("Error", "This cube could not be solved, fix your colors", "OK");
            }
        }


        private bool SolveCube()
        {
            string currentState = _rubiksCube.FridrichGetCubeState();
            var solver = new FridrichSolver(currentState);

            solver.Solve();

            return solver.IsSolved;
        }

        private void OnResetButtonClicked(object sender, EventArgs e)
        {
            ResetFaceColors(WhiteFace, Colors.White);
            ResetFaceColors(RedFace, Colors.Red);
            ResetFaceColors(GreenFace, Colors.Green);
            ResetFaceColors(YellowFace, Colors.Yellow);
            ResetFaceColors(BlueFace, Colors.Blue);
            ResetFaceColors(OrangeFace, Colors.Orange);
        }

        private void ResetFaceColors(Grid face, Color centerColor)
        {
            foreach (var child in face.Children)
            {
                if (child is Frame frame)
                {
                    int boxIndex = GetBoxIndex(frame);
                    if (boxIndex == 4 || boxIndex == 13 || boxIndex == 22 || boxIndex == 31 || boxIndex == 40 || boxIndex == 49)
                    {
                        frame.BackgroundColor = centerColor;
                    }
                    else
                    {
                        frame.BackgroundColor = Colors.Gray;
                    }
                }
            }
        }
    }
}
