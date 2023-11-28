namespace PMSystem.Client.Common
{
    public static class StringExtension
    {
        public static string ToShort(this string title)
        {
            if (title.Length > 10)
            {
                title = title.Substring(0, 10);
            }
            title = title += "···";
            return title;
        }
    }
}
