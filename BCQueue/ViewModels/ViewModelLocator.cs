using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BCQueue.ViewModels
{
    // This class contains static references to all the view models in the
    // application and provides an entry point for the bindings.
    public class ViewModelLocator
    {
        private static MainViewModel _main;


        // Initializes a new instance of the ViewModelLocator class.
        public ViewModelLocator()
        {
            _main = new MainViewModel();
        }

        // Gets the Main property which defines the main viewmodel.
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
            "CA1822:MarkMembersAsStatic",
            Justification = "This non-static member is needed for data binding purposes.")]
        public MainViewModel Main
        {
            get
            {
                return _main;
            }
        }
    }
}