using System;

namespace Faker.ValueGenerators.GenericTypesGenerators
{
    public interface IGenericTypeGenerator : IValueGenerator
    {
        object Generate(Type baseType);
    }
}
