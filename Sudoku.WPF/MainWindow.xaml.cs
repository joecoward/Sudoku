using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            Difficulty("Normal");

            var grid = new Grid();
            grid.ShowGridLines = true;
            for (int i = 0; i < 9; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            var board = _board.GetBoard();
            
            for (int r = 0; r < 9; r++)
            {
                for (int c = 0; c < 9; c++)
                {
                    var text = new TextBlock
                    {

                        FontSize = 40,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center

                    };
                    var input = new TextBox //пофіксити input 
                    {
                        FontSize = 40,
                        MaxLength = 1,
                        Padding = new Thickness(0),
                        TextAlignment = TextAlignment.Center,
                        VerticalScrollBarVisibility = ScrollBarVisibility.Disabled,

                        VerticalContentAlignment = VerticalAlignment.Center,
                        HorizontalContentAlignment = HorizontalAlignment.Center

                        //BorderBrush = Brushes.Gray;
                        //BorderThickness = new Thickness(1);
                    };
                    text.Text = board[r, c].value.ToString();
                    if (board[r, c].isLocked == false)
                    {
                        Grid.SetRow(input, r);
                        Grid.SetColumn(input, c);

                        grid.Children.Add(input);
                    }
                    else
                    {

                        Grid.SetRow(text, r);
                        Grid.SetColumn(text, c);
                        grid.Children.Add(text);
                    }

                }
            }

            this.Content = grid;
        }

        private void Start(string difficulty)
        {
            Difficulty(difficulty);

            while (!_isGameOver)
            {

                Console.WriteLine("Mistakes Coount := " + _countMistakes);
                Console.WriteLine("----------------------");
                _board.WriteBoard();
                Console.WriteLine("----------------------");

                Console.WriteLine();

                Console.Write("Enter row:=");
                if (!int.TryParse(Console.ReadLine(), out int indexRow))
                    Console.WriteLine("Its not a number");

                Console.Write("Enter column:=");
                if (!int.TryParse(Console.ReadLine(), out int indexColumn))
                    Console.WriteLine("Its not a number");

                Console.Write("Enter value:=");
                if (!char.TryParse(Console.ReadLine(), out char value))
                    Console.WriteLine("Its not a number");

                Console.WriteLine();

                Console.Clear();

                _board.UpdateBoard(indexRow - 1, indexColumn - 1, value);
                if (!_rules.IsValidSudoku(_board.GetBoard()))
                {
                    _countMistakes++;
                    Console.WriteLine("try again");
                }

            }

        }


        private void Difficulty(string difficulty)
        {

            var dif = 0;
            var locked = 35;
            if (difficulty == "Normal")
            {
                dif = 1;
                locked = 30;
            }
            if (difficulty == "Hard")
            {
                dif = 2;
                locked = 25;
            }

            var board = _board.GetBoard();

            var deleted = 0;

            var empty = -1;

            while (deleted != 81 - locked/* || empty != dif*/)
            {
                var randomCell = _random.Next(0, 81);

                var Celli = randomCell % 9;
                var Cellj = randomCell / 9;

                if (board[Celli, Cellj].value != '.')
                {
                    board[Celli, Cellj] = new Cell('.');
                    deleted++;
                }
                else
                    continue;

            }

        }
    }
}