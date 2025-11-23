using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace WpfFocusFinal.Behaviors
{
    public static class FocusOnContentBehavior
    {
        public static readonly DependencyProperty EnableProperty =
            DependencyProperty.RegisterAttached(
                "Enable",
                typeof(bool),
                typeof(FocusOnContentBehavior),
                new PropertyMetadata(false, OnEnableChanged));

        public static void SetEnable(DependencyObject obj, bool value) =>
            obj.SetValue(EnableProperty, value);

        public static bool GetEnable(DependencyObject obj) =>
            (bool)obj.GetValue(EnableProperty);

        private static void OnEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ContentControl cc)
            {
                var descriptor = DependencyPropertyDescriptor.FromProperty(
                    ContentControl.ContentProperty, typeof(ContentControl));

                if (descriptor == null)
                    return;

                if ((bool)e.NewValue)
                    descriptor.AddValueChanged(cc, OnContentChanged);
                else
                    descriptor.RemoveValueChanged(cc, OnContentChanged);
            }
        }

        private static void OnContentChanged(object sender, EventArgs e)
        {
            if (!(sender is ContentControl cc))
                return;

            // Defer until visual tree is updated and template applied
            cc.Dispatcher.BeginInvoke((Action)(() =>
            {
                try
                {
                    var contentVm = cc.Content;
                    if (contentVm == null)
                        return;

                    // Find the child element whose DataContext equals the content VM
                    var view = FindVisualChildByDataContext(cc, contentVm);
                    if (view != null)
                    {
                        // Make sure view can receive focus
                        if (view is UIElement ui)
                        {
                            ui.Focusable = true;
                            // Ensure it is focusable for keyboard
                            ui.Dispatcher.BeginInvoke((Action)(() =>
                            {
                                ui.Focus();
                                Keyboard.Focus(ui);
                            }), DispatcherPriority.Input);
                        }
                    }
                }
                catch
                {
                    // swallow: don't throw from UI handler
                }
            }), DispatcherPriority.Loaded);
        }

        private static FrameworkElement FindVisualChildByDataContext(DependencyObject parent, object dataContextToFind)
        {
            if (parent == null)
                return null;

            int count = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is FrameworkElement fe)
                {
                    // If this child's DataContext is the view model, we've found the view
                    if (ReferenceEquals(fe.DataContext, dataContextToFind))
                        return fe;

                    // Otherwise, recurse
                    var result = FindVisualChildByDataContext(child, dataContextToFind);
                    if (result != null)
                        return result;
                }
                else
                {
                    // still recurse on non-FrameworkElement children
                    var result = FindVisualChildByDataContext(child, dataContextToFind);
                    if (result != null)
                        return result;
                }
            }
            return null;
        }
    }
}
