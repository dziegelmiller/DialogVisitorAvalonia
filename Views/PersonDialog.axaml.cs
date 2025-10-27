using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace DialogVisitorApp.Views;

public partial class PersonDialog : Window
{
    public PersonDialog()
    {
        InitializeComponent();
    }
    private void OkBtn_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}