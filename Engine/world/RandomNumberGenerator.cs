using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace Engine.world
{
    class RandomNumberGenerator
    {
        private static readonly RNGCryptoServiceProvider _generator
            = new RNGCryptoServiceProvider();

        public static int NumberBetween(int min, int max)
        {
            byte[] randomNumber = new byte[1];

            _generator.GetBytes(randomNumber);

            double asciiValueOfRandomNumber = Convert.ToDouble(randomNumber[0]);

            //Double.MinValue is just toooo 'small'
            double multiplier = Math.Max(0, (asciiValueOfRandomNumber /255d) - float.MinValue);

            int range = max - min + 1;

            double randInRange = Math.Floor(multiplier * range);

            return (int)(min + randInRange);
        }
    }
}
