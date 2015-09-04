using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication4.Model
{
    class RuleOption
    {
        Dictionary<String, String> ruleMap;

        public RuleOption(String option)
        {
            ruleMap = new Dictionary<string, string>();

            String[] options = option.Split(new[] { ";" }, StringSplitOptions.None);

            foreach (String ruleOption in options)
            {
                int keyIndex = ruleOption.IndexOf(":");
                ruleMap.Add(
                    ruleOption.Substring(0, keyIndex).Trim(),
                    ruleOption.Substring(keyIndex).Trim());
            }
        }

    }
}
