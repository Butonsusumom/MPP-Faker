using System;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker.ValueGenerators.StringGeneratorPlugin
{
    public class StringValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            byte[] stringBytes = new byte[random.Next(0, byte.MaxValue)]; // max length of output string will be max value of byte (255) * 4 / 3

            random.NextBytes(stringBytes);
            return Convert.ToBase64String(stringBytes);
        }

        public StringValueGenerator()
        {
            GeneratedType = typeof(string);
            random = new Random();
        }
    }
}
