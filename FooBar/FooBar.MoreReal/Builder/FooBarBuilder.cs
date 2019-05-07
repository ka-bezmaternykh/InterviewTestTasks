using FooBar.MoreReal.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal.Builder
{
    public class FooBarBuilder : IFooBarBuilder
    {
        /// <summary>
        /// Will set range from 1 to 100;
        /// Add rule: print "Foo" for every third 
        /// Add rule: print "Bar" for every fifth 
        /// </summary>
        /// <returns></returns>
        public IFooBarBuilder UseDefaults()
        {
            return SetRange(1, 100)
                .AddRule(3, "Foo")
                .AddRule(5, "Bar");
        }

        public Config Config { get; } = new Config();

        /// <summary>
        /// Adds rule: print <see cref="message"></see> for every <see cref="serialIndex"></see>
        /// 
        /// Note: no support for rule uniqueness
        /// </summary>
        /// <param name="serialIndex">Can be positive, not zero, and must be inside of Range</param>
        /// <param name="message">Can be empty, but not null</param>
        /// <returns></returns>
        public IFooBarBuilder AddRule(int serialIndex, string message)
        {
            var rule = new Rule(serialIndex, message);
            Config.AddRule(rule);
            return this;
        }

        /// <summary>
        /// Set range which starts with rangeFrom and ends on rangeTo. 
        /// For simplicity allowed range should be positive.
        /// </summary>
        /// <param name="rangeFrom">Can be positive, not zero</param>
        /// <param name="rangeTo">Can be positive, not zero</param>
        /// <returns></returns>
        public IFooBarBuilder SetRange(int rangeFrom, int rangeTo)
        {
            Config.Range = new Range(rangeFrom, rangeTo);
            return this;
        }

        /// <summary>
        /// Makes an instance of <see cref="IFooBar"></see>.
        /// Сhecks that range from/to are set and rules are inside of range.
        /// </summary>
        /// <returns></returns>
        public IFooBar Build()
        {
            // good enough check cause default range is {0,0}, 
            // which is not allowed and for now is the marker, what Range was not set
            if (default(Range).Equals(Config.Range))
                throw new InvalidOperationException("Cannot create FooBar, because Range was not set.");

            // Check rules are inside of range
            if (Config.Rules.Any())
            {
                foreach (var rule in Config.Rules)
                {
                    if (Config.Range.From > rule.SerialIndex
                        || Config.Range.To < rule.SerialIndex)
                    {
                        var msg = $"Cannot create FooBar, because {rule.SerialIndex} in rule is out of range.";
                        throw new ArgumentOutOfRangeException(msg);
                    }
                }
            }

            return new FooBar(Config);
        }
    }
}
