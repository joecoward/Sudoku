using Sudoku.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sudoku.WPF
{
    /// <summary>
    /// Interaction logic for LogInWindow.xaml
    /// </summary>
    public partial class LogInWindow : Window
    {
        public LoginViewModel _viewModel;
        public LogInWindow(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
            InitializeComponent();
        }

        private void Login_Click(object sender , RoutedEventArgs e)
        {
            _viewModel.Login(TbLogin.Text, PbPassword.Password);
        }
    }
}
