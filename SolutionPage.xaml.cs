using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;

namespace RubiksCubeSolver
{
    public partial class SolutionPage : ContentPage
    {
        private List<string> _steps;
        private int _currentStep;
        private char[] _cubeStates;

        private readonly int[] _readOrder = {
             42, 39, 36, 43, 40, 37, 44, 41, 38 , // Желтая грань  
             27, 28, 29, 30, 31, 32, 33, 34, 35, // Красная грань
             0, 1, 2, 3, 4 ,5, 6, 7, 8, // Зеленая грань
             9, 10, 11, 12, 13, 14, 15, 16, 17, // Оранжевая грань
             18, 19, 20, 21, 22, 23, 24, 25, 26, // Синяя грань
             47, 50, 53, 46, 49, 52, 45, 48, 51  // Белая грань
        };

        public SolutionPage(List<string> solutionSteps, string initialCubeState)
        {
            InitializeComponent();
            _steps = solutionSteps ?? new List<string>();
            _currentStep = 0;
            _cubeStates = initialCubeState.ToCharArray();

            InitializeCubeColors();

            if (_steps.Count > 0)
            {
                ApplyStepToCube(_steps[_currentStep]);
                ShowStep(_currentStep);
            }
            else
            {
                DisplayAlert("Error", "No solution steps provided.", "OK");
            }
        }

        private void InitializeCubeColors()
        {
            for (int i = 0; i < 54; i++)
            {
                var frameName = $"Face{i}";
                var frame = this.FindByName<Frame>(frameName);
                if (frame != null)
                {
                    frame.BackgroundColor = ConvertCharToColor(_cubeStates[_readOrder[i]]);
                }
            }
        }

        private Color ConvertCharToColor(char colorChar)
        {
            return colorChar switch
            {
                'y' => Colors.Yellow,
                'r' => Colors.Red,
                'g' => Colors.Green,
                'o' => Colors.Orange,
                'b' => Colors.Blue,
                'w' => Colors.White,
                _ => Colors.Gray
            };
        }

        private void ShowStep(int stepIndex)
        {
            StepCounterLabel.Text = $"{stepIndex + 1}/{_steps.Count}";
            string step = _steps[stepIndex];
            LoadMediaForStep(step);
        }

        private void LoadMediaForStep(string step)
        {
            string mediaFile = GetMediaFilePath(step);
            if (VideoPlayer != null)
            {
                VideoPlayer.Stop(); // Остановить воспроизведение видео
                VideoPlayer.Source = mediaFile;
                VideoPlayer.Play(); // Начать воспроизведение видео
            }
        }

        private string GetMediaFilePath(string step)
        {
            CurrentStepLabel.Text = $"{step}";
            string fileName = ConvertStepToFileName(step) + ".mp4";
            return $"file:///android_asset/Resources/Raw/{fileName}";
        }


        private string ConvertStepToFileName(string step)
        {
            return step switch
            {
                "D" => "D",
                "D'" => "D-",
                "D2" => "D2",
                "F" => "F",
                "F'" => "F-",
                "F2" => "F2",
                "R" => "R",
                "R'" => "R-",
                "R2" => "R2",
                "U" => "U",
                "U'" => "U-",
                "U2" => "U2",
                "L" => "L",
                "L'" => "L-",
                "L2" => "L2",
                "B" => "B",
                "B'" => "B-",
                "B2" => "B2",
                _ => throw new ArgumentException($"Unknown step: {step}")
            };
        }

        private void OnNextClicked(object sender, EventArgs e)
        {
            if (_currentStep < _steps.Count - 1)
            {
                _currentStep++;
                ApplyStepToCube(_steps[_currentStep]);
                ShowStep(_currentStep);
            }
        }

