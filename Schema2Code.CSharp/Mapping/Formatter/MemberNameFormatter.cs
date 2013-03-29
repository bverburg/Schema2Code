using Schema2Code.Mapping.Formatter;

namespace Schema2Code.CSharp.Mapping.Formatter
{
    public class MemberNameFormatter : AbstractMemberNameFormatter
    {
        protected override string FormatValueCore(string value)
        {
            return value;
        }
    }
}
