using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Foundation.Metadata;
using Windows.System;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Automation.Peers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Settings Flyout item template is documented at http://go.microsoft.com/fwlink/?LinkId=273769

namespace Weather.View
{
    public sealed partial class Options : SettingsFlyout
    {
        public Options()
        {
            this.InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += SettingsFlyout1_AcceleratorKeyActivated;
            };
            this.Unloaded += (sender, e) =>
            {
                Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated -= SettingsFlyout1_AcceleratorKeyActivated;
            };
        }

        void SettingsFlyout1_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        {
            // Only investigate further when Left is pressed
            if (args.EventType == CoreAcceleratorKeyEventType.SystemKeyDown &&
                args.VirtualKey == VirtualKey.Left)
            {
                var coreWindow = Window.Current.CoreWindow;
                var downState = CoreVirtualKeyStates.Down;

                // Check for modifier keys
                // The Menu VirtualKey signifies Alt
                bool menuKey = (coreWindow.GetKeyState(VirtualKey.Menu) & downState) == downState;
                bool controlKey = (coreWindow.GetKeyState(VirtualKey.Control) & downState) == downState;
                bool shiftKey = (coreWindow.GetKeyState(VirtualKey.Shift) & downState) == downState;

                if (menuKey && !controlKey && !shiftKey)
                {
                    args.Handled = true;
                    this.Hide();
                }
            }
        }

        private void zipCodeTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            zipCodeTextBox.Foreground = new SolidColorBrush(Colors.Black);
        
            if ("Zip code" == zipCodeTextBox.Text)
                zipCodeTextBox.Text = String.Empty;
        }
    }
}
