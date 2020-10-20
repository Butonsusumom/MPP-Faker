using System;
using System.Collections.Generic;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker.ValueGenerators.GenericTypesGenerators.ArraysGenerators
{
    public class SingleRankArrayGenerator : IArrayGenerator
    {
        protected IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators;
        protected IDictionary<Type, IGenericTypeGenerator> genericTypesGenerators;
        protected readonly ByteValueGenerator byteValueGenerator;

        public Type GeneratedType { get; protected set; }

        public int ArrayRank { get; protected set; }

        public object Generate(Type baseType)
        {
            if (baseTypesGenerators.TryGetValue(baseType, out IBaseTypeGenerator baseTypeGenerator))
            {
                Array result = Array.CreateInstance(baseType, (byte) byteValueGenerator.Generate());

                for (int i = 0; i < result.Length; i++)
                {
                    result.SetValue(baseTypeGenerator.Generate(), i);
                }

                return result;
            }

            else
            {
                if (genericTypesGenerators.TryGetValue(baseType.GetGenericTypeDefinition(), out IGenericTypeGenerator genericTypeGenerator))
                {
                    Array result = Array.CreateInstance(baseType, (byte) byteValueGenerator.Generate());

                    for (int i = 0; i < result.Length; i++)
                    {
                        result.SetValue(genericTypeGenerator.Generate(baseType.GetGenericArguments()[0]), i);
                    }

                    return result;
                }
                else
                {
                    if (!(genericTypesGenerators.TryGetValue(baseType.GetGenericTypeDefinition(), out genericTypeGenerator)) &&
                        !(baseTypesGenerators.TryGetValue(baseType, out baseTypeGenerator)))
                    {
                        Array result = Array.CreateInstance(baseType, (byte) byteValueGenerator.Generate());

                        for (int i = 0; i < result.Length; i++)
                        {
                            Type t = baseType.GetElementType();
                            result.SetValue(Generate(baseType.GetElementType()), i);
                        }

                        return result;
                    }
                    else
                    {
                        return Array.CreateInstance(baseType, 0);
                    }
                }
            } 
        }

        public SingleRankArrayGenerator(IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators,IDictionary<Type, IGenericTypeGenerator> genericTypesGenerators)
        {
            GeneratedType = typeof(Array);
            this.baseTypesGenerators = baseTypesGenerators;
            this.genericTypesGenerators = genericTypesGenerators;
            byteValueGenerator = new ByteValueGenerator();
            ArrayRank = 1;
        }
    }
}
