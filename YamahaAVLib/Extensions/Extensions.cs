using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;

namespace YamahaAVLib.Extensions
{
    internal static class Extensions
    {

        /// <summary>
        /// Translates XElement structure to XML text
        /// </summary>
        /// <returns>XML string</returns>
        public static string ToXMLString(this XElement xDoc)
        {
            string result;

            using (UTF8Writer writer = new UTF8Writer())
            {
                xDoc.Save(writer);
                result = writer.ToString();
            }

            return result.Replace("\r", "").Replace("\n", "");
        }

        public static string ToXMLString(this HttpWebResponse response, Encoding encoding)
        {
            string result = "";

            if (response != null)
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream(), encoding))
                {
                    result = sr.ReadToEnd();
                }
            }

            return result;
        }

        public static TAttribute GetAttribute<TAttribute>(this Enum value) where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return (TAttribute)enumType.GetField(name).GetCustomAttributes(false).Where(f => f.GetType() == typeof(TAttribute)).SingleOrDefault();
            //return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }

        public static string CommaSplit(this string str, int part)
        {
            string[] parts = str.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            if (part <= parts.Length - 1)
            {
                return parts[part];
            }
            else return string.Empty;
        }

        public static string EqualSplit(this string str, int part)
        {
            string[] parts = str.Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

            if (part <= parts.Length - 1)
            {
                return parts[part];
            }
            else return string.Empty;
        }

        public static string CleanSpaces(this string str)
        {
            return str.Replace(" ", "");
        }

        public static string ToOnOff(this Boolean value)
        {
            if (value == true) return "On";
            else return "Off";
        }

        public static bool ToBool(this string value)
        {
            if (value == "On") return true;
            else return false;
        }

        public static bool HasProperty<T>(this object obj, string propertyName)
        {
            var type = ((T)obj).GetType();
            return type.GetProperty(propertyName) != null;
        }

        public static string GetValue<T>(this object obj, string propertyName)
        {
            var type = ((T)obj).GetType();
            return type.GetProperty(propertyName).GetValue(obj).ToString();
        }

        public static bool BooleanValue(this XElement element)
        {
            if (element.Value.ToLower() == "on") return true;
            else return false;
        }

        public static int IntegerValue(this XElement element)
        {
            int result = 0;

            if (!int.TryParse(element.Value, out result)) result = -1;

            return result;
        }
    }
}
