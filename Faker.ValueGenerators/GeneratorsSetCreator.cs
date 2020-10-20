using System;
using System.Collections.Generic;
using Faker.ValueGenerators.BaseTypesGenerators;
using Faker.ValueGenerators.GenericTypesGenerators;
using Faker.ValueGenerators.GenericTypesGenerators.ArraysGenerators;

namespace Faker.ValueGenerators
{
    public static class GeneratorsSetCreator
    {
        private static void AddBaseGeneratorToDictionary(IBaseTypeGenerator generator, Dictionary<Type, IBaseTypeGenerator> dictionary)
        {
            dictionary.Add(generator.GeneratedType, generator);
        }

        public static Dictionary<Type, IBaseTypeGenerator> CreateBaseTypesGeneratorsDictionary()
        {
            var dictionary = new Dictionary<Type, IBaseTypeGenerator>();

            AddBaseGeneratorToDictionary(new BoolValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new ByteValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new DateTimeValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new DecimalValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new DoubleValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new FloatValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new IntValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new LongValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new SByteValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new ShortValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new UIntValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new ULongValueGenerator(), dictionary);
            AddBaseGeneratorToDictionary(new UShortValueGenerator(), dictionary);

            return dictionary;
        }

        public static Dictionary<Type, IGenericTypeGenerator> CreateGenericTypesGeneratorsDictionary(Dictionary<Type, IBaseTypeGenerator> baseTypesGenerators)
        {
            var dictionary = new Dictionary<Type, IGenericTypeGenerator>();
            IGenericTypeGenerator generator;

            generator = new ListGenerator(baseTypesGenerators);
            dictionary.Add(generator.GeneratedType, generator);

            return dictionary;
        }

        public static Dictionary<int, IArrayGenerator> CreateArraysGeneratorsDictionary(Dictionary<Type, IBaseTypeGenerator> baseTypesGenerators)
        {
            var dictionary = new Dictionary<int, IArrayGenerator>();
            IArrayGenerator generator;

            generator = new SingleRankArrayGenerator(baseTypesGenerators);
            dictionary.Add(generator.ArrayRank, generator);

            return dictionary;
        }
    }
}
