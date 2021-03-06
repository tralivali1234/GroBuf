using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GroBuf.DataMembersExtracters
{
    public class PropertiesExtractor : IDataMembersExtractor
    {
        public IDataMember[] GetMembers(Type type)
        {
            var result = new List<IDataMember>();
            GetMembers(type, result);
            return result.ToArray();
        }

        private static void GetMembers(Type type, List<IDataMember> members)
        {
            if(type == null || type == typeof(object))
                return;
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
            members.AddRange(properties.Where(property => property.CanRead && property.GetGetMethod(true).GetParameters().Length == 0 && property.CanWrite && property.GetSetMethod(true).GetParameters().Length == 1).Select(DataMember.Create));
            GetMembers(type.BaseType, members);
        }
    }
}