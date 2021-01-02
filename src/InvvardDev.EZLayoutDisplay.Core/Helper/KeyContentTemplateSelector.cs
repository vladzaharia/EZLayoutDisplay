using System;
using InvvardDev.EZLayoutDisplay.Core.Models;
using InvvardDev.EZLayoutDisplay.Core.Models.Enum;

namespace InvvardDev.EZLayoutDisplay.Core.Helper
{
    public class KeyContentTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SimpleLabelDataTemplate { private get; set; }
        public DataTemplate ModifierOnTopDataTemplate { private get; set; }
        public DataTemplate ModifierUnderDataTemplate { private get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            DataTemplate template = SimpleLabelDataTemplate;

            if (!(item is KeyTemplate key)) return template;

            switch (key.EZKey.DisplayType)
            {
                case KeyDisplayType.None:
                case KeyDisplayType.SimpleLabel:
                    template = SimpleLabelDataTemplate;

                    break;
                case KeyDisplayType.ModifierOnTop:
                    template = ModifierOnTopDataTemplate;

                    break;
                case KeyDisplayType.ModifierUnder:
                    template = ModifierUnderDataTemplate;

                    break;
                default:

                    throw new ArgumentOutOfRangeException();
            }

            return template;
        }
    }
}