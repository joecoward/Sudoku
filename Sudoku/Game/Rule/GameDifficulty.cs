using Sudoku.Game.BoardSettings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Game.Rule
{
    public class GameDifficulty
    {

        private string _difficulty;

        public int[] SetDifficulty(string difficulty)
        {

            var dif = 0;
            var locked = 50;
            if (difficulty == "Normal")
            {
                dif = 1;
                locked = 45;
            }
            if (difficulty == "Hard")
            {
                dif = 2;
                locked = 40;
            }
            else
            {
                difficulty = "Easy";
            }

            _difficulty = difficulty;

            return [dif, locked];

        }

        public string GetDifficulty()
        {
            return _difficulty;
        }
    }
}
