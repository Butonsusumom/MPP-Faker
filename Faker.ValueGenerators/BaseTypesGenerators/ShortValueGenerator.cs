using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class ShortValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (short)random.Next();
        }

        public ShortValueGenerator()
        {
            GeneratedType = typeof(short);
            random = new Random();
        }
    }
}
