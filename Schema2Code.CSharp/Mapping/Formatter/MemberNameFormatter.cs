using Schema2Code.Mapping.Formatter;

namespace Schema2Code.CSharp.Mapping.Formatter
{
    public class MemberNameFormatter : AbstractMemberNameFormatter
    {
        public override string Format(string value)
        {
            return value;
        }
    }
}
