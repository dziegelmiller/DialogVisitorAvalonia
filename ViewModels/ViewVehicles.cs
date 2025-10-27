using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DialogVisitorApp.Models;
using System.Collections.ObjectModel;

namespace DialogVisitorApp.ViewModels
{

    public partial class ViewVehicles : ObservableObject
    {
        /// <summary>
        /// The visitor class which is invoked to pop up the dialogs.
        /// The functional instance is injected by the mainWindow Loaded event handler
        /// </summary>
        public DialogVisitor? Visitor { get; set; }
        public ViewVehicles()
        {
            VehicleList = new ObservableCollection<Vehicle>();
            VehicleListView = new DataGridCollectionView(VehicleList);
        }

        /// <summary>
        /// The collection of Vehicle objects
        /// </summary>
        public ObservableCollection<Vehicle> VehicleList;

        ///// <summary>
        ///// The property the datagrid is bound to
        ///// </summary>
        public DataGridCollectionView VehicleListView { get; private set; }

        /// <summary>
        /// Command to update the selected Vehicle object.
        /// </summary>
        [RelayCommand(CanExecute = nameof(CanUpdateVehicle))]
        public void UpdateVehicle()
        {
            // Invoke the visitor.  DynamicVisit will call the Visit method which has
            // the Vehicle argument, which creates and shows the dialog. Because the curent
            // item is passed, any changes are made to the existing object.
            Visitor?.DynamicVisit((Vehicle)VehicleListView.CurrentItem);
        }

        /// <summary>
        /// Enable/disable the Update Vehicle button.  Note that the
        /// SelectionChanged event of the DataGrid is needed to NotifyCanExecuteChanged,
        /// implemented in the MainWindow.axaml.cs
        /// </summary>
        /// <returns></returns>
        private bool CanUpdateVehicle()     
        {
            // Check if the current item is not null and if the Visitor is set
            return (Vehicle)VehicleListView.CurrentItem != null && Visitor != null;
        }

        /// <summary>
        ///  command to create a new Vehicle object and show the dialog.
        /// </summary>
        [RelayCommand]
        private void CreateVehicle()
        {
            if (Visitor != null)
            {
                Vehicle v = new Vehicle();
                // Invoke the visitor.  DynamicVisit will call the Visit method which has
                // the Vehicle argument, which creates and shows the dialog.
                Visitor.DynamicVisit(v);
                VehicleList.Add(v);
            }
        }

    }
}
