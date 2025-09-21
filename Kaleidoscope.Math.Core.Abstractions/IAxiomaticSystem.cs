using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Core.Abstractions
{
    public interface IAxiomaticSystem
    {
        public List<IYRAxiom> ExistanceAxioms { get; }
    }
}
