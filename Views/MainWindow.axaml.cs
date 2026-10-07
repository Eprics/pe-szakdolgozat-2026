using Avalonia.Controls;
using Avalonia.Interactivity;
using System.Diagnostics;
using GoblinApp.ViewModels;

namespace GoblinApp.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new GameViewModel();
    }

}