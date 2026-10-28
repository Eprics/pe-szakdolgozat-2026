using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GoblinApp.Models;
using GoblinApp.Services;

namespace GoblinApp.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    private readonly List<Goblin> _goblins;
    private readonly Action _onExitToMenu;

    public ObservableCollection<CellViewModel> Cells { get; } = new();
    public int Columns { get; }

    public GameViewModel() : this(onExitToMenu: () => { })
    {
        
    }

    public GameViewModel(Action onExitToMenu)
    {
        _onExitToMenu = onExitToMenu;

        var mapPath = Path.Combine(AppContext.BaseDirectory, "Maps", "level1.txt");
        var map = MapLoader.LoadFromFile(mapPath);

        Columns = map.Width;
        _goblins = map.Goblins;

        for (var y = 0; y < map.Height; y++)
        {
            for (var x = 0; x < map.Width; x++)
            {
                Cells.Add(new CellViewModel(map.Fields[y, x]));
            }
        }
    }

    [RelayCommand]
    private void Move(Direction direction)
    {
        if (_goblins.Count == 0) { return; }

        _goblins[0].Step(direction);

        foreach (var cell in Cells)
        {
            cell.Refresh();
        }
    }

    [RelayCommand]
    private void ExitToMenu()
    {
        _onExitToMenu();
    }
}