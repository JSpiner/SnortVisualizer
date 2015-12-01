using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.Model
{
    public class fw_Log
    {
        public String raw;
        public String Src_ip;
        public String Dest_ip;

        public fw_Log(String log)
        {
            this.raw = log;
            String[] lines = System.Text.RegularExpressions.Regex.Split(log, " ");

            foreach (string line in lines)
            {
                int i = 0;
                String[] sub_lines = System.Text.RegularExpressions.Regex.Split(line, "=");
                foreach (string sub_line in sub_lines)
                {
                    if (sub_line.Equals("SRC"))
                    {
                        this.Src_ip = sub_lines[i+1];
                    }
                    else if (sub_line.Equals("DST"))
                    {
                        this.Dest_ip = sub_lines[i + 1];
                    }
                    i++;
                }
            }
        }
    }
}
