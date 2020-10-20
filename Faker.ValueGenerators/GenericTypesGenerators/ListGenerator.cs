using System;
using System.Collections;
using System.Collections.Generic;
using Faker.ValueGenerators.BaseTypesGenerators;
using Faker.ValueGenerators.GenericTypesGenerators.ArraysGenerators;
using Faker;

namespace Faker.ValueGenerators.GenericTypesGenerators
{
    public class ListGenerator : IGenericTypeGenerator
    {
        protected readonly ByteValueGenerator byteValueGenerator;
        protected IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators;

        public Type GeneratedType
        { get; protected set; }

        public object Generate(Type baseType)
        {

            IList result = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(baseType));

            if (baseTypesGenerators.TryGetValue(baseType, out IBaseTypeGenerator baseTypeGenerator))
            {
                byte listSize = (byte)byteValueGenerator.Generate();

                for (int i = 0; i < listSize; i++)
                {
                    result.Add(baseTypeGenerator.Generate());
                }
            }
            else 
            {
                if(baseType.IsArray)
                {
                    byte listSize = (byte) byteValueGenerator.Generate();

                    for (int i = 0; i < listSize; i++)
                    {
                        result.Add(Generate(baseType.GetElementType()));
                    }
                }
                else
                {
                    byte listSize = (byte) byteValueGenerator.Generate();
                   // IArrayGenerator arrayTypeGenerator = new SingleRankArrayGenerator();
                    //SingleRankArrayGenerator arrayGenerator = new SingleRankArrayGenerator(baseTypesGenerators,genericTypesGenerators);
                    for (int i = 0; i < listSize; i++)
                        
                    {
                        
                        result.Add(Generate(baseType.GetGenericArguments()[0]));
                    }
                }
            }
            return result;
        }

        public ListGenerator(IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators)
        {
            GeneratedType = typeof(List<>);
            this.baseTypesGenerators = baseTypesGenerators;
            byteValueGenerator = new ByteValueGenerator();
        }
    }
}
