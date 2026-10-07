using CommunityToolkit.Mvvm.ComponentModel;
using GoblinApp.Models;

namespace GoblinApp.ViewModels;

public partial class CellViewModel : ViewModelBase
{
    public Field Field { get; }

    [ObservableProperty]
    public partial string Display { get; set; }

    public CellViewModel(Field field)
    {
        Field = field;
        Display = ComputeDisplay();
    }

    public void Refresh()
    {
        Display = ComputeDisplay();
    }

    private string ComputeDisplay()
    {
        var pushable = Field.Pushable;

        if (pushable is Goblin) { return "G"; }
        if (pushable is Boulder) { return "R"; }
        if (pushable is Wall) { return "#"; }

        return "";
    }
}