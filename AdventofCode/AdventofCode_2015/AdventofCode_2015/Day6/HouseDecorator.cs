using System;
using System.Collections.Generic;
using System.Linq;

namespace Day6
{
    public class HouseDecorator
    {
        private readonly ChristmasLight[][] _lightsArrays;

        public HouseDecorator(int gridSize)
        {
            _lightsArrays = new ChristmasLight[gridSize][];
            for (int i = 0; i < gridSize; i++)
            {
                _lightsArrays[i] = new ChristmasLight[gridSize];
                //for (int j = 0; j < _lightsArrays.Length; j++)
                //{
                //    _lightsArrays[i][j] = new ChristmasLight();
                //}
            }
        }

        public int TurnOnChristmasLights(List<string> instructions)
        {
            var lightsOn = 0;
            foreach (var instruction in instructions)
            {
                var instructionArray = instruction.Split(' ');
                var coordinates = GetLightCoordinates(instructionArray);


                for (int i = coordinates["x_start"]; i <= coordinates["x_end"]; i++)
                {
                    for (int j = coordinates["y_start"]; j <= coordinates["y_end"]; j++)
                    {
                        if (_lightsArrays[i][j] == null)
                        {
                            _lightsArrays[i][j] = new ChristmasLight();
                        }

                        if (instructionArray.Contains("on"))
                        {
                            _lightsArrays[i][j].Brightness = 1;
                        }

                        else if (instructionArray.Contains("off"))
                        {
                            _lightsArrays[i][j].Brightness = 0;
                        }

                        else if (instructionArray.Contains("toggle"))
                        {
                            _lightsArrays[i][j].Brightness = _lightsArrays[i][j].Brightness == 1 ? 0 : 1;
                        }
                    }
                }
            }

            foreach (var lightsArray in _lightsArrays)
            {
                lightsOn += lightsArray.Where(l => l != null).Count(light => light.Brightness > 0);
            }

            return lightsOn;
        }

        public int ChangeBrightness(List<string> instructions)
        {
            var lightsOn = 0;
            foreach (var instruction in instructions)
            {
                var instructionArray = instruction.Split(' ');
                var coordinates = GetLightCoordinates(instructionArray);


                for (int i = coordinates["x_start"]; i <= coordinates["x_end"]; i++)
                {
                    for (int j = coordinates["y_start"]; j <= coordinates["y_end"]; j++)
                    {
                        if (_lightsArrays[i][j] == null)
                        {
                            _lightsArrays[i][j] = new ChristmasLight();
                        }
                        if (instructionArray.Contains("on"))
                        {
                            _lightsArrays[i][j].Brightness++;
                        }

                        else if (instructionArray.Contains("off"))
                        {
                            _lightsArrays[i][j].Brightness = _lightsArrays[i][j].Brightness == 0
                                ? 0
                                : _lightsArrays[i][j].Brightness-1;
                        }

                        else if (instructionArray.Contains("toggle"))
                        {
                            _lightsArrays[i][j].Brightness += 2;
                        }
                    }
                }
            }

            foreach (var lightsArray in _lightsArrays)
            {
                lightsOn += lightsArray.Where(l => l != null).Sum(light => light.Brightness);
            }

            return lightsOn;
        }




        private Dictionary<string, int> GetLightCoordinates(string[] instruction)
        {
            var coordinateInstructions = instruction.Where(x => x.Any(char.IsDigit)).ToList();
            var startCoordinates = coordinateInstructions[0].Split(',');
            var endCoordinates = coordinateInstructions[1].Split(',');

            var coordinates = new Dictionary<string,int>();
            coordinates.Add("x_start", Int32.Parse(startCoordinates[0]));
            coordinates.Add("x_end", Int32.Parse(endCoordinates[0]));
            coordinates.Add("y_start", Int32.Parse(startCoordinates[1]));
            coordinates.Add("y_end", Int32.Parse(endCoordinates[1]));

            return coordinates;
        }
    }
}