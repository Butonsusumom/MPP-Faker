namespace Faker.UnitTests.TestClasses
{
    public class IndirectRecursiveClass1
    {
        public IndirectRecursiveClass2 InnerObject
        { get; set; }

        public IndirectRecursiveClass1(IndirectRecursiveClass2 class2)
        {
            InnerObject = class2;
        }
    }
}
