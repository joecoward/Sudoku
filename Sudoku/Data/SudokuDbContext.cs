using Microsoft.EntityFrameworkCore;
using Sudoku.Entity;

namespace Sudoku.Data
{
    public class SudokuDbContext : DbContext
    {
        public DbSet<GameEntity> Games { get; set; }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\VS\\Sudoku.repo\\Sudoku\\Sudoku.db");  
        }
    }

    
}