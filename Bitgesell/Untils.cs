using System;
namespace Bitgesell
{
    public static class Untils
    {
        public static DateTime ConvertDate(long num)
        {
            long unixDate = num;
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return origin.AddSeconds(num);
        }
    }
}
