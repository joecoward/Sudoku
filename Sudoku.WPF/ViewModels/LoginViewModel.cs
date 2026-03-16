using Sudoku.Dal.Interfa;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class LoginViewModel
    {
        private IUserDal _userDal;

        public LoginViewModel(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public bool Login(string userName,string password)
        {
            return false; 
        }
    }
}
