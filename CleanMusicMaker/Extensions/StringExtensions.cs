namespace CleanMusicMaker.Extensions
{
    public static class StringExtensions
    {
        public static string GetSubString(this string str, int start, int end)
        {
            return str[start..end];
        }
    }
}
