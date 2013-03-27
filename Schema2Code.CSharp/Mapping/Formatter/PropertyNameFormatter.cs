using Schema2Code.Mapping.Formatter;

namespace Schema2Code.CSharp.Mapping.Formatter
{
    public class PropertyNameFormatter : AbstractPropertyNameFormatter
    {
        protected override string FormatValueCore(string value)
        {
            return value;
        }
    }
}
