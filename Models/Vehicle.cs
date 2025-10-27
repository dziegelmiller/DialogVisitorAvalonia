using CommunityToolkit.Mvvm.ComponentModel;


namespace DialogVisitorApp.Models
{
    public partial class Vehicle : ObservableObject 
    {

        [ObservableProperty]
        private string? _make;

        [ObservableProperty]
        private string? _model;

        [ObservableProperty]
        private string? _year;
    }
}
