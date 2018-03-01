namespace WeatherApplication.Models
{
	public interface IWeatherImportService
    {
		void SaveAllStations();
		void SaveHistoricalAirTemperatures(string line);
    }
}
