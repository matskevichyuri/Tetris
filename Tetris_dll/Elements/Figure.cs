using System;
using Tetris_dll.Interfaces;

namespace Tetris_dll.Elements
{
    public class Shape : IMovable
    {
        internal int AxisX { get; private set; }
        internal int AxisY { get; private set; }
        internal int[,] Matrix { get; private set; }
        internal int SizeMatrix { get; private set; }
        public Shape(int[,] matrix)
        {
            this.AxisX = 6;
            this.Matrix = matrix;
            this.SizeMatrix = (int)Math.Sqrt(matrix.Length);
        }

        public void MoveDown()
        {
            AxisY++;
        }

        public void MoveLeft()
        {
            AxisX--;
        }

        public void MoveRight()
        {
            AxisX++;
        }
        public void Rotate()
        {
            int[,] tempMatrix = new int[SizeMatrix, SizeMatrix];
            for (int i = 0; i < SizeMatrix; i++)
            {
                for (int j = 0; j < SizeMatrix; j++)
                {
                    tempMatrix[i, j] = Matrix[j, (SizeMatrix - 1) - i];
                }
            }
            Matrix = tempMatrix;
            int offset1 = (8 - (AxisX + SizeMatrix));
            if (offset1 < 0)
            {
                for (int i = 0; i < Math.Abs(offset1); i++)
                    MoveLeft();
            }

            if (AxisX < 0)
            {
                for (int i = 0; i < Math.Abs(AxisX) + 1; i++)
                    MoveRight();
            }
        }
    }
}
