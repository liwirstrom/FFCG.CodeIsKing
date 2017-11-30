using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public interface IRandom
    {

        int min { get; set; }
        int max { get; set; }
        int GetRandom();
    }

    public class MyRandom : IRandom
    {
        private int _min;
        private int _max;

        public MyRandom(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int min
        {
            get
            { return _min;}

            set
            { _min = value;}
        }

        public int max
        {
            get
            { return _max;}
            set
            { _max = value;}
        }

        public int GetRandom()
        {
            System.Random random = new System.Random();
            return random.Next(min, max + 1);
        }
    }

    public class MockRandom : IRandom
    {
        private int _min;
        private int _max;

        public MockRandom(int min, int max)
        {
            _min = min;
            _max = max;
        }

        public int min
        {
            get
            { return _min;}

            set
            { _min = value;}
        }

        public int max
        {
            get
            {return _max;}

            set
            { _max = value;}
        }

        public int GetRandom()
        {
            return _max;
        }
    }
}
