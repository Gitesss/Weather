using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Weather.ViewModel;
using Weather.Model;

namespace Weather.ViewModel
{
    public class ApplicationViewModel
    {
        public ObservableCollection<DayViewModel> WeatherDays { get; set; }
        private XNamespace yWeatherNS = "http://xml.weather.yahoo.com/ns/rss/1.0";
        //   private string query = String.Format("http://weather.yahooapis.com/forecastrss?w=");
        public string ZipCode { get; set; }

        public CurrentWeatherViewModel CurrentWeatherProperty { get; set; }

        public ApplicationViewModel()
        {
            WeatherDays = new ObservableCollection<DayViewModel>();
            //  ZipCode = "523920";
            //  query += ZipCode;
            // query += "u=c&d=10";
            GetWeatherDaysOfTheWeek();
            GetCurrentWeather();
        }

        private void GetWeatherDaysOfTheWeek()
        {
            string query = "http://weather.yahooapis.com/forecastrss?w=523920&u=c&d=10";
            XDocument rssXml = XDocument.Load(query);

            rssXml.Root.ReplaceAll(XElement.Load(query));
            var weatherDaysList = (from weatherday in rssXml.Descendants(yWeatherNS + "forecast") select weatherday);

            foreach (var day in weatherDaysList)
            {
                WeatherDays.Add(new DayViewModel()
                {
                    Day = day.Attribute("day").Value,
                    Date = day.Attribute("date").Value,
                    High = int.Parse(day.Attribute("high").Value),
                    Low = int.Parse(day.Attribute("low").Value),
                    Text = day.Attribute("text").Value,
                    Image = "Assets/white/" + day.Attribute("code").Value + ".png",
                });
            }
        }

        private void GetCurrentWeather()
        {
            string query = "http://weather.yahooapis.com/forecastrss?w=523920&u=c&d=10";
            XDocument rssXml = XDocument.Load(query);

            rssXml.Root.ReplaceAll(XElement.Load(query));

            var searchLocation = rssXml.Descendants(yWeatherNS + "location").FirstOrDefault();
            var searchTemperature = rssXml.Descendants(yWeatherNS + "condition").FirstOrDefault();
            var searchWind = rssXml.Descendants(yWeatherNS + "wind").FirstOrDefault();

            CurrentWeatherViewModel currentWeatherViewModel = new CurrentWeatherViewModel()
            {
                City = searchLocation.Attribute("city").Value,
                Country = searchLocation.Attribute("country").Value,
                Temperature = searchTemperature.Attribute("temp").Value + "°C",
                Wind = searchWind.Attribute("speed").Value + " km/h"
            };
            CurrentWeatherProperty = currentWeatherViewModel;
        }
    }
}