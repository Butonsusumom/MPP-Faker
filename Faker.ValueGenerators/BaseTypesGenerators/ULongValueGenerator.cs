using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class ULongValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (ulong)random.NextDouble();
        }

        public ULongValueGenerator()
        {
            GeneratedType = typeof(ulong);
            random = new Random();
        }
    }
}
