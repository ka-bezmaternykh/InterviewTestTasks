using FooBar.MoreReal.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal
{
    public class FooBar : IFooBar
    {
        internal FooBar(Config config)
        {
            Config = config;
        }

        public Config Config { get; }

        public IEnumerable<string> FooBars()
        {
            // May be cached for future use, 
            // but then it will take its place in memory. 
            // Let's leave simple for now.
            for (int i = Config.Range.From; i <= Config.Range.To; i++)
            {
                var msg = string.Empty;
                foreach (var rule in Config.Rules)
                {
                    if (i % rule.SerialIndex == 0)
                    {
                        // Note: StringBuilder could be used here, 
                        // but cases in which its allocation in memory would be justified, 
                        // will probably be rare.
                        msg += rule.Message;
                    }
                }

                if (string.IsNullOrEmpty(msg))
                {
                    msg = i.ToString();
                }
                yield return msg;
            }
        }

        public void ProcessEach(Action<string> action)
        {
            foreach (var message in FooBars())
            {
                action.Invoke(message);
            }
        }
    }
}
