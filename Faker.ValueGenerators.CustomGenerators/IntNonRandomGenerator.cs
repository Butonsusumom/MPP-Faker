using System;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker.ValueGenerators.CustomGenerators
{
    public class IntNonRandomGenerator : IBaseTypeGenerator, INonRandomGenerator
    {
        public static int DefaultGeneratedValue
        { get => 42; }

        public Type GeneratedType
        { get; protected set; }

        public int GeneratedValue
        { get; protected set; }

        public object Generate()
        {
            return GeneratedValue;
        }

        public IntNonRandomGenerator()
            : this(DefaultGeneratedValue)
        { }

        public IntNonRandomGenerator(int generatedValue)
        {
            GeneratedType = typeof(int);
            GeneratedValue = generatedValue;
        }
    }
}
