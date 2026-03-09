using System.Numerics;

namespace Sudoku.Game.BoardSettings
{
    public class BoardConfiguration 
    {
        private readonly Random _random = new Random();
        protected readonly int Column = 9;
        protected readonly int Row = 9;
        protected Cell[,] Field;

        public BoardConfiguration()
        {
            BoardSetting();
        }

        private void CreateBoard()
        {
            Field = new Cell[Column, Row];
            var value = 0;
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    value = ((i * 3 + i / 3 + j) % (Row) + 1);

                    Field[i, j] = new Cell(char.Parse(value.ToString()), true);
                }
            }
            //return Field;

        }

        private void TransposingBoard()
        {
            var mybool = _random.Next(0, 2);
            if (mybool == 0)
                return;

            for (int i = 0; i < Row; i++)
            {
                for (int j = i; j < Column; j++)
                {
                    var value = Field[j, i].value;
                    Field[j, i].value = Field[i, j].value;
                    Field[i, j].value = value;


                }
            }
            //return Field;
        }

        private void SwapRows()
        {
            for (int block = 0; block < 3; block++)
            {
                var row1 = block * 3 + _random.Next(0, 3);
                var row2 = block * 3 + _random.Next(0, 3);

                while (row1 == row2)
                    row2 = block * 3 + _random.Next(0, 3);

                for (int column = 0; column < Column; column++)
                {
                    var value = Field[row1, column].value;
                    Field[row1, column].value = Field[row2, column].value;
                    Field[row2, column].value = value;
                }
            }
            //return Field;

        }

        private void SwapColums()
        {
            for (int block = 0; block < 3; block++)
            {
                var column1 = block * 3 + _random.Next(0, 3);
                var column2 = block * 3 + _random.Next(0, 3);

                while(column1 == column2)
                    column2 = block * 3 + _random.Next(0, 3);

                for (int row = 0; row < Row; row++)
                {
                    var value = Field[row, column1].value;
                    Field[row, column1].value = Field[row, column2].value;
                    Field[row, column2].value = value;
                }
            }
            //return Field;
        }

        private void BoardSetting()
        {
            var iteration = 0;

            var ran = _random.Next(0, 2);

            CreateBoard();
            if(ran == 0)
            {
                TransposingBoard();
                iteration++;
            }

            while(iteration!=10)
            {
                ran = _random.Next(0, 2);
                if(ran == 0)
                {
                    SwapRows();
                    iteration++;
                }
                if(ran == 1)
                {
                    SwapColums();
                    iteration++;
                }

            }
        }
    }
}
