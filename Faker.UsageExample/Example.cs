using System;
using Faker.ValueGenerators.CustomGenerators;

namespace Faker.UsageExample
{
    public class Example
    {
        public static void Main(string[] args)
        {
            FakerConfig config = new FakerConfig();
            config.Add<ExampleClassProperties, int, IntNonRandomGenerator>(ex => ex.CustomGeneratorCheckProperty);
           // config.Add<ExampleClassConstructor, int, IntNonRandomGenerator>(ex => ex.CustomGeneratorCheckProperty2);

            Faker faker = new Faker(config);

            ConsoleJsonSerializer.Serialize(faker.Create<ExampleClassProperties>());
          //  ConsoleJsonSerializer.Serialize(faker.Create<ExampleClassConstructor>());

            Console.ReadKey();

         /*   var faker = new Faker();
            ExampleClassProperties foo = faker.Create<ExampleClassProperties>();
            ConsoleJsonSerializer.Serialize(foo);
            Console.ReadKey();*/
        }
    }
}
