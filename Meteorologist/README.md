# Meteorologist

Meteorologist är ett program som läser väderdata från en .csv som består av en UnixTimeStamp och en temperatur. Programmet räknar sedan ut
* Första tidpunkten minusgrader uppmättes
* Den varmaste temperaturen
* Den kallaste temperaturen 
* Medelvärdet för varje dag i väderdata. 

```
Exempel output: 
	The following result is based on temperatures between Saturday, October 28, 2017 11:30:06 AM and Thursday, November 30, 2017 8:55:44 AM
	The highest temperature was Saturday, October 28, 2017 12:15:44 PM
	The first time the temperature was subzero was Saturday, October 28, 2017 11:30:08 AM and it was -0.5 degrees.
	The mean temperature was 2.64285714285714 degrees on Saturday,October 28
	The mean temperature was 7 degrees on Thursday,November 30
```

## Utveckling
* Visual Studio 2017
* C#

## Klasser
* `TemperatureData.cs` är ett objekt som håller en temperature kopplat till ett specifikt datum en specifik tid
* `WeatherResult.cs` är ett objekt som hjälper att printa ut resultatet efter att väderdata har bearbetats.
* `Meteorologist.cs` är klassen där själva logiken ligger. Klassen tar emot en lista med **TemperatureData-objekt**.
* `FileReader.cs` är klassen som hjälper till att läsa in väderdata från en fil. Finns bara implementerat för **.csv** nu.

## Test
* `WeatherPrognosisTest.cs`

## För att köra
* Starta programmet och skriv in fullständig filväg och en separator uppdelade med ett ',' emellan.
```
Exempel input: 
		C:\Users\li.wirstrom\Documents\Code is King\FFCG.CodeIsKing\Meteorologist\src\testTemperatureData.csv,;
```

## TODO
* Komma på bättre sätt att mata in fil och separator (ej med ',' då separatorn i sig kan var ','). 
* Skriva in filtyp i input för att hantera olika filtyper.
