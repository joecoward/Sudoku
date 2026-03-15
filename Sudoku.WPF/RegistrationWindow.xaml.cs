using Sudoku.WPF.ViewModels;
using System.Windows;

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
            var login = TbLogin.Text;
            
        }
    }
}
