using Windows.UI.Core.AnimationMetrics;
using Weather.Model;
using Weather.ViewModel;

namespace Weather.ViewModel
{
    public class CurrentWeatherViewModel : ObservableObject
    {
        private CurrentWeather _currentWeather;

        public CurrentWeatherViewModel()
        {
            _currentWeather = new CurrentWeather();
        }

        public string City
        {
            get { return _currentWeather.City; }
            set
            {
                if (_currentWeather.City != value)
                {
                    _currentWeather.City = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public string Country
        {
            get { return _currentWeather.Country; }
            set
            {
                if (_currentWeather.Country != value)
                {
                    _currentWeather.Country = value;
                    OnPropertyChanged("City");
                }
            }
        }

        public string Temperature
        {
            get { return _currentWeather.Temperature; }
            set
            {
                if (_currentWeather.Temperature != value)
                {
                    _currentWeather.Temperature = value;
                    OnPropertyChanged("Temperature");
                }
            }
        }

        public string Wind
        {
            get { return _currentWeather.Wind; }
            set
            {
                if (_currentWeather.Wind != value)
                {
                    _currentWeather.Wind = value;
                    OnPropertyChanged("Wind");
                }
            }
        }

    }
}