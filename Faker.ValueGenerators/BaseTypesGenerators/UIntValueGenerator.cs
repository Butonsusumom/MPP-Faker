using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class UIntValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (uint)random.NextDouble();
        }

        public UIntValueGenerator()
        {
            GeneratedType = typeof(uint);
            random = new Random();
        }
    }
}
