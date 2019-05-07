using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal.Configuration
{
    public class Config
    {
        public Range Range { get; internal set; }
        public IEnumerable<Rule> Rules => RulesList;

        private List<Rule> RulesList { get; } = new List<Rule>();

        internal Config AddRule(Rule rule)
        {
            RulesList.Add(rule);
            return this;
        }
    }
}
