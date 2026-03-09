using Sudoku.Game.BoardSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Game.Rule
{
    public class GameDifficulty
    {
        private readonly IBoard _board;
        private readonly Random _random = new Random();

        public GameDifficulty(IBoard board)
        {
            _board = board;
        }
        public void Difficulty(string difficulty)
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
