using Newtonsoft.Json;
using System;
using WeatherApplication.Logic;

namespace WeatherApplication.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var dataImporter = new DataImporter();
            var stationList = dataImporter.CreateSimpleStationList("https://opendata-download-metobs.smhi.se/api/version/latest/parameter/1.json");
			//dataImporter.SaveInLocalTextFile(stationList, @"C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\WeatherApplication\src\Data\stations.json");
			dataImporter.SaveInLocalDatabase(stationList);
		}
    }
}
