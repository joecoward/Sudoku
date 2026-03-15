using Sudoku.WPF.Services.Abs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace Sudoku.WPF.Services.Conc
{
    public class DialogService : IDialogService
    {
        public void ShowMessage(string message) => MessageBox.Show(message);
    }
}
