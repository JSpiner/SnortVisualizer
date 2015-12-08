using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    public class FLogModel
    {

        public DateTime time;
        public String msg;
        public String IN;
        public String OUT;

        private readonly String[] monthString = { "jan", "feb", "mar", "apr", "may", "jun", "jul", "aug", "sep", "oct", "nov", "dec" };

        public FLogModel(String str)
        {
//            String str = "Nov  7 11:36:36 OpenWrt [19923.310000] udp_flooding : IN=br-lan OUT= MAC=4c:5e:0c:39:42:63:24:b6:fd:13:b9:a2:08:00 SR";
            String[] strs = str.Split(new[] { " " }, StringSplitOptions.None);
            String[] times = strs[3].Split(new[] { ":" }, StringSplitOptions.None);
            time = new DateTime(2015,
                parseMonth(strs[0]),
                Convert.ToInt32(strs[2]),
                Convert.ToInt32(times[0]),
                Convert.ToInt32(times[1]),
                Convert.ToInt32(times[2]));

            msg = strs[6];

            int startIndex = str.IndexOf("IN=");
            int endIndex = str.IndexOf("OUT=", startIndex);
            IN = str.Substring(startIndex + 3, endIndex - startIndex);
            OUT = str.Substring(endIndex + 3);



        }

        private int parseMonth(String str)
        {
            int i = 0;
            foreach (String month in monthString)
            {

                i++;
                if (str.ToLower().Equals(month))
                {
                    return i;
                }
            }
            return 0;
        }

        /*
        private int parseMonth(String str){
            switch (str.ToLower()) {
            case "jan":
                return 0;
                break;
            case "feb":
                return 1;
                break;
            case "mar":
                return 2;
                break;
            case "apr":
                return 3;
                break;
            case "may":
                return 4;
                break;
            case "jun":
                return 5;
                break;
            case "jul":
                return 6;
                break;
            case "aug":
                return 7;
                break;
            case "sep":
                return 8;
                break;
            case "oct":
                return 9;
                break;
            case "nov":
                return 10;
                break;
            case "dec":
                return 11;
                break;
            }
            return 0;
        }*/
    }
}
