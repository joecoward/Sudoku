using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Sudoku.Models
{
    public class Game
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string? Time { get; set; }

        public string? Difficulty { get; set; }

        public int Mistakes { get; set; }

        public bool Finished { get; set; }



    }
}
