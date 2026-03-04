
using Sudoku.Game;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new GameEngine();            
            game.Start("Normal");
        }

    }
}
