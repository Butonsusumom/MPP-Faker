using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class ByteValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (byte)random.Next();
        }

        public ByteValueGenerator()
        {
            GeneratedType = typeof(byte);
            random = new Random();
        }
    }
}
