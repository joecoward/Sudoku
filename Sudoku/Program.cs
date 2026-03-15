
using Sudoku.Dal.Conc;
using Sudoku.Game;
using Sudoku.Models;

namespace Sudoku
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var dal = new UserDal();
            var salt = Guid.NewGuid().ToByteArray();
            var entity = new User();
            entity.UserName = "Oleg";
            dal.Create(entity, "12341234");
        }

    }
}
