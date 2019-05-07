using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal.Configuration
{
    public struct Range
    {
        internal Range(int rangeFrom, int rangeTo)
        {
            if (rangeFrom < 1)
                throw new ArgumentException($"{rangeFrom} must be positive, non zero", nameof(rangeFrom));

            if (rangeTo < 1)
                throw new ArgumentException($"{rangeTo} must be positive, non zero", nameof(rangeTo));

            if (rangeFrom > rangeTo)
                throw new ArgumentException($"{rangeFrom} must be less then {rangeTo}");

            From = rangeFrom;
            To = rangeTo;
        }

        public int From { get; internal set; }
        public int To { get; internal set; }
    }
}
