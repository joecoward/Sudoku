using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IServiceProvider _serviceProvider;
        public MenuWindow(IServiceProvider serviceProvider)
        {

            InitializeComponent();

            _serviceProvider = serviceProvider;
        }

        private async void StartGame_Click(object sender, RoutedEventArgs e)
        {
            var selectedDiff = "Easy";

            if (RbEasy.IsChecked == true)
                selectedDiff = RbEasy.Tag.ToString();
            if (RbNormal.IsChecked == true)
                selectedDiff = RbNormal.Tag.ToString();
            if (RbHard.IsChecked == true)
                selectedDiff = RbHard.Tag.ToString();

            var mainWindow = _serviceProvider.GetRequiredService<MainWindow>();

            var vm = (MainViewModel)mainWindow.DataContext;

            await Task.Run(() =>
            {
                vm.Engine.Difficulty(selectedDiff);
                vm.LevelOfDifficulty.LevelOfDifficulty = selectedDiff;
            });
            mainWindow.CreateSudokuGrid();
            mainWindow.Show();

            this.Close();
        }
    }
}
