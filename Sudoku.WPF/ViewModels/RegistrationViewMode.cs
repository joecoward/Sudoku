using Sudoku.Dal.Interfa;
using Sudoku.Models;
using Sudoku.WPF.Services.Abs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sudoku.WPF.ViewModels
{
    public class RegistrationViewMode
    {
        private IUserDal UserDal;

        private IDialogService _dialogService;

        public RegistrationViewMode(IUserDal userDal, IDialogService dialogService)
        {
            _dialogService = dialogService;
            UserDal = userDal;
        }

        public bool Register(string login, string password) //зробити нормальну валідацію
        {
            if(!UserDal.IsUserNameFree(login))
            {
                _dialogService.ShowMessage("This login is already exist");
                return false;
            }

            var entity = new User
            {
                UserName = login
            };

            UserDal.Create(entity, password);

            _dialogService.ShowMessage("Welcome");

            return true;
        }
    }
}
