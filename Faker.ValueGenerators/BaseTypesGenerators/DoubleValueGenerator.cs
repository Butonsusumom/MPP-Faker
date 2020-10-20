using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class DoubleValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return random.NextDouble();
        }

        public DoubleValueGenerator()
        {
            GeneratedType = typeof(double);
            random = new Random();
        }
    }
}
