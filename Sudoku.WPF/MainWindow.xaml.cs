using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Sudoku.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random _random = new Random();

        private IBoard _board = new Board();

        private IRules _rules = new Rules();

        private bool _isGameOver = false;

        private int _countMistakes = 0;
        public MainWindow()
        {
            InitializeComponent();
            CreateSudokuGrid();
        }

        private void CreateSudokuGrid()
        {
            GameDifficulty _gameDifficulty = new GameDifficulty(_board);
            _gameDifficulty.Difficulty("");

            var grid = new Grid()
            {
                Height = 450,
                Width = 450,
            };
            


            for (int i = 0; i < 9; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var board = _board.GetBoard();
            
            for (int r = 0; r < 9; r++)
            {
                var top = (r % 3 == 0) ? 3 : 1;

                var bottom = (r == 8) ? 3 : 0;

                for (int c = 0; c < 9; c++)
                {
                    
                    var left = (c % 3 == 0) ? 3 : 1;
                    var right = (c == 8) ? 3 : 0;



                    if (board[r, c].isLocked == false)
                    {
                        var input = new TextBox
                        {
                            Style = (Style)Application.Current.FindResource("SudokuInputStyle"),
                            BorderThickness = new Thickness(left, top, right, bottom),
                            Tag = new { Row = r, Column = c }
                        };
                        input.TextChanged += OnCellTextChanged;
                        Grid.SetRow(input, r);
                        Grid.SetColumn(input, c);

                        grid.Children.Add(input);
                    }
                    else
                    {
                        var lable = new Label
                        {
                            Content = board[r, c].value,
                            Style = (Style)Application.Current.FindResource("SudokuLabelStyle"),    
                            BorderThickness = new Thickness(left, top, right, bottom)
                        };

                        Grid.SetRow(lable, r);
                        Grid.SetColumn(lable, c);
                        grid.Children.Add(lable);
                    }

                }
            }

            this.Content = grid;
        }

        private void OnCellTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            if(textBox == null || string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Background = Brushes.White;
                return;
            }

            dynamic position = textBox.Tag;

            int r = position.Row;
            int c = position.Column;

            char value = textBox.Text[0];

            _board.UpdateBoard(r, c, value);

            if (!_rules.IsValidSudoku(_board.GetBoard()))
            {
                textBox.Background = Brushes.Red;
                _countMistakes++;
            }

        }



    }
}