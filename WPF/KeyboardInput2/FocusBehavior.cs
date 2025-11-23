using System.Windows;
using System.Windows.Input;

namespace KeyboardInput2
{
    public static class FocusBehavior
    {
        public static readonly DependencyProperty RequestFocusProperty =
            DependencyProperty.RegisterAttached(
                "RequestFocus",
                typeof(bool),
                typeof(FocusBehavior),
                new PropertyMetadata(false, OnRequestFocusChanged));

        public static void SetRequestFocus(DependencyObject obj, bool value)
            => obj.SetValue(RequestFocusProperty, value);

        public static bool GetRequestFocus(DependencyObject obj)
            => (bool)obj.GetValue(RequestFocusProperty);

        private static void OnRequestFocusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is UIElement element && (bool)e.NewValue == true)
            {
                element.Dispatcher.BeginInvoke(() =>
                {
                    element.Focus();
                    Keyboard.Focus(element);

                    // reset property so it can be triggered again
                    SetRequestFocus(d, false);
                });
            }
        }
    }
}
