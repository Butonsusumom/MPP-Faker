using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class IntValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return random.Next();
        }

        public IntValueGenerator()
        {
            GeneratedType = typeof(int);
            random = new Random();
        }
    }
}
