using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class LongValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (long)random.NextDouble();
        }

        public LongValueGenerator()
        {
            GeneratedType = typeof(long);
            random = new Random();
        }
    }
}
