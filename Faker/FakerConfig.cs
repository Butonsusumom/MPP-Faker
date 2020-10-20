using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Faker.ValueGenerators.BaseTypesGenerators;

namespace Faker
{
    public class FakerConfig : IFakerConfig
    {
        protected Dictionary<PropertyInfo, IBaseTypeGenerator> generators;

        public Dictionary<PropertyInfo, IBaseTypeGenerator> Generators
        {
            get => new Dictionary<PropertyInfo, IBaseTypeGenerator>(generators);
        }

        public void Add<TClass, TPropertyType, TGenerator>(Expression<Func<TClass, TPropertyType>> expression)
            where TClass : class
            where TGenerator : IBaseTypeGenerator, new()
        {
            Expression expressionBody = expression.Body;
            if (expressionBody.NodeType != ExpressionType.MemberAccess)
            {
                throw new ArgumentException("Illegal expression");
            }
            IBaseTypeGenerator generator = (IBaseTypeGenerator)Activator.CreateInstance(typeof(TGenerator));
            if (!generator.GeneratedType.Equals(typeof(TPropertyType)))
            {
                throw new ArgumentException("Illegal generator");
            }
            generators.Add((PropertyInfo)((MemberExpression)expressionBody).Member, generator);
        }

        public FakerConfig()
        {
            generators = new Dictionary<PropertyInfo, IBaseTypeGenerator>();
        }
    }
}
