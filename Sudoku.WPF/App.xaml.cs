using Microsoft.Extensions.DependencyInjection;
using Sudoku.Dal.Conc;
using Sudoku.Dal.Interfa;
using Sudoku.Data;
using Sudoku.Game;
using Sudoku.Game.BoardSettings;
using Sudoku.Game.Rule;
using Sudoku.WPF.Services.Abs;
using Sudoku.WPF.Services.Conc;
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
            services.AddTransient<GameEngine>();

            services.AddSingleton<IBoard, Board>();
            services.AddSingleton<IRules, Rules>();

            services.AddSingleton<Random>();

            services.AddSingleton<GameDifficulty>();

            services.AddDbContext<SudokuDbContext>();
            

            services.AddSingleton<IGameDal, GameDal>();
            services.AddSingleton<IUserDal, UserDal>();

            services.AddTransient<IDialogService, DialogService>();

            services.AddTransient<MistakeCounterViewModel>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<TimerViewModel>();
            services.AddTransient<RegistrationViewMode>();

            services.AddTransient<MainWindow>();
            services.AddTransient<MenuWindow>();
            services.AddTransient<RegistrationWindow>();
            
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var menuWindow = serviceProvider.GetService<MenuWindow>();
            menuWindow.Show();
        }
    }

}
