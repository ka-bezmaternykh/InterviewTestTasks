using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FooBar.MoreReal
{
    public interface IFooBar
    {
        IEnumerable<string> FooBars();
        void ProcessEach(Action<string> action);
    }
}
