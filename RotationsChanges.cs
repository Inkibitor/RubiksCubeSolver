using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RubiksCubeSolver
{
    public class RotationsChanges
    {

        public static void U(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[36] = _cubeStates[42];
            newCubeState[37] = _cubeStates[39];
            newCubeState[38] = _cubeStates[36];
            newCubeState[39] = _cubeStates[43];
            newCubeState[41] = _cubeStates[37];
            newCubeState[42] = _cubeStates[44];
            newCubeState[43] = _cubeStates[41];
            newCubeState[44] = _cubeStates[38];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[0 + i] = _cubeStates[9 + i];
                newCubeState[9 + i] = _cubeStates[18 + i]; 
                newCubeState[18 + i] = _cubeStates[27 + i];
                newCubeState[27 + i] = _cubeStates[0 + i]; 
            }

            _cubeStates = newCubeState;
        }
        public static void Ucounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[36] = _cubeStates[38];
            newCubeState[37] = _cubeStates[41];
            newCubeState[38] = _cubeStates[44];
            newCubeState[39] = _cubeStates[37];
            newCubeState[41] = _cubeStates[43];
            newCubeState[42] = _cubeStates[36];
            newCubeState[43] = _cubeStates[39];
            newCubeState[44] = _cubeStates[42];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[0 + i] = _cubeStates[27 + i]; 
                newCubeState[9 + i] = _cubeStates[0 + i];
                newCubeState[18 + i] = _cubeStates[9 + i];
                newCubeState[27 + i] = _cubeStates[18 + i];
            }

            _cubeStates = newCubeState;
        }

        public static void U2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[36] = _cubeStates[44];
            newCubeState[37] = _cubeStates[43];
            newCubeState[38] = _cubeStates[42];
            newCubeState[39] = _cubeStates[41];
            newCubeState[41] = _cubeStates[39];
            newCubeState[42] = _cubeStates[38];
            newCubeState[43] = _cubeStates[37];
            newCubeState[44] = _cubeStates[36];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[0 + i] = _cubeStates[18 + i];
                newCubeState[9 + i] = _cubeStates[27 + i];
                newCubeState[18 + i] = _cubeStates[0 + i]; 
                newCubeState[27 + i] = _cubeStates[9 + i]; 
            }

            _cubeStates = newCubeState;
        }
        public static void D(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[45] = _cubeStates[51];
            newCubeState[46] = _cubeStates[48];
            newCubeState[47] = _cubeStates[45];
            newCubeState[48] = _cubeStates[52];
            newCubeState[50] = _cubeStates[46];
            newCubeState[51] = _cubeStates[53];
            newCubeState[52] = _cubeStates[50];
            newCubeState[53] = _cubeStates[47];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[6 + i] = _cubeStates[33 + i];
                newCubeState[15 + i] = _cubeStates[6 + i];
                newCubeState[24 + i] = _cubeStates[15 + i];
                newCubeState[33 + i] = _cubeStates[24 + i];
            }

            _cubeStates = newCubeState;
        }

        public static void Dcounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[45] = _cubeStates[47];
            newCubeState[46] = _cubeStates[50];
            newCubeState[47] = _cubeStates[53];
            newCubeState[48] = _cubeStates[46];
            newCubeState[50] = _cubeStates[52];
            newCubeState[51] = _cubeStates[45];
            newCubeState[52] = _cubeStates[48];
            newCubeState[53] = _cubeStates[51];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[6 + i] = _cubeStates[15 + i];
                newCubeState[15 + i] = _cubeStates[24 + i];
                newCubeState[24 + i] = _cubeStates[33 + i];
                newCubeState[33 + i] = _cubeStates[6 + i];
            }

            _cubeStates = newCubeState;
        }

        public static void D2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[45] = _cubeStates[53];
            newCubeState[46] = _cubeStates[52];
            newCubeState[47] = _cubeStates[51];
            newCubeState[48] = _cubeStates[50];
            newCubeState[50] = _cubeStates[48];
            newCubeState[51] = _cubeStates[47];
            newCubeState[52] = _cubeStates[46];
            newCubeState[53] = _cubeStates[45];

            for (int i = 0; i < 3; i++)
            {
                newCubeState[6 + i] = _cubeStates[24 + i];
                newCubeState[15 + i] = _cubeStates[33 + i];
                newCubeState[24 + i] = _cubeStates[6 + i];
                newCubeState[33 + i] = _cubeStates[15 + i];
            }

            _cubeStates = newCubeState;
        }

        public static void R(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[9] = _cubeStates[15];
            newCubeState[10] = _cubeStates[12];
            newCubeState[11] = _cubeStates[9];
            newCubeState[12] = _cubeStates[16];
            newCubeState[14] = _cubeStates[10];
            newCubeState[15] = _cubeStates[17];
            newCubeState[16] = _cubeStates[14];
            newCubeState[17] = _cubeStates[11];

            newCubeState[2] = _cubeStates[53];
            newCubeState[5] = _cubeStates[52];
            newCubeState[8] = _cubeStates[51];
            newCubeState[36] = _cubeStates[2];
            newCubeState[37] = _cubeStates[5];
            newCubeState[38] = _cubeStates[8];

            newCubeState[18] = _cubeStates[38];
            newCubeState[21] = _cubeStates[37];
            newCubeState[24] = _cubeStates[36];
            newCubeState[51] = _cubeStates[18];
            newCubeState[52] = _cubeStates[21];
            newCubeState[53] = _cubeStates[24];

            _cubeStates = newCubeState;
        }

        public static void Rcounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[9] = _cubeStates[11];
            newCubeState[10] = _cubeStates[14];
            newCubeState[11] = _cubeStates[17];
            newCubeState[12] = _cubeStates[10];
            newCubeState[14] = _cubeStates[16];
            newCubeState[15] = _cubeStates[9];
            newCubeState[16] = _cubeStates[12];
            newCubeState[17] = _cubeStates[15];

            newCubeState[2] = _cubeStates[36];
            newCubeState[5] = _cubeStates[37];
            newCubeState[8] = _cubeStates[38];
            newCubeState[51] = _cubeStates[8];
            newCubeState[52] = _cubeStates[5];
            newCubeState[53] = _cubeStates[2];

            newCubeState[18] = _cubeStates[51];
            newCubeState[21] = _cubeStates[52];
            newCubeState[24] = _cubeStates[53];
            newCubeState[36] = _cubeStates[24];
            newCubeState[37] = _cubeStates[21];
            newCubeState[38] = _cubeStates[18];

            _cubeStates = newCubeState;
        }

        public static void R2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[9] = _cubeStates[17];
            newCubeState[10] = _cubeStates[16];
            newCubeState[11] = _cubeStates[15];
            newCubeState[12] = _cubeStates[14];
            newCubeState[14] = _cubeStates[12];
            newCubeState[15] = _cubeStates[11];
            newCubeState[16] = _cubeStates[10];
            newCubeState[17] = _cubeStates[9];

            newCubeState[2] = _cubeStates[24];
            newCubeState[5] = _cubeStates[21];
            newCubeState[8] = _cubeStates[18];
            newCubeState[51] = _cubeStates[38];
            newCubeState[52] = _cubeStates[37];
            newCubeState[53] = _cubeStates[36];

            newCubeState[18] = _cubeStates[8];
            newCubeState[21] = _cubeStates[5];
            newCubeState[24] = _cubeStates[2];
            newCubeState[36] = _cubeStates[53];
            newCubeState[37] = _cubeStates[52];
            newCubeState[38] = _cubeStates[51];

            _cubeStates = newCubeState;
        }

        public static void L(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[27] = _cubeStates[33];
            newCubeState[28] = _cubeStates[30];
            newCubeState[29] = _cubeStates[27];
            newCubeState[30] = _cubeStates[34];
            newCubeState[32] = _cubeStates[28];
            newCubeState[33] = _cubeStates[35];
            newCubeState[34] = _cubeStates[32];
            newCubeState[35] = _cubeStates[29];

            newCubeState[0] = _cubeStates[42];
            newCubeState[3] = _cubeStates[43];
            newCubeState[6] = _cubeStates[44];
            newCubeState[45] = _cubeStates[6];
            newCubeState[46] = _cubeStates[3];
            newCubeState[47] = _cubeStates[0];

            newCubeState[20] = _cubeStates[45];
            newCubeState[23] = _cubeStates[46];
            newCubeState[26] = _cubeStates[47];
            newCubeState[42] = _cubeStates[26];
            newCubeState[43] = _cubeStates[23];
            newCubeState[44] = _cubeStates[20];

            _cubeStates = newCubeState;
        }

        public static void Lcounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[27] = _cubeStates[29];
            newCubeState[28] = _cubeStates[32];
            newCubeState[29] = _cubeStates[35];
            newCubeState[30] = _cubeStates[28];
            newCubeState[32] = _cubeStates[34];
            newCubeState[33] = _cubeStates[27];
            newCubeState[34] = _cubeStates[30];
            newCubeState[35] = _cubeStates[33];

            newCubeState[0] = _cubeStates[47];
            newCubeState[3] = _cubeStates[46];
            newCubeState[6] = _cubeStates[45];
            newCubeState[45] = _cubeStates[20];
            newCubeState[46] = _cubeStates[23];
            newCubeState[47] = _cubeStates[26];

            newCubeState[20] = _cubeStates[44];
            newCubeState[23] = _cubeStates[43];
            newCubeState[26] = _cubeStates[42];
            newCubeState[42] = _cubeStates[0];
            newCubeState[43] = _cubeStates[3];
            newCubeState[44] = _cubeStates[6];

            _cubeStates = newCubeState;
        }

        public static void L2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[27] = _cubeStates[35];
            newCubeState[28] = _cubeStates[34];
            newCubeState[29] = _cubeStates[33];
            newCubeState[30] = _cubeStates[32];
            newCubeState[32] = _cubeStates[30];
            newCubeState[33] = _cubeStates[29];
            newCubeState[34] = _cubeStates[28];
            newCubeState[35] = _cubeStates[27];

            newCubeState[0] = _cubeStates[26];
            newCubeState[3] = _cubeStates[23];
            newCubeState[6] = _cubeStates[20];
            newCubeState[45] = _cubeStates[44];
            newCubeState[46] = _cubeStates[43];
            newCubeState[47] = _cubeStates[42];

            newCubeState[20] = _cubeStates[6];
            newCubeState[23] = _cubeStates[3];
            newCubeState[26] = _cubeStates[0];
            newCubeState[42] = _cubeStates[47];
            newCubeState[43] = _cubeStates[46];
            newCubeState[44] = _cubeStates[45];

            _cubeStates = newCubeState;
        }

        public static void F(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[0] = _cubeStates[6];
            newCubeState[1] = _cubeStates[3];
            newCubeState[2] = _cubeStates[0];
            newCubeState[3] = _cubeStates[7];
            newCubeState[5] = _cubeStates[1];
            newCubeState[6] = _cubeStates[8];
            newCubeState[7] = _cubeStates[5];
            newCubeState[8] = _cubeStates[2];

            newCubeState[9] = _cubeStates[44];
            newCubeState[12] = _cubeStates[41];
            newCubeState[15] = _cubeStates[38];
            newCubeState[47] = _cubeStates[15];
            newCubeState[50] = _cubeStates[12];
            newCubeState[53] = _cubeStates[9];

            newCubeState[29] = _cubeStates[47];
            newCubeState[32] = _cubeStates[50];
            newCubeState[35] = _cubeStates[53];
            newCubeState[38] = _cubeStates[29];
            newCubeState[41] = _cubeStates[32];
            newCubeState[44] = _cubeStates[35];

            _cubeStates = newCubeState;
        }

        public static void Fcounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[0] = _cubeStates[2];
            newCubeState[1] = _cubeStates[5];
            newCubeState[2] = _cubeStates[8];
            newCubeState[3] = _cubeStates[1];
            newCubeState[5] = _cubeStates[7];
            newCubeState[6] = _cubeStates[0];
            newCubeState[7] = _cubeStates[3];
            newCubeState[8] = _cubeStates[6];

            newCubeState[9] = _cubeStates[53];
            newCubeState[12] = _cubeStates[50];
            newCubeState[15] = _cubeStates[47];
            newCubeState[47] = _cubeStates[29];
            newCubeState[50] = _cubeStates[32];
            newCubeState[53] = _cubeStates[35];

            newCubeState[29] = _cubeStates[38];
            newCubeState[32] = _cubeStates[41];
            newCubeState[35] = _cubeStates[44];
            newCubeState[38] = _cubeStates[15];
            newCubeState[41] = _cubeStates[12];
            newCubeState[44] = _cubeStates[9];

            _cubeStates = newCubeState;
        }
        public static void F2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[0] = _cubeStates[8];
            newCubeState[1] = _cubeStates[7];
            newCubeState[2] = _cubeStates[6];
            newCubeState[3] = _cubeStates[5];
            newCubeState[5] = _cubeStates[3];
            newCubeState[6] = _cubeStates[2];
            newCubeState[7] = _cubeStates[1];
            newCubeState[8] = _cubeStates[0];

            newCubeState[9] = _cubeStates[35];
            newCubeState[12] = _cubeStates[32];
            newCubeState[15] = _cubeStates[29];
            newCubeState[47] = _cubeStates[38];
            newCubeState[50] = _cubeStates[41];
            newCubeState[53] = _cubeStates[44];

            newCubeState[29] = _cubeStates[15];
            newCubeState[32] = _cubeStates[12];
            newCubeState[35] = _cubeStates[9];
            newCubeState[38] = _cubeStates[47];
            newCubeState[41] = _cubeStates[50];
            newCubeState[44] = _cubeStates[53];

            _cubeStates = newCubeState;
        }
        public static void B(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[18] = _cubeStates[24];
            newCubeState[19] = _cubeStates[21];
            newCubeState[20] = _cubeStates[18];
            newCubeState[21] = _cubeStates[25];
            newCubeState[23] = _cubeStates[19];
            newCubeState[24] = _cubeStates[26];
            newCubeState[25] = _cubeStates[23];
            newCubeState[26] = _cubeStates[20];

            newCubeState[11] = _cubeStates[51];
            newCubeState[14] = _cubeStates[48];
            newCubeState[17] = _cubeStates[45];
            newCubeState[45] = _cubeStates[27];
            newCubeState[48] = _cubeStates[30];
            newCubeState[51] = _cubeStates[33];

            newCubeState[27] = _cubeStates[36];
            newCubeState[30] = _cubeStates[39];
            newCubeState[33] = _cubeStates[42];
            newCubeState[36] = _cubeStates[17];
            newCubeState[39] = _cubeStates[14];
            newCubeState[42] = _cubeStates[11];

            _cubeStates = newCubeState;
        }

        public static void Bcounter(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[18] = _cubeStates[20];
            newCubeState[19] = _cubeStates[23];
            newCubeState[20] = _cubeStates[26];
            newCubeState[21] = _cubeStates[19];
            newCubeState[23] = _cubeStates[25];
            newCubeState[24] = _cubeStates[18];
            newCubeState[25] = _cubeStates[21];
            newCubeState[26] = _cubeStates[24];

            newCubeState[11] = _cubeStates[42];
            newCubeState[14] = _cubeStates[39];
            newCubeState[17] = _cubeStates[36];
            newCubeState[45] = _cubeStates[17];
            newCubeState[48] = _cubeStates[14];
            newCubeState[51] = _cubeStates[11];

            newCubeState[27] = _cubeStates[45];
            newCubeState[30] = _cubeStates[48];
            newCubeState[33] = _cubeStates[51];
            newCubeState[36] = _cubeStates[27];
            newCubeState[39] = _cubeStates[30];
            newCubeState[42] = _cubeStates[33];

            _cubeStates = newCubeState;
        }

        public static void B2(ref char[] _cubeStates)
        {
            char[] newCubeState = (char[])_cubeStates.Clone();

            newCubeState[18] = _cubeStates[26];
            newCubeState[19] = _cubeStates[25];
            newCubeState[20] = _cubeStates[24];
            newCubeState[21] = _cubeStates[23];
            newCubeState[23] = _cubeStates[21];
            newCubeState[24] = _cubeStates[20];
            newCubeState[25] = _cubeStates[19];
            newCubeState[26] = _cubeStates[18];

            newCubeState[11] = _cubeStates[33];
            newCubeState[14] = _cubeStates[30];
            newCubeState[17] = _cubeStates[27];
            newCubeState[45] = _cubeStates[36];
            newCubeState[48] = _cubeStates[39];
            newCubeState[51] = _cubeStates[42];

            newCubeState[27] = _cubeStates[17];
            newCubeState[30] = _cubeStates[14];
            newCubeState[33] = _cubeStates[11];
            newCubeState[36] = _cubeStates[45];
            newCubeState[39] = _cubeStates[48];
            newCubeState[42] = _cubeStates[51];

            _cubeStates = newCubeState;
        }
    }
}
