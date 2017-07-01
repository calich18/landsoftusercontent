using System;

namespace Landsoft.UserContent.Helpers
{
    public class Common
    {
        public static long Now()
        {
            return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
        }
    }
}