using System;

namespace Faker.UnitTests.TestClasses
{
    public class NullablePropertiesWithConstructor : NullablePropertiesNoConstructor
    {
        public NullablePropertiesWithConstructor(DateTime dateTime)
        {
            DateTimeProperty = dateTime;
        }
    }
}
