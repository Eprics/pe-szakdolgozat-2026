using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.Input;
using GoblinApp.Models;

namespace GoblinApp.ViewModels;

public partial class GameViewModel : ViewModelBase
{
    private Goblin _goblin;

    public ObservableCollection<CellViewModel> Cells { get; } = new();

    public GameViewModel()
    {
        var f1 = new Field();
        var f2 = new Field();
        var f3 = new Field();
        var f4 = new Field();

        f1.SetNeighbor(Direction.Right, f2);
        f2.SetNeighbor(Direction.Left, f1);
        f2.SetNeighbor(Direction.Right, f3);
        f3.SetNeighbor(Direction.Left, f2);
        f3.SetNeighbor(Direction.Right, f4);
        f4.SetNeighbor(Direction.Left, f3);

        _goblin = new Goblin("Bilbo", strength: 1);
        var boulder = new Boulder();

        f1.Enter(_goblin);
        f2.Enter(boulder);

        Cells.Add(new CellViewModel(f1));
        Cells.Add(new CellViewModel(f2));
        Cells.Add(new CellViewModel(f3));
        Cells.Add(new CellViewModel(f4));
    }

    [RelayCommand]
    private void Move(Direction direction)
    {
        _goblin.Step(direction);

        foreach (var cell in Cells)
        {
            cell.Refresh();
        }
    }
}