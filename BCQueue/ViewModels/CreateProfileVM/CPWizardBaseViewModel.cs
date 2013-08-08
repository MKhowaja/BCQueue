using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using GalaSoft.MvvmLight;

namespace BCQueue.ViewModels.CreateProfileVM
{
    /// <summary>
    /// Abstract base class for all pages shown in the wizard.
    /// </summary>
    public abstract class CPWizardBaseViewModel : ViewModelBase, INotifyPropertyChanged
    {
        #region Fields

        //readonly Court _court;
        bool _isCurrentPage;

        #endregion // Fields

        #region Constructor

        protected CPWizardBaseViewModel() : base (null)
        {
        }

        #endregion // Constructor

        #region Properties

        public abstract string DisplayName { get; }

        public bool IsCurrentPage
        {
            get { return _isCurrentPage; }
            set 
            {
                if (value == _isCurrentPage)
                    return;

                _isCurrentPage = value;
                this.OnPropertyChanged("IsCurrentPage");
            }
        }

        #endregion // Properties

        #region Methods

        /// <summary>
        /// Returns true if the user has filled in this page properly
        /// and the wizard should allow the user to progress to the 
        /// next page in the workflow.
        /// </summary>
        internal abstract bool IsValid();

        #endregion // Methods

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion // INotifyPropertyChanged Members
    }
}
