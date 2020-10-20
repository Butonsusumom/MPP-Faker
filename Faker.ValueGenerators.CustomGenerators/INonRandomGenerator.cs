namespace Faker.ValueGenerators.CustomGenerators
{
    public interface INonRandomGenerator : IValueGenerator
    {
        int GeneratedValue
        { get; }
    }
}
