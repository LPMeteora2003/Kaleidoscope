using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions.Evaluation
{
    public interface IYRLogicEvaluator
    {
        public object Evaluate(IYRLogicConstruct logicConstruct, IYRContext conclusion);

    }
}
