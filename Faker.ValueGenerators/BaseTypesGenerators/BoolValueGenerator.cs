using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class BoolValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return random.Next() % 2 == 0;
        }

        public BoolValueGenerator()
        {
            GeneratedType = typeof(bool);
            random = new Random();
        }
    }
}
