using Sudoku.Game.Rule;

namespace Sudoku.Game.BoardSettings
{
    public class BoardConfiguration 
    {
        private readonly Random _random;
        protected readonly int Column = 9;
        protected readonly int Row = 9;
        protected Cell[,] Field;

        private int _solutionsFound;
        public BoardConfiguration(Random random)
        {
            _random = random;
            BoardSetting();
        }

        protected void Difficulty(int locked, int dif)
        {
            var deleted = 0;

            var empty = -1;

            while (deleted != 81 - locked/* || empty != dif*/)
            {
                var r = _random.Next(0, 9);
                var c = _random.Next(0, 9);

                if (Field[r, c].value != '.')
                {
                    var temp = Field[r, c].value;

                    Field[r, c] = new Cell('.');

                    if (SudokuSolver())
                        deleted++;
                    
                    else
                        Field[r, c].value = temp;
                    
                }
                else
                    continue;

            }
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

            while(iteration!=100)
            {
                ran = _random.Next(0, 3);
                if (ran == 0)
                {
                    TransposingBoard();
                    iteration++;
                }
                if (ran == 1)
                {
                    SwapRows();
                    iteration++;
                }
                if(ran == 2)
                {
                    SwapColums();
                    iteration++;
                }

            }
        }

        private bool SudokuSolver() //вкрав нагло
        {
            // 1. Копіюємо ігрове поле лише ОДИН раз перед початком рекурсії
            char[,] testBoard = new char[9, 9];
            for (int r = 0; r < 9; r++)
                for (int c = 0; c < 9; c++)
                    testBoard[r, c] = Field[r, c].value;

            _solutionsFound = 0;
            CountSolutions(testBoard);

            // Судоку валідне, якщо воно має РІВНО ОДИН розв'язок
            return _solutionsFound == 1;
        }

        private void CountSolutions(char[,] board)
        {
            // Якщо ми вже знайшли більше одного розв'язку, далі можна не шукати
            if (_solutionsFound > 1) return;

            int row = -1;
            int col = -1;
            bool isEmpty = false;

            // Шукаємо першу порожню клітинку
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (board[i, j] == '.')
                    {
                        row = i;
                        col = j;
                        isEmpty = true;
                        break;
                    }
                }
                if (isEmpty) break;
            }

            // Якщо порожніх клітинок немає — ми знайшли розв'язок!
            if (!isEmpty)
            {
                _solutionsFound++;
                return;
            }

            // Пробуємо підставити цифри від 1 до 9
            for (char num = '1'; num <= '9'; num++)
            {
                if (IsSafe(board, row, col, num))
                {
                    board[row, col] = num;
                    CountSolutions(board); // Рекурсивний виклик
                    board[row, col] = '.'; // Відкат (Backtrack)
                }
            }
        }

        private bool IsSafe(char[,] board, int row, int col, char val) //вкрав нагло
        {
            for (int i = 0; i < 9; i++)
            {
                if (board[row, i] == val || board[i, col] == val ||
                    board[row - row % 3 + i / 3, col - col % 3 + i % 3] == val)
                    return false;
            }
            return true;
        }
    }
}
