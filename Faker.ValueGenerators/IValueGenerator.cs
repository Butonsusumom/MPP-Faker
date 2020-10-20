using System;

namespace Faker.ValueGenerators
{
    public interface IValueGenerator
    {
        Type GeneratedType { get; }
    }
}
