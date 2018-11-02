namespace dotnet_webapp
{
    public static class IntegerExtensions
    {
        public static string ToOrdinal(this int val)
        {
            var suffix = "th";
            var str = val.ToString();

            if (!str.EndsWith("11") && !str.EndsWith("12") && !str.EndsWith("13"))
            {
                switch (str.Substring(str.Length - 1, 1))
                {
                    case "1":
                        suffix = "st";
                        break;
                    case "2":
                        suffix = "nd";
                        break;
                    case "3":
                        suffix = "rd";
                        break;
                }
            }

            return $"{str}{suffix}";
        }
    }
}
