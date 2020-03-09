using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Edikate.TimeManager.App.Controls
{
    public class EdikateContentControl : ContentControl
    {
        private Grid _contentGrid;

        private UIElement _currentView;

        public EdikateContentControl()
        {
            _contentGrid = new Grid();
            this.Content = _contentGrid;
        }

        public object CurrentItem
        {
            get { return (object)GetValue(CurrentItemProperty); }
            set { SetValue(CurrentItemProperty, value); }
        }

        public static readonly DependencyProperty CurrentItemProperty =
                DependencyProperty.Register("CurrentItem", typeof(object), typeof(EdikateContentControl),
                new PropertyMetadata(null, (s, e) => ((EdikateContentControl)s).OnCurrentItemChanged()));

        private void OnCurrentItemChanged()
        {
            var newView = EnsureItem(CurrentItem);
            SendToBack(_currentView);
            _currentView = newView;
        }

        private UIElement EnsureItem(object source)
        {
            if (source == null)
            {
                return null;
            }

            var view = GetView(source);

            if (!_contentGrid.Children.Contains(view))
            {
                SubscribeDeactivation(source);
                _contentGrid.Children.Add(view);
            }

            BringToFront(view);
            return view;
        }

        private UIElement GetView(object viewModel)
        {
            var context = View.GetContext(this);
            var view = ViewLocator.LocateForModel(viewModel, this, context);

            ViewModelBinder.Bind(viewModel, view, context);
            return view;
        }

        private void SubscribeDeactivation(object source)
        {
            if (source is IScreen sourceScreen)
            {
                sourceScreen.Deactivated += SourceScreen_Deactivated;
            }
        }

        private void SourceScreen_Deactivated(object sender, DeactivationEventArgs e)
        {
            if (e.WasClosed)
            {
                if (sender is IScreen sourceScreen)
                {
                    sourceScreen.Deactivated -= SourceScreen_Deactivated;

                    var view = GetView(sourceScreen);
                    _contentGrid.Children.Remove(view);
                }
            }
        }

        private void BringToFront(UIElement control)
        {
            control.Visibility = Visibility.Visible;
        }

        private void SendToBack(UIElement control)
        {
            if (control != null)
            {
                control.Visibility = Visibility.Collapsed;
            }
        }
    }
}