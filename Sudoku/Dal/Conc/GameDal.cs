using Sudoku.Dal.Interfa;
using Sudoku.Data;
using Sudoku.Entity;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Sudoku.Dal.Conc
{
    public class GameDal : IGameDal
    {
        //private readonly string connString;

        //public GameDal(string connStr)
        //{
        //    connString = connStr;
        //}
        public Models.Game Create(Models.Game game)
        {
            using (var context = new SudokuDbContext())
            {
                var entity = new GameEntity
                {
                    UserId = game.UserId,
                    Time = game.Time,
                    Difficulty = game.Difficulty,
                    Mistakes = game.Mistakes,
                    Finished = game.Finished
                };
                context.Games.Add(entity);
                context.SaveChanges();
                game.Id = entity.Id;
                return game;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Models.Game> GetAll()
        {
            throw new NotImplementedException();
        }

        public Models.Game Update(Models.Game game)
        {
            throw new NotImplementedException();
        }
    }
}
