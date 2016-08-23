namespace Earthware.Selenium.Helpers
{
    using System;
    using System.Linq;

    public static class DataGenerator
    {
        public static string RandomString(int length = 10)
        {
            var random = new Random();

            var randomName = new string(Enumerable.Repeat("abcdefgjiklmnopqrstuvwxyz1234567890", length)
                .Select(s => s[random.Next(length)])
                .ToArray());

            return randomName;
        }
    }
}