        private void OnPreviousClicked(object sender, EventArgs e)
        {
            if (_currentStep > 0)
            {
                string previousStep = _steps[_currentStep];
                OppositeStepToCube(previousStep);
                _currentStep--;
                StepCounterLabel.Text = $"{_currentStep + 1}/{_steps.Count}";
                CurrentStepLabel.Text = $"{_steps[_currentStep]}";
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (VideoPlayer != null)
            {
                VideoPlayer.Stop();
                VideoPlayer.Dispose();
            }
        }

        private void UpdateCubeColors()
        {
            for (int i = 0; i < 54; i++)
            {
                var frameName = $"Face{i}";
                var frame = this.FindByName<Frame>(frameName);
                if (frame != null)
                {
                    frame.BackgroundColor = ConvertCharToColor(_cubeStates[_readOrder[i]]);
                }
            }
        }
        private void ApplyStepToCube(string step)
        {
            switch (step)
            {
                case "U":
                    RotationsChanges.U(ref _cubeStates);
                    break;
                case "U'":
                    RotationsChanges.Ucounter(ref _cubeStates);
                    break;
                case "U2":
                    RotationsChanges.U2(ref _cubeStates);
                    break;
                case "D":
                    RotationsChanges.D(ref _cubeStates);
                    break;
                case "D'":
                    RotationsChanges.Dcounter(ref _cubeStates);
                    break;
                case "D2":
                    RotationsChanges.D2(ref _cubeStates);
                    break;
                case "R":
                    RotationsChanges.R(ref _cubeStates);
                    break;
                case "R'":
                    RotationsChanges.Rcounter(ref _cubeStates);
                    break;
                case "R2":
                    RotationsChanges.R2(ref _cubeStates);
                    break;
                case "L":
                    RotationsChanges.L(ref _cubeStates);
                    break;
                case "L'":
                    RotationsChanges.Lcounter(ref _cubeStates);
                    break;
                case "L2":
                    RotationsChanges.L2(ref _cubeStates);
                    break;
                case "F":
                    RotationsChanges.F(ref _cubeStates);
                    break;
                case "F'":
                    RotationsChanges.Fcounter(ref _cubeStates);
                    break;
                case "F2":
                    RotationsChanges.F2(ref _cubeStates);
                    break;
                case "B":
                    RotationsChanges.B(ref _cubeStates);
                    break;
                case "B'":
                    RotationsChanges.Bcounter(ref _cubeStates);
                    break;
                case "B2":
                    RotationsChanges.B2(ref _cubeStates);
                    break;
            }
            UpdateCubeColors();
        }

        private void OppositeStepToCube(string step)
        {
            switch (step)
            {
                case "U":
                    RotationsChanges.Ucounter(ref _cubeStates);
                    break;
                case "U'":
                    RotationsChanges.U(ref _cubeStates);
                    break;
                case "U2":
                    RotationsChanges.U2(ref _cubeStates);
                    break;
                case "D":
                    RotationsChanges.Dcounter(ref _cubeStates);
                    break;
                case "D'":
                    RotationsChanges.D(ref _cubeStates);
                    break;
                case "D2":
                    RotationsChanges.D2(ref _cubeStates);
                    break;
                case "R":
                    RotationsChanges.Rcounter(ref _cubeStates);
                    break;
                case "R'":
                    RotationsChanges.R(ref _cubeStates);
                    break;
                case "R2":
                    RotationsChanges.R2(ref _cubeStates);
                    break;
                case "L":
                    RotationsChanges.Lcounter(ref _cubeStates);
                    break;
                case "L'":
                    RotationsChanges.L(ref _cubeStates);
                    break;
                case "L2":
                    RotationsChanges.L2(ref _cubeStates);
                    break;
                case "F":
                    RotationsChanges.Fcounter(ref _cubeStates);
                    break;
                case "F'":
                    RotationsChanges.F(ref _cubeStates);
                    break;
                case "F2":
                    RotationsChanges.F2(ref _cubeStates);
                    break;
                case "B":
                    RotationsChanges.Bcounter(ref _cubeStates);
                    break;
                case "B'":
                    RotationsChanges.B(ref _cubeStates);
                    break;
                case "B2":
                    RotationsChanges.B2(ref _cubeStates);
                    break;
            }
            UpdateCubeColors();
        }
    }
}
