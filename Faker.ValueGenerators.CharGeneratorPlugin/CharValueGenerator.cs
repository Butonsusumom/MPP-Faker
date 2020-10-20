using System;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker.ValueGenerators.CharGeneratorPlugin
{
    public class CharValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            char[] base64Representation = new char[4]; // base64 representation of 1 byte is 2 chars with 2 padding chars

            Convert.ToBase64CharArray(inArray: new byte[] { (byte)random.Next() }, offsetIn: 0, length: 1, outArray: base64Representation, offsetOut: 0);
            return base64Representation[random.Next(0, 2)];
        }

        public CharValueGenerator()
        {
            GeneratedType = typeof(char);
            random = new Random();
        }
    }
}
