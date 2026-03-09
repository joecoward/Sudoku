using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sudoku.Entity
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("userName")]
        public string UserName { get; set; }

        [Column("password")]
        public Guid Password { get; set; }

        [Column("salt")]
        public Guid Salt { get; set; }
    }
}
