using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Faker.ValueGenerators;
using Faker.ValueGenerators.BaseTypesGenerators;
using Faker.ValueGenerators.GenericTypesGenerators;
using Faker.ValueGenerators.GenericTypesGenerators.ArraysGenerators;

namespace Faker
{
    public class Faker : IFaker
    {
        public Dictionary<Type, IBaseTypeGenerator> baseTypesGenerators;
        public Dictionary<Type, IGenericTypeGenerator> genericTypesGenerators;
        public Dictionary<int, IArrayGenerator> arraysGenerators;

        public Dictionary<PropertyInfo, IBaseTypeGenerator> customGenerators;
        public Stack<Type> generatedTypes;

        protected const string defaultPluginsPath = "C:\\Users\\Ksusha\\Downloads\\mpp-dotnet-faker-master\\Plugins";

        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        protected object Create(Type type)
        {
            object generated;

            if (baseTypesGenerators.TryGetValue(type, out IBaseTypeGenerator baseTypeGenerator))
            {
                generated = baseTypeGenerator.Generate();
            }
            else if (type.IsGenericType && genericTypesGenerators.TryGetValue(type.GetGenericTypeDefinition(), out IGenericTypeGenerator genericTypeGenerator))
            {
                generated = genericTypeGenerator.Generate(type.GenericTypeArguments[0]);
            }
            else if (type.IsArray && arraysGenerators.TryGetValue(type.GetArrayRank(), out IArrayGenerator arrayGenerator))
            {
                generated = arrayGenerator.Generate(type.GetElementType());
            }
            else if (type.IsClass && !type.IsGenericType && !type.IsArray && !type.IsPointer && !type.IsAbstract && !generatedTypes.Contains(type))
            {
                int maxConstructorFieldsCount = 0, curConstructorFieldsCount;
                ConstructorInfo constructorToUse = null;

                foreach (ConstructorInfo constructor in type.GetConstructors())
                {
                    curConstructorFieldsCount = constructor.GetParameters().Length;
                    if (curConstructorFieldsCount > maxConstructorFieldsCount)
                    {
                        maxConstructorFieldsCount = curConstructorFieldsCount;
                        constructorToUse = constructor;
                    }
                }

                generatedTypes.Push(type);
                if (constructorToUse == null)
                {
                    generated = CreateByProperties(type);
                }
                else
                {
                    generated = CreateByConstructor(type, constructorToUse);
                }
                generatedTypes.Pop();
            }
            else if (type.IsValueType)
            {
                generated = Activator.CreateInstance(type);
            }
            else
            {
                generated = null;
            }

            return generated;
        }

        protected bool TryCreateByCustomGenerator(PropertyInfo propertyInfo, out object generated)
        {
            if (customGenerators.TryGetValue(propertyInfo, out IBaseTypeGenerator generator))
            {
                generated = generator.Generate();
                return true;
            }
            else
            {
                generated = default(object);
                return false;
            }
        }

        protected bool TryCreateByCustomGenerator(FieldInfo fieldInfo, out object generated)
        {
            foreach (KeyValuePair<PropertyInfo, IBaseTypeGenerator> keyValue in customGenerators)
            {
                if ((keyValue.Key.Name.ToLower() == fieldInfo.Name.ToLower()) && keyValue.Value.GeneratedType.Equals(fieldInfo.FieldType)
                    && keyValue.Key.ReflectedType.Equals(fieldInfo.ReflectedType))
                {
                    generated = keyValue.Value.Generate();
                    return true;
                }
            }
            generated = default(object);
            return false;
        }

        protected bool TryCreateByCustomGenerator(ParameterInfo parameterInfo, Type type, out object generated)
        {
            foreach (KeyValuePair<PropertyInfo, IBaseTypeGenerator> keyValue in customGenerators)
            {
                if ((keyValue.Key.Name.ToLower() == parameterInfo.Name.ToLower()) && keyValue.Value.GeneratedType.Equals(parameterInfo.ParameterType)
                    && keyValue.Key.ReflectedType.Equals(type))
                {
                    generated = keyValue.Value.Generate();
                    return true;
                }
            }
            generated = default(object);
            return false;
        }

        protected object CreateByProperties(Type type)
        {
            object generated = Activator.CreateInstance(type);

            foreach (FieldInfo fieldInfo in type.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
            {
                if (!TryCreateByCustomGenerator(fieldInfo, out object value))
                {
                    value = Create(fieldInfo.FieldType);
                }
                fieldInfo.SetValue(generated, value);
            }

            foreach (PropertyInfo propertyInfo in type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public))
            {
                if (propertyInfo.CanWrite)
                {
                    if (!TryCreateByCustomGenerator(propertyInfo, out object value))
                    {
                        value = Create(propertyInfo.PropertyType);
                    }
                    propertyInfo.SetValue(generated, value);
                }
            }

            return generated;
        }

        protected object CreateByConstructor(Type type, ConstructorInfo constructor)
        {
            var parametersValues = new List<object>();

            foreach (ParameterInfo parameterInfo in constructor.GetParameters())
            {
                if (!TryCreateByCustomGenerator(parameterInfo, type, out object value))
                {
                    value = Create(parameterInfo.ParameterType);
                }
                parametersValues.Add(value);
            }

            try
            {
                return constructor.Invoke(parametersValues.ToArray());
            }
            catch (TargetInvocationException)
            {
                return null;
            }
        }

        public Faker(string pluginsPath, IFakerConfig config)
        {
            IBaseTypeGenerator pluginGenerator;
            List<Assembly> assemblies = new List<Assembly>();

            generatedTypes = new Stack<Type>();
            baseTypesGenerators = GeneratorsSetCreator.CreateBaseTypesGeneratorsDictionary();
            genericTypesGenerators = GeneratorsSetCreator.CreateGenericTypesGeneratorsDictionary(baseTypesGenerators);
            arraysGenerators = GeneratorsSetCreator.CreateArraysGeneratorsDictionary(baseTypesGenerators,genericTypesGenerators);
            if (config == null)
            {
                customGenerators = new Dictionary<PropertyInfo, IBaseTypeGenerator>();
            }
            else
            {
                customGenerators = config.Generators;
            }

            try
            {
                foreach (string file in Directory.GetFiles(pluginsPath, "*.dll"))
                {
                    try
                    {
                        assemblies.Add(Assembly.LoadFile(file));
                    }
                    catch (BadImageFormatException)
                    { }
                    catch (FileLoadException)
                    { }
                }
            }
            catch (DirectoryNotFoundException)
            { }

            foreach (Assembly assembly in assemblies)
            {
                foreach (Type type in assembly.GetTypes())
                {
                    foreach (Type typeInterface in type.GetInterfaces())
                    {
                        if (typeInterface.Equals(typeof(IBaseTypeGenerator)))
                        {
                            pluginGenerator = (IBaseTypeGenerator)Activator.CreateInstance(type);
                            baseTypesGenerators.Add(pluginGenerator.GeneratedType, pluginGenerator);
                        }
                    }
                }
            }
        }

        public Faker()
            : this(defaultPluginsPath, null)
        { }

        public Faker(string pluginsPath)
            : this(pluginsPath, null)
        { }

        public Faker(IFakerConfig config)
            : this(defaultPluginsPath, config)
        { }
    }
}
