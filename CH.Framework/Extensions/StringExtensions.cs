using System.Text.RegularExpressions;

namespace CH.Framework.Extensions;

public static class StringExtensions
{
    public static string CleanCacheKey(this string uri) =>
        Regex.Replace((new Regex("[\\~#%&*{}/:<>?|\"-]")).Replace(uri, " "), @"\s+", "_");

    public static string FormattedNumber(this string number) =>
        Convert.ToDouble(number).FormattedNumber();
    public static string RemoveGuidFromEmail(this string input)
    {
        int length = input.LastIndexOf('_');
        if (length > 0)
        {
            string guid = input.Substring(length + 1);
            if (guid.Length == 36)
            {
                input = input.Substring(0, length);
            }
        }
        return input;
    }

    public static bool IsValidEmail(this string email)
    {
        var trimmedEmail = email.Trim();

        if (trimmedEmail.EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == trimmedEmail;
        }
        catch
        {
            return false;
        }
    }


    public static Dictionary<string, string> GetParams(string uri)
    {
        var matches = Regex.Matches(uri, @"[\?&](([^&=]+)=([^&=#]*))", RegexOptions.Compiled);
        return matches.Cast<Match>().ToDictionary(
            m => Uri.UnescapeDataString(m.Groups[2].Value),
            m => Uri.UnescapeDataString(m.Groups[3].Value)
        );
    }
}

