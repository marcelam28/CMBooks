using System.Linq;

namespace Deventure.BusinessLogic.Extensions
{
    public static class StringExtensions
    {
        public static string InvertCases(this string text)
        {
            if (text == null)
            {
                return null;
            }
            return new string(text.Reverse().ToArray());
        }
    }
}
