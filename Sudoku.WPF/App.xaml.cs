using Microsoft.Extensions.DependencyInjection;
using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using Sudoku.WPF.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Sudoku.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider serviceProvider { set; private get; }

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddSingleton<IBoard, Board>();
            services.AddSingleton<IRules, Rules>();

            services.AddSingleton<Random>();

            services.AddSingleton<GameDifficulty>();


            services.AddTransient<MistakeCounterViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<TimerViewModel>();
            services.AddTransient<MainWindow>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainWindow = serviceProvider.GetService<MainWindow>();
            mainWindow.Show();
        }
    }

}
