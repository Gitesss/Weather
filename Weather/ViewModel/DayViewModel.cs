using Weather.Model;

namespace Weather.ViewModel
{
    public class DayViewModel : ObservableObject
    {
        private Days _weatherdays;

        public DayViewModel()
        {
            _weatherdays = new Days();
        }

        public string Day
        {
            get { return _weatherdays.Day; }
            set
            {
                if (_weatherdays.Day != value)
                {
                    _weatherdays.Day = value;
                    OnPropertyChanged("Day");
                }
            }
        }

        public string Date
        {
            get { return _weatherdays.Date; }
            set
            {
                if (_weatherdays.Date != value)
                {
                    _weatherdays.Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        public int Low
        {
            get { return _weatherdays.Low; }
            set
            {
                if (_weatherdays.Low != value)
                {
                    _weatherdays.Low = value;
                    OnPropertyChanged("Low");
                }
            }
        }

        public int High
        {
            get { return _weatherdays.High; }
            set
            {
                if (_weatherdays.High != value)
                {
                    _weatherdays.High = value;
                    OnPropertyChanged("High");
                }
            }
        }

        public string Text
        {
            get { return _weatherdays.Text; }
            set
            {
                if (_weatherdays.Text != value)
                {
                    _weatherdays.Text = value;
                    OnPropertyChanged("Text");
                }
            }
        }

        public string Image
        {
            get { return _weatherdays.Image; }
            set
            {
                if (_weatherdays.Image != value)
                {
                    _weatherdays.Image = value;
                    OnPropertyChanged("Image");
                }
            }
        }
    }
}