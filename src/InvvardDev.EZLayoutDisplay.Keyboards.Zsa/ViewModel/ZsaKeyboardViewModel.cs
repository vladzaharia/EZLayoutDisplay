using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.ViewModel
{
    public class ZsaKeyboardViewModel : ViewModelBase
    {
        #region Fields

        private ObservableCollection<KeyTemplate> _currentLayoutTemplate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        public ObservableCollection<KeyTemplate> CurrentLayoutTemplate
        {
            get => _currentLayoutTemplate;
            set => Set(ref _currentLayoutTemplate, value);
        }

        #endregion
    }
}