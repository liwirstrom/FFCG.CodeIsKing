using System;

namespace MeteorologistLogic
{
    public class TemperatureData
    {
        public DateTime TimeStamp { get; private set; }
        public double Temperature { get; private set; }

        public TemperatureData() { }
        public TemperatureData(string timeStamp, string temperature, int rowNr)
        {
            try
            {
                double unixTimeStamp = Convert.ToDouble(timeStamp);
                TimeStamp = UnixTimeStampToDateTime(unixTimeStamp);
                Temperature = Convert.ToDouble(temperature);
            }
            catch (FormatException exception)
            {
                Console.WriteLine($"Could not create TemperatureData object from row {rowNr}. {exception}");
            }

        }

        private DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            System.DateTime dateDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dateDateTime = dateDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateDateTime;
        }

    }
}
