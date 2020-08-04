using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsportManager
{
    public class GlobalMethodes
    {
        public static int[] ParseDate(string date)
        {
            int[] parsed = new int[3];
            parsed[0] = int.Parse(date.Substring(0, 4));
            parsed[1] = int.Parse(date.Substring(5, 2));
            parsed[2] = int.Parse(date.Substring(8, 2));
            return parsed;
        }

        public static int CountAge(int[] smaller, int[] bigger)
        {
            DateTime small = new DateTime(smaller[0], smaller[1], smaller[2]);
            DateTime big = new DateTime(bigger[0], bigger[1], bigger[2]);
            int i = 0;
            while (big > small)
            {
                small = small.AddYears(1);
                i++;
            }
            return i;
        }

        public static string FormatDate(int[] date)
        {
            return date[2] + ". " + date[1] + ". " + date[0];
        }
    }
}
