using Sudoku.Dal.Interfa;
using Sudoku.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class RegistrationViewMode
    {
        private IUserDal UserDal;

        public RegistrationViewMode(IUserDal userDal)
        {
            UserDal = userDal;
        }

        public void Register(string login, string password)
        {
            var entity = new User
            {
                UserName = login
            };

            UserDal.Create(entity, password);
        }
    }
}
