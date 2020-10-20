using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class DecimalValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (decimal)random.NextDouble();
        }

        public DecimalValueGenerator()
        {
            GeneratedType = typeof(decimal);
            random = new Random();
        }
    }
}
