using Sudoku.Entity;
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
        public bool IsUserNameFree(string userName);

        public User ToDto(UserEntity user);
        //public User SearchByLogin(string login);
    }
}
