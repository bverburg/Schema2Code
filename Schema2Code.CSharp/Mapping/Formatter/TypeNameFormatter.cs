using Schema2Code.Mapping.Formatter;

namespace Schema2Code.CSharp.Mapping.Formatter
{
    public class TypeNameFormatter : AbstractTypeNameFormatter
    {
        protected override string FormatValueCore(string value)
        {
            return value.Substring(0, 1).ToUpper() + value.Substring(1, value.Length - 1);
        }
    }
}
