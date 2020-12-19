using System;
using System.Windows;
using System.Windows.Controls;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Enum;
using InvvardDev.EZLayoutDisplay.Keyboards.Common.Model;

namespace InvvardDev.EZLayoutDisplay.Keyboards.Zsa.Helper
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