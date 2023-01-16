using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Tetris_dll.Elements
{
    public class Field
    {
        public int[,] Grid { get; }
        public int Width { get; }
        public int Height { get; }
        public Field(int height, int width)
        {
            this.Width = width;
            this.Height = height;
            this.Grid = new int[height, width];
        }
    }
}
