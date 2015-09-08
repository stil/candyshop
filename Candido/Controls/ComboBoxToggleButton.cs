using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace Candido.Controls
{
    /// <summary>
    ///     Adds additional InnerBorderBrush property, so it can hold both outer and inner border brush.
    /// </summary>
    public class ComboBoxToggleButton : ToggleButton
    {
        public static readonly DependencyProperty InnerBorderBrushProperty =
            DependencyProperty.Register("InnerBorderBrush", typeof (Brush),
                typeof (ComboBoxToggleButton), new FrameworkPropertyMetadata(Brushes.Transparent));

        public Brush InnerBorderBrush
        {
            get { return (Brush) GetValue(InnerBorderBrushProperty); }
            set { SetValue(InnerBorderBrushProperty, value); }
        }
    }
}