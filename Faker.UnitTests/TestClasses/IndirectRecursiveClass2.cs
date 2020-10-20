namespace Faker.UnitTests.TestClasses
{
    public class IndirectRecursiveClass2
    {
        public IndirectRecursiveClass1 InnerObject
        { get; set; }

        public IndirectRecursiveClass2(IndirectRecursiveClass1 class1)
        {
            InnerObject = class1;
        }
    }
}
