using Avalonia.Controls;
using Avalonia.Interactivity;
using DialogVisitorApp.ViewModels;


namespace DialogVisitorApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private ViewPersons? viewPersons;
        private ViewVehicles? viewVehicles;

        /// <summary>
        /// The visitor class which is invoked to pop up the dialogs, per the Visitor pattern.
        /// </summary>
        private DialogVisitor? Visitor;


        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Visitor = new Views.DialogVisitor((Avalonia.Controls.Window)this);

            // retrieve the object created by axaml from the resources and 
            // use property injection to add the Visitor to the View Model
            if (this.TryGetResource("viewPersons", out var vp))
            {
                viewPersons = (ViewPersons)vp!;
                ((ViewPersons)viewPersons!).Visitor = Visitor;
            }

            // do the same for vehicle
            if(this.TryGetResource("viewVehicles", out var vv))
            {
                viewVehicles = (ViewVehicles)vv!;
                ((ViewVehicles)viewVehicles!).Visitor = Visitor;
            }
        }

        /// <summary>
        /// Handles the selection event for the person grid.
        /// </summary>
        /// <remarks>This method updates the state of the associated command to reflect whether it can be
        /// executed, based on the current selection in the person grid.</remarks>
        /// <param name="sender">The source of the event, typically the person grid control.</param>
        /// <param name="e">The event data associated with the selection event.</param>
       // private void PersonGrid_SelectionChanged(object sender, RoutedEventArgs e)
        private void PersonGrid_SelectionChanged(object sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            viewPersons?.UpdatePersonCommand.NotifyCanExecuteChanged();
        }

        /// <summary>
        /// Handles the selection change event for the vehicle grid.
        /// </summary>
        /// <remarks>This method updates the state of the <see cref="viewVehicles.UpdateVehicleCommand"/> 
        /// by notifying that its execution status may have changed.</remarks>
        /// <param name="sender">The source of the event, typically the vehicle grid control.</param>
        /// <param name="e">The event data containing information about the selection change.</param>
        private void VehicleGrid_SelectionChanged(object sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            viewVehicles?.UpdateVehicleCommand.NotifyCanExecuteChanged();
        }

    }
}