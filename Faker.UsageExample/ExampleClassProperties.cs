using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Faker.UsageExample
{
    [DataContract]
    public class ExampleClassProperties
    {       
        [DataMember]
        public DateTime dateTimeField;
        [DataMember]
        public object objectField;
        [DataMember]
        public char publicStringField;
        [DataMember]
        public bool publicBoolField;
        [DataMember]
        protected bool nonPublicBoolField;

        [DataMember]
        public int PublicIntSetter
        { get; set; }

        [DataMember]
        public int NonPublicIntSetter
        { get; protected set; }

        [DataMember]
        private readonly int nonPublicIntField;

        [DataMember]
        public bool[] publicList;
        
       [DataMember]
         public List<int> publicArray;
        
        //[DataMember]
        //public List<List<char>> publicListInList;

        [DataMember]
        public ExampleClassProperties nestedObject;

        [DataMember]
        public int CustomGeneratorCheckProperty
        { get; set; }

        public ExampleClassProperties()
        { }
    }
}
