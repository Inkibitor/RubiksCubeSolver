namespace RubiksCubeSolver
{
    public class RubiksCube
    {
        private char[] _cubeState;

        // Порядок индексов для чтения состояния кубика
        private readonly int[] _KociembaReadOrder = {
             38, 41, 44, 37, 40, 43, 36, 39, 42, // Желтая грань
             11, 14, 17, 10, 13, 16, 9, 12, 15, // Оранжевая грань
             2, 5, 8, 1, 4 ,7, 0, 3, 6,     // Зеленая грань
             47, 50, 53, 46, 49, 52, 45, 48, 51,  // Белая грань
             29, 32, 35, 28, 31, 34, 27, 30, 33, // Красная грань
             20, 23, 26, 19, 22, 25, 18, 21, 24, // Синяя грань
        };

        // Порядок индексов для чтения состояния кубика
        private readonly int[] _FridrichReadOrder = {
                     2, 5, 8, 1, 4 ,7, 0, 3, 6,     // Зеленая грань
                     11, 14, 17, 10, 13, 16, 9, 12, 15, // Оранжевая грань
                     20, 23, 26, 19, 22, 25, 18, 21, 24, // Синяя грань
                     29, 32, 35, 28, 31, 34, 27, 30, 33, // Красная грань
                     44, 43, 42, 41, 40, 39, 38, 37, 36, // Желтая грань
                     45, 46, 47, 48, 49, 50, 51, 52, 53  // Белая грань
                };

        public RubiksCube()
        {
            _cubeState = new char[54];
            // Инициализация кубика в состоянии решенного кубика
            for (int i = 0; i < 9; i++) _cubeState[i] = 'g';
            for (int i = 9; i < 18; i++) _cubeState[i] = 'o';
            for (int i = 18; i < 27; i++) _cubeState[i] = 'b';
            for (int i = 27; i < 36; i++) _cubeState[i] = 'r';
            for (int i = 36; i < 45; i++) _cubeState[i] = 'y';
            for (int i = 45; i < 54; i++) _cubeState[i] = 'w';
        }

        public void UpdateColor(int index, char color)
        {
            _cubeState[index] = color;
        }

        public string FridrichGetCubeState()
        {
            char[] orderedState = new char[54];
            for (int i = 0; i < 54; i++)
            {
                orderedState[i] = _cubeState[_FridrichReadOrder[i]];
            }
            return new string(orderedState);
        }

        public string KociembaGetCubeState()
        {
            char[] orderedState = new char[54];
            for (int i = 0; i < 54; i++)
            {
                orderedState[i] = _cubeState[_KociembaReadOrder[i]];
            }
            return new string(orderedState);
        }
        public static string ConvertForKociemba(string cubeState)
        {
            return cubeState
                .Replace('r', 'L')  // Orange -> Left
                .Replace('o', 'R')  // Red -> Right
                .Replace('y', 'U')  // Yellow -> Up
                .Replace('w', 'D')  // White -> Down
                .Replace('g', 'F')  // Green -> Front
                .Replace('b', 'B'); // Blue -> Back
        }

    }
}