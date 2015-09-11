using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    public class RuleModel
    {
        public String raw;
        public RuleHeader ruleHeader;
        public RuleOption ruleOption;

        public static RuleModel parse(String rule)
        {
            RuleModel ruleModel = new RuleModel();
            ruleModel.raw = rule;

            int headerIndex = rule.IndexOf("(");

            if (headerIndex == -1)
            {
                throw new Exception("not correct argument");
            }

            String strHeader = rule.Substring(0, headerIndex);
            String strOption = rule.Substring(headerIndex);

            ruleModel.ruleHeader = new RuleHeader(strHeader.Trim());
            ruleModel.ruleOption = new RuleOption(strOption.Trim());

            return ruleModel;
        }
    }
}
