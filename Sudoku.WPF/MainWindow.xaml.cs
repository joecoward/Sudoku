using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using Sudoku.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Sudoku.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly MainViewModel _viewModel;

        private bool _isGameOver = false;



        public MainWindow(MainViewModel mainModel)
        {
            InitializeComponent();

            _viewModel = mainModel;
            this.DataContext = _viewModel;

            CreateSudokuGrid();
        }

        private void CreateSudokuGrid()
        {

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

            var board = _viewModel.Board.GetBoard();
            
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

            GameControl.Content = grid;
        }

        private void OnCellTextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;

            var board = _viewModel.Board;

            var rules = _viewModel.Rules;

            var counter = _viewModel.Mistakes;


            if (textBox == null || string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Background = Brushes.White;
                return;
            }

            dynamic position = textBox.Tag;

            int r = position.Row;
            int c = position.Column;

            char value = textBox.Text[0];

            board.UpdateBoard(r, c, value);

            if (!rules.IsValidSudoku(board.GetBoard()))
            {
                textBox.Background = Brushes.Red;
                counter.MistakeCounter += 1;
            }

        }



    }
}