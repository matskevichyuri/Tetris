using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Tetris_dll.Elements;

namespace Tetris_dll
{
    public class TetrisGame
    {
        private List<int[,]> shapePatterns;
        private Shape currentShape;
        private Field field;

        public TetrisGame()
        {
            field = new Field(20, 15);
            if (shapePatterns == null)
            {
                shapePatterns = ClassicalshapesConstructor();
            }
            this.currentShape = Randomshape();
            
        }
        public void Nextshape()
        {
           currentShape = Randomshape();
        }
        public void AddCustomShape(int[,] customPattern)
        {
            shapePatterns.Add(customPattern);
        }
        public Shape GetcurrentShape()
        {

            return currentShape; }
        public Field GetField()
        { return field; }

        private List<int[,]> ClassicalshapesConstructor()
        {
            return new List<int[,]>
            {
                new int[4, 4]{
            {0,0,1,0  },
            {0,0,1,0  },
            {0,0,1,0  },
            {0,0,1,0  },

        },
                new int[3, 3]{
            {0,2,0  },
            {0,2,2 },
            {0,0,2 },
        },
           new int[3, 3]{
            {0,0,0  },
            {3,3,3 },
            {0,3,0 },
        },
         new int[3, 3]{
            {4,0,0 },
            {4,0,0 },
            {4,4,0 },
        },
         new int[2, 2]{
            { 5,5  },
            {5,5 },
        } }        ;
    }
        public void ChangeGridParameters(int height, int width)
        {
            if (height >= 20 && width >= 15)
            {
                field = new Field(height, width);
            }
        }
        public Shape Randomshape()
        {
            Random r = new Random();
            var pattern = shapePatterns[r.Next(0, shapePatterns.Count)];
            return new Shape(pattern); 
        }
        public void ClearMap()
        {
            for (int i = 0; i < field.Height; i++)
            {
                for (int j = 0; j < field.Width; j++)
                {
                    field.Grid[i, j] = 0;
                }
            }
        }
        public void SliceMap()
        {
            int count = 0;
            int curRemovedLines = 0;
            for (int i = 0; i < field.Height; i++)
            {
                count = 0;
                for (int j = 0; j < field.Width; j++)
                {
                    if (field.Grid[i, j] != 0)
                        count++;
                }
                if (count == field.Width)
                {
                    curRemovedLines++;
                    for (int k = i; k >= 1; k--)
                    {
                        for (int o = 0; o < field.Width; o++)
                        {
                            field.Grid[k, o] = field.Grid[k - 1, o];
                        }
                    }
                }
            }
        }

        public bool IsIntersects()
        {
            for (int i = currentShape.AxisY; i < currentShape.AxisY + currentShape.SizeMatrix; i++)
            {
                for (int j = currentShape.AxisX; j < currentShape.AxisX + currentShape.SizeMatrix; j++)
                {
                    if (j >= 0 && j <= field.Width-1)
                    {
                        if (field.Grid[i, j] != 0 && currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX] == 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void Merge()
        {
            for (int i = currentShape.AxisY; i < currentShape.AxisY + currentShape.SizeMatrix; i++)
            {
                for (int j = currentShape.AxisX; j < currentShape.AxisX + currentShape.SizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX] != 0)
                        field.Grid[i, j] = currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX];
                }
            }
        }

        public bool Collide()
        {
            for (int i = currentShape.AxisY + currentShape.SizeMatrix - 1; i >= currentShape.AxisY; i--)
            {
                for (int j = currentShape.AxisX; j < currentShape.AxisX + currentShape.SizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX] != 0)
                    {
                        if (i + 1 == field.Height)
                            return true;
                        if (field.Grid[i + 1, j] != 0)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public bool CollideHor(int dir)
        {
            for (int i = currentShape.AxisY; i < currentShape.AxisY + currentShape.SizeMatrix; i++)
            {
                for (int j = currentShape.AxisX; j < currentShape.AxisX + currentShape.SizeMatrix; j++)
                {
                    if (currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX] != 0)
                    {
                        if (j + 1 * dir > field.Width-1 || j + 1 * dir < 0)
                            return true;

                        if (field.Grid[i, j + 1 * dir] != 0)
                        {
                            if (j - currentShape.AxisX + 1 * dir >= currentShape.SizeMatrix || j - currentShape.AxisX + 1 * dir < 0)
                            {
                                return true;
                            }
                            if (currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX + 1 * dir] == 0)
                                return true;
                        }
                    }
                }
            }
            return false;
        }

        public void ResetArea()
        {

            for (int i = currentShape.AxisY; i < currentShape.AxisY + currentShape.SizeMatrix; i++)
            {
                for (int j = currentShape.AxisX; j < currentShape.AxisX + currentShape.SizeMatrix; j++)
                {
                    if (i >= 0 && j >= 0 && i < field.Height && j < field.Width)
                    {
                        if (currentShape.Matrix[i - currentShape.AxisY, j - currentShape.AxisX] == 0)
                        {
                            continue;
                        }
                        field.Grid[i, j] = 0;
                    }
                }
            }
        }


    }
}
