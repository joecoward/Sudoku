
namespace Sudoku.Dal.Interfa
{
    public interface IGameDal
    {
        public Sudoku.Models.Game Create(Sudoku.Models.Game game);

        public List<Sudoku.Models.Game> GetAll();

        public Sudoku.Models.Game Update(Sudoku.Models.Game game);

        public void Delete(int id);
    }
}
