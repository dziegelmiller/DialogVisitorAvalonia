using CommunityToolkit.Mvvm.ComponentModel;

namespace DialogVisitorApp.Models
{
    public partial class Person : ObservableObject 
    {

        [ObservableProperty]
        public string? _firstName;

        [ObservableProperty]
        private string? _lastName;


        [ObservableProperty]
        private string? _phone;

    }
}
