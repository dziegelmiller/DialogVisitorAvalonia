using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DialogVisitorApp.Views;

public partial class VehicleDialog : Window
{
    public VehicleDialog()
    {
        InitializeComponent();
    }

    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}