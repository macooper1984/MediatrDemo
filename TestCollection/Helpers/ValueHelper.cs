using System;
using System.Linq;

namespace TestCollection.Helpers
{
    public static class ValueHelper
    {
        private static readonly Random Random = new Random();

        const string ValidChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        public static string RandomString(int length)
        {

            var chars = Enumerable.Range(0, length)
                .Select(n => ValidChars[Random.Next(ValidChars.Length)])
                .ToArray();

            return new string(chars);
        }

        public static int RandomInt(int maxValue)
        {
            return Random.Next(maxValue);
        }
    }
}