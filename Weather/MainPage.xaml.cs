using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

using Weather.Model;
using Weather.View;
using Weather.ViewModel;

namespace Weather
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            WeatherControl.DataContext = ViewModel.CurrentWeatherProperty;
            WeatherControl.Start();
            Fun.DataContext = ViewModel.CurrentWeatherProperty;
        }

        private void ShowOptions_OnClick(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                Options sf = new Options();
                sf.ShowIndependent();
            }
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            zipCodeText.Background = new SolidColorBrush(Colors.White);

            if ("Wpisz ZipCode" == zipCodeText.Text)
                zipCodeText.Text = String.Empty;
        }
    }
}
