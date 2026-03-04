using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Game.BoardSettings
{
    public class Cell
    {
        public bool isLocked;
        public char value;
        public Cell(char value, bool isLocked = false)
        {
            this.value = value;
            this.isLocked = isLocked;
        }



    }
}
