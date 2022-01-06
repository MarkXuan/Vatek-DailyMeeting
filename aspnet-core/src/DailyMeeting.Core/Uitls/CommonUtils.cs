using System;
using System.Collections.Generic;
using System.Text;

namespace DailyMeeting.Uitls
{
    public class CommonUtils
    {
        public static string GenerateRandomPassword(byte length)
        {
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);

        }

        public static string AddMoreHourToHHmm(string HHmm, double hour)
        {
            if (HHmm.Contains(":"))
            {
                var t = HHmm.Split(':');
                double minute = double.Parse(t[0]) * 60 + double.Parse(t[1]) + hour * 60;

                return (int) (minute / 60) + ":" + minute % 60;

            }
            return HHmm;

        }

        public static double SubtractHHmm(string HHmm1, string HHmm2)
        {
            if (string.IsNullOrEmpty(HHmm1) || string.IsNullOrEmpty(HHmm2))
                return 0;
            if( HHmm1.Contains(":") &&  HHmm2.Contains(":"))
            {
                var t1 = HHmm1.Split(':');
                var t2 = HHmm2.Split(':');
                return double.Parse(t1[0]) * 60 + double.Parse(t1[1]) - (double.Parse(t2[0]) * 60 + double.Parse(t2[1]));
            }
            return 0;
        }

        public string ConvertHourToHHmm(double hour)
        {
            return TimeSpan.FromHours(hour).ToString(@"hh\:mm");
        }

    }
}
