using CommunityToolkit.Mvvm.ComponentModel;

namespace GoblinApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ViewModelBase CurrentViewModel { get; set; }

    public MainViewModel()
    {
        CurrentViewModel = CreateMainMenu();
    }

    private MainMenuViewModel CreateMainMenu()
    {
        return new MainMenuViewModel(
            onPlay: () => CurrentViewModel = CreateGame(),
            onExit: () => Environment.Exit(0));
    }

    private GameViewModel CreateGame()
    {
        return new GameViewModel(onExitToMenu: () => CurrentViewModel = CreateMainMenu());
    }
}