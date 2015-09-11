using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    public class LogModel
    {
        public String raw;
        public LogHeader logHeader;
        public LogBody logBody;

        public static LogModel parse(String log)
        {
            LogModel logModel = new LogModel();
            logModel.raw = log;

            String[] lines = log.Split(new[] { "\n" }, StringSplitOptions.None);

            StringBuilder headBuilder = new StringBuilder();
            StringBuilder bodyBuilder = new StringBuilder();

            foreach (String line in lines)
            {
                if (line.Trim().StartsWith("["))
                {
                    headBuilder.Append(line);
                }
                else
                {
                    bodyBuilder.Append(line);

                }
            }

            logModel.logHeader =
                new LogHeader(headBuilder.ToString());
            logModel.logBody =
                new LogBody(bodyBuilder.ToString());

            return logModel;
        }

    }
}
