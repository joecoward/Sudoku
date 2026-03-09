using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public Guid Password { get; set; }
    }
}
