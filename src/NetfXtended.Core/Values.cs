using System.Globalization;

namespace NetfXtended.Core
{
    public static class Values
    {
        public static int? ParseHexS(string text)
        {
            if (Strings.IsNullOrWhiteSpace(text))
                return null;
            return int.Parse(text, NumberStyles.HexNumber);
        }

        public static uint? ParseHexU(string text)
        {
            if (Strings.IsNullOrWhiteSpace(text))
                return null;
            return uint.Parse(text, NumberStyles.HexNumber);
        }
    }
}