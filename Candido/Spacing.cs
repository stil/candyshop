using System.Windows;
using System.Windows.Controls;

namespace Candido
{
    public class Spacing
    {
        // Using a DependencyProperty as the backing store for Margin. This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalProperty = RegisterSpacingProperty("Horizontal");
        public static readonly DependencyProperty VerticalProperty = RegisterSpacingProperty("Vertical");

        private static DependencyProperty RegisterSpacingProperty(string name)
        {
            return DependencyProperty.RegisterAttached(name, typeof (double), typeof (Spacing),
                new UIPropertyMetadata(0.0, MarginChangedCallback));
        }

        public static double GetHorizontal(DependencyObject obj)
        {
            return (double) obj.GetValue(HorizontalProperty);
        }

        public static void SetHorizontal(DependencyObject obj, double value)
        {
            obj.SetValue(HorizontalProperty, value);
        }

        public static double GetVertical(DependencyObject obj)
        {
            return (double) obj.GetValue(VerticalProperty);
        }

        public static void SetVertical(DependencyObject obj, double value)
        {
            obj.SetValue(VerticalProperty, value);
        }

        public static void MarginChangedCallback(object sender, DependencyPropertyChangedEventArgs e)
        {
            // Make sure this is put on a panel
            var panel = sender as Panel;
            if (panel == null) return;
            panel.Loaded += panel_Loaded;
        }

        private static void panel_Loaded(object sender, RoutedEventArgs e)
        {
            var panel = (Panel) sender;

            // Go over the children and set margin for them:
            var first = true;
            foreach (var child in panel.Children)
            {
                if (first)
                {
                    first = false;
                    continue;
                }

                var fe = child as FrameworkElement;
                if (fe == null) continue;
                fe.Margin = new Thickness(GetHorizontal(panel) ,GetVertical(panel), fe.Margin.Right, fe.Margin.Bottom);
            }
        }
    }
}