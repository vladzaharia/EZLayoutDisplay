using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using InvvardDev.EZLayoutDisplay.PluginContract.Model;

namespace InvvardDev.EZLayoutDisplay.Plugin.ZsaKeyboards.ViewModel
{
    public class ErgoDoxEzViewModel : ViewModelBase
    {
        #region Fields

        private IEnumerable<IEnumerable<KeyTemplate>> _layoutTemplates;
        private ObservableCollection<KeyTemplate> _currentLayoutTemplate;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the layout template.
        /// </summary>
        internal ObservableCollection<KeyTemplate> CurrentLayoutTemplate
        {
            get => _currentLayoutTemplate;
            set => Set(ref _currentLayoutTemplate, value);
        }

        #endregion

        public ErgoDoxEzViewModel(IEnumerable<IEnumerable<KeyTemplate>> layoutTemplates)
        {
            _layoutTemplates = layoutTemplates;
            CurrentLayoutTemplate = new ObservableCollection<KeyTemplate>();
        }

        #region Private methods

        #endregion
    }
}