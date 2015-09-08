using System.Windows;
using System.Windows.Controls;

namespace Candido.Selectors
{
    internal class LastItemStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            var itemsControl = ItemsControl.ItemsControlFromItemContainer(container);
            var index = itemsControl.ItemContainerGenerator.IndexFromContainer(container);

            if (index == itemsControl.Items.Count - 1)
            {
                return (Style) itemsControl.FindResource("LastItemStyle");
            }

            return base.SelectStyle(item, container);
        }
    }
}