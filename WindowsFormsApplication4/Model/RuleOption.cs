using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    public class RuleOption
    {
        public String raw;
        public Dictionary<String, String> ruleMap;

        public RuleOption(String option)
        {
            this.raw = option;
            parse(option);
        }

        private void parse(String option)
        {

            if (option.StartsWith("("))
            {
                parse(option.Substring(1, option.Length - 2).Trim());
                return;
            }
            ruleMap = new Dictionary<string, string>();

            String[] options = option.Split(new[] { ";" }, StringSplitOptions.None);

            foreach (String ruleOption in options)
            {
                int keyIndex = ruleOption.IndexOf(":");
                if (keyIndex == -1) continue;
                ruleMap.Add(
                    ruleOption.Substring(0, keyIndex).Trim(),
                    ruleOption.Substring(keyIndex + 1).Trim());
            }

        }
    }

}