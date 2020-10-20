namespace Faker.UnitTests.TestClasses
{
    public class NullableFieldsWithConstructor : NullableFieldsNoConstructor
    {
        public NullableFieldsWithConstructor(char str)
        {
            stringField = str;
        }
    }
}
