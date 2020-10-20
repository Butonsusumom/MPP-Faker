namespace Faker.UnitTests.TestClasses
{
    public class CustomGenerationConstructorClass : CustomGenerationPropertyClass
    {
        public int SomeValue2
        { get; private set; }

        public CustomGenerationConstructorClass(int someValue, int someValue2)
        {
            SomeValue = someValue;
            this.someValue = someValue;
            SomeValue2 = someValue2;
        }
    }
}
