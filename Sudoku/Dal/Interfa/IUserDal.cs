using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.Dal.Interfa
{
    public interface IUserDal
    {
        public User Create(User user, string password);
        public List<User> GetAll();
        public User Update(User user);
        public void Delete(int id);
    }
}
