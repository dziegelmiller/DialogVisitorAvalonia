using Avalonia.Controls;
using DialogVisitorApp.Models;
//using DialogVisitorApp.ViewModels;
using DialogVisitorApp.Views;
using System;

namespace DialogVisitorApp.Views
{
    /// <summary>
    /// Modified Visitor.  Using Dynamic to simplify the pattern.
    /// See "Albahari, C# 7.0 in a Nutshell"
    /// Daniel Ziegelmiller, author
    /// </summary>

    public class DialogVisitor : ViewModels.DialogVisitor
    {

        Window window;

        public  DialogVisitor(Window window) : base(window)
        {
            this.window = window;
            window.Width = 300;
            window.Height = 250;
        }
        /// <summary>
        /// The method which is called by ViewModel classes to instantiate and show the dialog 
        /// windows.  By dynamic member resolution, the correct private Visit method will
        /// be invoked based on the method signature.
        /// </summary>
        /// <param name="data">The object which the dialog window
        /// will manipulate.</param>
        /// <returns>The object argument as modified.</returns>
        public override  object DynamicVisit(Object data) => Visit((dynamic)data);

        // create overloaded Visit methods.  The correct one will
        // be called based on the method signature, when the DynamicVisit delegate 
        // is invoked.
        //
        // This decouples the data (argument) from the action (dialog) performed
        // on it.
        private Person Visit(Person p)
        {
            var dlg = new PersonDialog();
            dlg.DataContext = p;
            dlg.ShowDialog(window);
            return p;
        }

        private Vehicle Visit(Vehicle v)
        {
            var dlg = new VehicleDialog();
            dlg.DataContext = v;
            dlg.ShowDialog(window);
            return v;
        }

    }
}
