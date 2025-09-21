using Kaleidoscope.Core.Async.Abstractions;
using Kaleidoscope.Math.Core.Abstractions;
using Kaleidoscope.Math.Set.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Math.Core.Axiom
{
    public class ZFAxiomaticSystem : IAxiomaticSystem
    {
        IEnumerable<IYRAxiom> _existanceAxioms;
        public ZFAxiomaticSystem(IEnumerable<IYRAxiom> existanceAxioms)
        {
            _existanceAxioms = existanceAxioms;
        }

        public List<IYRAxiom> ExistanceAxioms => _existanceAxioms.ToList();
    }
}
