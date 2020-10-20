using System.Runtime.Serialization;

namespace Faker.UsageExample
{
    [DataContract]
    public class ExampleClassConstructor : ExampleClassProperties
    {
        [DataMember]
        public int CustomGeneratorCheckProperty2
        { get; set; }

        public ExampleClassConstructor(int intValue, bool boolValue, int customGeneratorCheckProperty, int customGeneratorCheckProperty2)
        {
            PublicIntSetter = intValue;
            publicBoolField = boolValue;
            CustomGeneratorCheckProperty = customGeneratorCheckProperty;
            CustomGeneratorCheckProperty2 = customGeneratorCheckProperty2;
        }
    }
}
