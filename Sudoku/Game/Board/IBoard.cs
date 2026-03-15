using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Game.BoardSettings
{
    public interface IBoard
    {
        public void UpdateBoard(int indexRow,int indexColumn , char value ,bool isLocked = false);
        public void WriteBoard();
        public Cell[,] GetBoard();
        public void GenerateLevel(int locked, int dif);

        public bool IsGameEnd();


    }
}
