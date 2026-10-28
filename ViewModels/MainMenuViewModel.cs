using CommunityToolkit.Mvvm.Input;

namespace GoblinApp.ViewModels;

public partial class MainMenuViewModel : ViewModelBase
{
    public string Title { get; } = "GoblinApp";

    private readonly Action _onPlay;
    private readonly Action _onExit;

    public MainMenuViewModel() : this(onPlay: () => { }, onExit: () => { })
    {
        
    }

    public MainMenuViewModel(Action onPlay, Action onExit)
    {
        _onPlay = onPlay;
        _onExit = onExit;
    }

    [RelayCommand]
    private void Play()
    {
        _onPlay();
    }

    [RelayCommand]
    private void Exit()
    {
        _onExit();
    }
}