using System;
using System.Collections.Generic;
using System.Linq;

namespace SpiralGridModell
{
    public enum Direction { Up, Down, Right, Left }
    public class SpiralGridModel
    {
        private List<NumberModel> numberModelsList { get; set; }

        public SpiralGridModel()
        {
            numberModelsList = new List<NumberModel>();
        }
        public NumberModel FindPosition(int finalNumber)
        {
            NumberModel numberModel = new NumberModel();
            int lap = 0;
            while (numberModel.Number < finalNumber)
            {
                if (numberModel.X_position == lap && numberModel.Y_position == -lap)
                {
                    numberModel = Move(numberModel, Direction.Right);
                    lap++;
                }
                else if (numberModel.Y_position == -(lap-1) && numberModel.X_position == lap)
                {
                    while (numberModel.Y_position != lap && numberModel.Number != finalNumber )
                    {
                        numberModel = Move(numberModel, Direction.Up);
                    }
                }
                else if (numberModel.Y_position == lap && numberModel.X_position == lap)
                {
                    while (numberModel.X_position > -lap && numberModel.Number != finalNumber)
                    {
                        numberModel = Move(numberModel, Direction.Left);
                    } 
                }
                else if (numberModel.X_position == -lap && numberModel.Y_position == lap)
                {
                    while (numberModel.Y_position > -lap && numberModel.Number != finalNumber)
                    {
                        numberModel = Move(numberModel, Direction.Down);
                    }
                }
                else if (numberModel.Y_position == -lap && numberModel.X_position == -lap)
                {
                    while (numberModel.X_position < lap && numberModel.Number != finalNumber)
                    {
                        numberModel = Move(numberModel, Direction.Right);
                    }
                }    
            }
            return numberModel;
        }

        public NumberModel CalculateWhenSumOvverridesValue(int valiueLimit)
        {
            NumberModel numberModel = new NumberModel();
            int lap = 0;
            while (numberModel.Number <= valiueLimit)
            {
                if (numberModel.X_position == lap && numberModel.Y_position == -lap)
                {
                    numberModel = MoveAndSum(numberModel, Direction.Right);
                    lap++;
                }
                else if (numberModel.Y_position == -(lap - 1) && numberModel.X_position == lap)
                {
                    while (numberModel.Y_position != lap && numberModel.Sum > valiueLimit)
                    {
                        numberModel = MoveAndSum(numberModel, Direction.Up);
                    }
                }
                else if (numberModel.Y_position == lap && numberModel.X_position == lap)
                {
                    while (numberModel.X_position > -lap && numberModel.Sum > valiueLimit)
                    {
                        numberModel = MoveAndSum(numberModel, Direction.Left);
                    }
                }
                else if (numberModel.X_position == -lap && numberModel.Y_position == lap)
                {
                    while (numberModel.Y_position > -lap && numberModel.Sum > valiueLimit)
                    {
                        numberModel = MoveAndSum(numberModel, Direction.Down);
                    }
                }
                else if (numberModel.Y_position == -lap && numberModel.X_position == -lap)
                {
                    while (numberModel.X_position < lap && numberModel.Sum > valiueLimit)
                    {
                        numberModel = MoveAndSum(numberModel, Direction.Right);
                    }
                }
            }
            return numberModel;
        }

        public int GetDistance(NumberModel numbermodel)
        {
            return Math.Abs(numbermodel.X_position) + Math.Abs(numbermodel.Y_position);
        }

        private NumberModel Move(NumberModel numberModel, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    numberModel.Y_position++;
                    numberModel.Number++;
                    return numberModel;
                case Direction.Down:
                    numberModel.Y_position--;
                    numberModel.Number++;
                    return numberModel;
                case Direction.Right:
                    numberModel.X_position++;
                    numberModel.Number++;
                    return numberModel;
                case Direction.Left:
                    numberModel.X_position--;
                    numberModel.Number++;
                    return numberModel;
            }
            return numberModel;
        }

        private NumberModel MoveAndSum(NumberModel numberModel, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    numberModel.Y_position++;
                    numberModel.Number++;
                    numberModelsList.Add(numberModel);
                    numberModel = CalculateSum(numberModel);
                    return numberModel;
                case Direction.Down:
                    numberModel.Y_position--;
                    numberModel.Number++;
                    numberModelsList.Add(numberModel);
                    numberModel = CalculateSum(numberModel);
                    return numberModel;
                case Direction.Right:
                    numberModel.X_position++;
                    numberModel.Number++;
                    numberModelsList.Add(numberModel);
                    numberModel = CalculateSum(numberModel);
                    return numberModel;
                case Direction.Left:
                    numberModel.X_position--;
                    numberModel.Number++;
                    numberModelsList.Add(numberModel);
                    numberModel = CalculateSum(numberModel);
                    return numberModel;
            }
            return numberModel;
        }

        private NumberModel CalculateSum(NumberModel number)
        {   
            for (int i = number.X_position-1 ; i <= number.X_position+1; i++)
            {
                for (int j = number.Y_position-1; j < number.Y_position+1; j++)
                {
                    if (!(i == number.X_position && j == number.Y_position))
                    {
                        if (numberModelsList.Where(obj => (obj.X_position == i) && (obj.Y_position == j)).FirstOrDefault() != null)
                        {
                            NumberModel correctNumber = numberModelsList.Where(obj => (obj.X_position == i) && (obj.Y_position == j)).First();
                            number.Sum += correctNumber.Sum;
                        }
                        else
                        {
                            number.Sum += 0;
                        }
                    }
                }
            }

            if (number.Sum == 0)
            {
                number.Sum = number.Number;
            }

            return number;
        }
    }
}
