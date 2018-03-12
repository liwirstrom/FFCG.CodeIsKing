# WeatherApplicaion

En väderapplikation för att hämta lufttemperaturer för olika väderstationer i Sverige. 

## Teknik
- Utvecklingsmiljö : VisualStudio 2017
- EntityFramework 
- .Net Core 2.0

## Endpoints

**GET**
- `http://localhost:5000/api/weather/` : List alla stations
- `http://localhost:5000/api/weather/{stationId}` : Visar detaljerad information för en viss station med inskickat id
- `http://localhost:5000/api/weather/{stationId}/temperatures/` : Visar 50 senaste temperaturmätningarna för 
- `http://localhost:5000/api/weather/{stationId}/temperatures/{datum}` : Visar temperaturmätningar för ett specifikt datum för en viss station. Datumformatet är 'yy-MM-dd'

**POST**
- `http://localhost:5000/api/import/smhi/stations/` : Hämtar ner alla stationer till en lokaldatabas
- `http://localhost:5000/api/import/smhi/stations/{stationId}/temperature` : Hämtar ner historiska temperaturdata för definierad station.