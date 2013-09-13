using System;
using System.Collections.Generic;
using System.Text;

namespace MageTheorycraft
{
    class Chance
    {
        private static bool _initialised = false;
        private static Random _random;

        public static int RandomInt(int lower, int upper)
        {
            Initialise();

            return _random.Next(lower, upper);
        }

        public static double RandomDouble(double lower, double upper)
        {
            Initialise();

            return _random.NextDouble() * (upper - lower) + lower;
        }

        public static bool RandomChance(double chance)
        {
            Initialise();

            if (_random.NextDouble() <= chance)
                return true;
            else
                return false;
        }

        private static void Initialise()
        {
            if (!_initialised)
            {
                _random = new Random();

                _initialised = true;
            }
        }
    }
}
