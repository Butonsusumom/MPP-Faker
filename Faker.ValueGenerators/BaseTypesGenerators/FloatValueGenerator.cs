using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class FloatValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (float)random.NextDouble();
        }

        public FloatValueGenerator()
        {
            GeneratedType = typeof(float);
            random = new Random();
        }
    }
}
