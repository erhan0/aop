namespace SheepAspect.Helpers
{
    public static class StringExtensions
    {
        public static bool IsWildcardMatch(this string text, string wildcard, bool caseSensitive = true)
        {
            var sb = new System.Text.StringBuilder(wildcard.Length + 10);
            sb.Append("^");
            for (int i = 0; i < wildcard.Length; i++)
            {
	        char c = wildcard[i];
	        switch(c)
	        {
	            case '*':
		        sb.Append(".*");
		        break;
	            default:
		        sb.Append(System.Text.RegularExpressions.Regex.Escape(wildcard[i].ToString()));
		        break;
	        }
            }
            sb.Append("$");

            System.Text.RegularExpressions.Regex regex;
            if (caseSensitive)
	        regex = new System.Text.RegularExpressions.Regex(sb.ToString(), System.Text.RegularExpressions.RegexOptions.None);
            else
	        regex = new System.Text.RegularExpressions.Regex(sb.ToString(), System.Text.RegularExpressions.RegexOptions.IgnoreCase);

            return regex.IsMatch(text);
        }

        public static string FormatWith(this string pattern, params object[] args)
        {
            return string.Format(pattern, args);
        }
    }
}