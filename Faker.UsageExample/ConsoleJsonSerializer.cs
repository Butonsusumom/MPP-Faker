using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Faker.UsageExample
{
    public static class ConsoleJsonSerializer
    {
        public static void Serialize<T>(T toSerialize)
        {
            using (var jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(Console.OpenStandardOutput(), Encoding.UTF8, ownsStream: true, indent: true))
            {
              new DataContractJsonSerializer(typeof(T)
                   ,new DataContractJsonSerializerSettings
              {
                 DateTimeFormat =  new DateTimeFormat("yyyy-MM-dd' Time 'HH:mm:ssZ")//("yyyy-MM-dd'T'HH:mm:ssZ")
              }
            ).WriteObject(jsonWriter, toSerialize);
              //new DataContractJsonSerializer(typeof(T)).WriteObject(jsonWriter, toSerialize);
            }
        }
    }
}
