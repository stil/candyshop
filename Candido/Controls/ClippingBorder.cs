using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Candido.Controls
{
    /// <summary>
    ///     Custom border that clips contents if CornerRadius is higher than zero.
    /// </summary>
    public class ClippingBorder : Border
    {
        private readonly RectangleGeometry _clipRect = new RectangleGeometry();
        private object _oldClip;

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (ReferenceEquals(Child, value)) return;
                if (Child != null)
                {
                    // Restore original clipping
                    Child.SetValue(ClipProperty, _oldClip);
                }

                _oldClip = value != null ? value.ReadLocalValue(ClipProperty) : null;

                base.Child = value;
            }
        }

        protected override void OnRender(DrawingContext dc)
        {
            OnApplyChildClip();
            base.OnRender(dc);
        }

        protected virtual void OnApplyChildClip()
        {
            if (Child == null) return;
            _clipRect.RadiusX = _clipRect.RadiusY = Math.Max(0.0, CornerRadius.TopLeft - (BorderThickness.Left*0.5));
            _clipRect.Rect = new Rect(Child.RenderSize);
            Child.Clip = _clipRect;
        }
    }
}