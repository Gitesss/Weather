namespace Weather.Model
{
    public class YahooWeatherRssItem
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public int Temperature { get; set; }
        public string Date { get; set; }
        public string Geolocation { get; set; }
        public string Text { get; set; } 
    }
}