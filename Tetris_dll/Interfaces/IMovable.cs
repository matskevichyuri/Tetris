using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris_dll.Elements;

namespace Tetris_dll.Interfaces
{
    internal interface IMovable
    {
        void MoveRight();
        void MoveLeft();
        void MoveDown();
        void Rotate();

    }
}
