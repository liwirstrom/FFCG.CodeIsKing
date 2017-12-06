using System;

namespace SpiralGridModell
{
    public enum Direction { Up, Down, Right, Left }
    public class SpiralGridModel
    {
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
                    //Console.WriteLine(numberModel.Number);
                    return numberModel;
                case Direction.Down:
                    numberModel.Y_position--;
                    numberModel.Number++;
                   // Console.WriteLine(numberModel.Number);
                    return numberModel;
                case Direction.Right:
                    numberModel.X_position++;
                    numberModel.Number++;
                   // Console.WriteLine(numberModel.Number);
                    return numberModel;
                case Direction.Left:
                    numberModel.X_position--;
                    numberModel.Number++;
                   // Console.WriteLine(numberModel.Number);
                    return numberModel;
            }
            return numberModel;
        }
    }
}
