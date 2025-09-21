using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Statements;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Evaluation;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Kaleidoscope.Logic.Complete.Simple.Outside
{
    public class OracleBeaver : BeaverBase, IYRLogicEvaluator
    {
        public override bool CompareContext(IYRContext premise, IYRContext conclusion)
        {
            List<IYRStatement> premiseStatements = new List<IYRStatement>();
            premiseStatements.Add(premise.Statement);
            while (premise != premise.Context)
            {
                premiseStatements.Add(premise.Statement);
                premise = premise.Context;
            }

            List<IYRStatement> conclusionStatements = new List<IYRStatement>();
            conclusionStatements.Add(conclusion.Statement);
            while (conclusion != conclusion.Context)
            {
                conclusionStatements.Add(conclusion.Statement);
                conclusion = conclusion.Context;
            }

            return conclusionStatements.All(x => premiseStatements.All(y => AskOracle(y, x)));
        }

        private bool AskOracle(IYRStatement y, IYRStatement x)
        {
            if(y == x)
                return true;

            if (y is Statement1 && x is Statement2)
                return true;

            return false;
        }
    }
}
