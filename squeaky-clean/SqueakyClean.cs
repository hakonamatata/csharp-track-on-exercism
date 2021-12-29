using System;
using System.Text;
using System.Text.RegularExpressions;

public static class Identifier
{
    public static string Clean(string identifier) => identifier
        .ReplaceSpaceWithUnderscore()
        .ReplaceCtrl()
        .ConvertToCamelCase()
        .RemoveNumbers()
        .RemoveEmojis()
        .OmitGreekLowercaseLetters();

    private static string ReplaceSpaceWithUnderscore(this string identifier) => identifier.Replace(' ', '_');

    private static string ReplaceCtrl(this string identifier) => identifier.Replace("\0", "CTRL");

    private static string ConvertToCamelCase(this string identifier)
    {
        var sb = new StringBuilder();
        for (int i = 0; i < identifier.Length; i++)
        {
            if (identifier[i] == '-')
            {
                if (i + 1 < identifier.Length)
                {
                    sb.Append(char.ToUpper(identifier[i + 1]));
                    i++;
                }
            }
            else
            {
                sb.Append(identifier[i]);
            }
        }

        return sb.ToString();
    }

    private static string RemoveNumbers(this string identifier) => Regex.Replace(identifier, @"\d", "");

    private static string RemoveEmojis(this string identifier) => Regex.Replace(identifier, @"\p{Cs}", "");

    private static string OmitGreekLowercaseLetters(this string identifier) =>
        Regex.Replace(identifier, @"[\u03B1-\u03C9]", string.Empty);
}
