using Sudoku.WPF.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Xml;

namespace Sudoku.WPF
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private RegistrationViewMode _viewModel;
        public RegistrationWindow(RegistrationViewMode viewMode)
        {
            _viewModel = viewMode;
            InitializeComponent();
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            if (_viewModel.Register(TbLogin.Text, PbPassword.Password))
                this.Close();
            
        }

    }
}
