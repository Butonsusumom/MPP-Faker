namespace Faker.UnitTests.TestClasses
{
    public class SelfRecursiveClassWithConstructor
    {
        public SelfRecursiveClassWithConstructor innerObject;

        public SelfRecursiveClassWithConstructor(SelfRecursiveClassWithConstructor inner)
        {
            innerObject = inner;
        }
    }
}
