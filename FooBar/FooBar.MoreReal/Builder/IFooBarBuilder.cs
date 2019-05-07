using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal.Builder
{
    public interface IFooBarBuilder
    {

        /// <summary>
        /// Will set range from 1 to 100;
        /// Add rule: print "Foo" for every third 
        /// Add rule: print "Bar" for every fifth 
        /// </summary>
        /// <returns></returns>
        IFooBarBuilder UseDefaults();

        /// <summary>
        /// Set range which starts with rangeFrom and ends on rangeTo. 
        /// For simplicity allowed range should be positive.
        /// </summary>
        /// <param name="rangeFrom">Can be positive, not zero</param>
        /// <param name="rangeTo">Can be positive, not zero</param>
        /// <returns></returns>
        IFooBarBuilder SetRange(int rangeFrom, int rangeTo);

        /// <summary>
        /// Adds rule: print <see cref="message"></see> for every <see cref="serialIndex"></see>
        /// </summary>
        /// <param name="serialIndex">Can be positive, not zero, and must be inside of Range</param>
        /// <param name="message">Can be empty, but not null</param>
        /// <returns></returns>
        IFooBarBuilder AddRule(int serialIndex, string message);
        IFooBar Build();

    }
}
