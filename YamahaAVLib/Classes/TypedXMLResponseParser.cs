///******************************************************************
///Class implements base functionality to parse XML response from 
///Yamaha receiver. 
///******************************************************************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml.Linq;
using YamahaAVLib.Extensions;
using YamahaAVLib.YNC;

namespace YamahaAVLib.Classes
{
    public abstract class TypedXMLResponseParser
    {
        internal object Parse(PropertyInfo[] properties, XElement xdoc, List<string> tags = null)
        {
            object result = Activator.CreateInstance(properties[0].DeclaringType);

            foreach (PropertyInfo property in properties)
            {
                if (property.CustomAttributes.Count() > 0)
                {
                    List<string> loc_tags = (tags ?? new List<string>());
                    YNCTag tag = (YNCTag)Attribute.GetCustomAttribute(property, typeof(YNCTag));

                    if (tag != null)
                    {
                        loc_tags.Add(tag.Name);

                        if (property.PropertyType.GetProperties().Count() > 0 && property.PropertyType != typeof(string))
                        {
                            
                            if (property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(List<>))
                            {
                                Type itemType = property.PropertyType.GetGenericArguments()[0];
                                IList lst = CreateGenericList(itemType);
                                List <XElement> childNodes = xdoc.Descendants(tag.Name).Elements().ToList();

                                foreach (XElement el in childNodes)
                                {
                                    object complex = Parse(itemType.GetProperties(), xdoc, new List<string> { el.Name.ToString() });
                                    lst.Add(complex);
                                }

                                property.SetValue(result, lst);
                            }
                            else
                            {
                                object complex = Parse(property.PropertyType.GetProperties(), xdoc, loc_tags);
                                property.SetValue(result, complex);
                            }
                        }
                        else
                        {
                            object node_value = null;

                            if (property.PropertyType == typeof(int)) node_value = FindValue(xdoc, loc_tags).IntegerValue();
                            else if (property.PropertyType == typeof(bool)) node_value = FindValue(xdoc, loc_tags).BooleanValue();
                            else node_value = FindValue(xdoc, loc_tags).Value;

                            property.SetValue(result, node_value);
                        }

                        loc_tags.Remove(loc_tags[loc_tags.Count() - 1]);
                    }
                }
            }
            return result;
        }

        private XElement FindValue(XElement xdoc, List<string> nodes)
        {
            XElement element = xdoc;

            foreach (string node in nodes)
            {
                element = element.Descendants(node).FirstOrDefault();
            }

            return element;
        }

        private IList CreateGenericList(Type type)
        {
            Type genericTypeList = typeof(List<>);
            Type genericList = genericTypeList.MakeGenericType(type);
            ConstructorInfo constructor = genericList.GetConstructor(new Type[] { });
            return (IList)constructor.Invoke(new object[] { });
        }
    }
}
