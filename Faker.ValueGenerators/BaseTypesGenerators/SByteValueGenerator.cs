using System;

namespace Faker.ValueGenerators.BaseTypesGenerators
{
    public class SByteValueGenerator : IBaseTypeGenerator
    {
        protected readonly Random random;

        public Type GeneratedType
        { get; protected set; }

        public object Generate()
        {
            return (sbyte)random.Next();
        }

        public SByteValueGenerator()
        {
            GeneratedType = typeof(sbyte);
            random = new Random();
        }
    }
}
