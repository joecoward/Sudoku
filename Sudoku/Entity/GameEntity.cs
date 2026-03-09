using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sudoku.Entity
{
    [Table("Game")]
    public class GameEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("userId")]
        [Column("userId")]
        public int UserId { get; set; }

        [Column("time")]
        public string? Time { get; set; }

        [Column("difficulty")]
        public string? Difficulty { get; set; }

        [Column("mistakes")]
        public int Mistakes { get; set; }

        [Column("finished")]
        public bool Finished { get; set; }
    }
}
