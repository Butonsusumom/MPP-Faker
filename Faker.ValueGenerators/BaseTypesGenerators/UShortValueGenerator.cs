using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class UShortValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (ushort)random.Next();
        }

        public UShortValueGenerator()
        {
            GeneratedType = typeof(ushort);
            random = new Random();
        }
    }
}
