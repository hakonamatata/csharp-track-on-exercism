using System;
using System.Text.RegularExpressions;

public static class Bob
{
    public static string Response(string statement) =>
        statement switch
        {
            string s when isSilence(s) => "Fine. Be that way!",
            string s when isShouting(s) && isQuestion(s) => "Calm down, I know what I'm doing!",
            string s when isShouting(s) => "Whoa, chill out!",
            string s when isQuestion(s) => "Sure.",
            _ => "Whatever.",
        };


    private static bool isSilence(string s) => s.Trim().Length == 0;
    private static bool isQuestion(string s) => filterOutRelevantCharacters(s).Trim().EndsWith("?");
    private static bool isShouting(string s) =>
        filterOutNonLetters(s).Length != 0 &&
        filterOutRelevantCharacters(s).Trim().ToUpper() == filterOutRelevantCharacters(s).Trim();

    private static string filterOutRelevantCharacters(string s) => Regex.Replace(s, @"[^a-zA-Z?!]", "");
    private static string filterOutNonLetters(string s) => Regex.Replace(s, @"[^a-zA-Z]", "");
}