using System;
using System.Collections.Generic;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker.ValueGenerators.GenericTypesGenerators.ArraysGenerators
{
    public class SingleRankArrayGenerator : IArrayGenerator
    {
        protected IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators;
        protected readonly ByteValueGenerator byteValueGenerator;

        public Type GeneratedType
        { get; protected set; }

        public int ArrayRank
        { get; protected set; }

        public object Generate(Type baseType)
        {
            if (baseTypesGenerators.TryGetValue(baseType, out IBaseTypeGenerator baseTypeGenerator))
            {
                Array result = Array.CreateInstance(baseType, (byte)byteValueGenerator.Generate());

                for (int i = 0; i < result.Length; i++)
                {
                    result.SetValue(baseTypeGenerator.Generate(), i);
                }
                return result;
            }
            else
            {
                return Array.CreateInstance(baseType, 0);
            }
        }

        public SingleRankArrayGenerator(IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators)
        {
            GeneratedType = typeof(Array);
            this.baseTypesGenerators = baseTypesGenerators;
            byteValueGenerator = new ByteValueGenerator();
            ArrayRank = 1;
        }
    }
}
