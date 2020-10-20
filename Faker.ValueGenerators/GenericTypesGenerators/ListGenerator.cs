using System;
using System.Collections;
using System.Collections.Generic;
using Faker.ValueGenerators.BaseTypesGenerators;
using Faker;

namespace Faker.ValueGenerators.GenericTypesGenerators
{
    public class ListGenerator : IGenericTypeGenerator
    {
        protected readonly ByteValueGenerator byteValueGenerator;
        protected IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators;
        //protected IDictionary<Type, IGenericTypeGenerator> genericTypesGenerators;

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
                byte listSize = (byte)byteValueGenerator.Generate();

                for (int i = 0; i < listSize; i++)
                {
                    //if(baseType==)
                    result.Add(Generate(baseType.GetGenericArguments()[0]));
                }
            }
            return result;
        }

        public ListGenerator(IDictionary<Type, IBaseTypeGenerator> baseTypesGenerators)
        {
            GeneratedType = typeof(List<>);
            this.baseTypesGenerators = baseTypesGenerators;
            //this.genericTypesGenerators = genericTypesGenerators;
            byteValueGenerator = new ByteValueGenerator();
        }
    }
}
