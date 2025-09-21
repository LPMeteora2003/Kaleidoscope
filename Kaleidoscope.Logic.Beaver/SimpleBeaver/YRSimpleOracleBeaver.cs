using Kaleidoscope.Logic.Beaver.Abstractions.Oracle;
using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Evaluation;
using Kaleidoscope.Logic.Core.Abstractions.Statement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Beaver.SimpleBeaver
{
    public class YRSimpleOracleBeaver : YRSimpleBeaverBase, IYRLogicEvaluator
    {
        private readonly IYREqualityBeaverOracle _beaverOracle;

        public YRSimpleOracleBeaver(IYREqualityBeaverOracle beaverOracle)
        {
            _beaverOracle = beaverOracle;
        }
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
            var result = _beaverOracle.Forsee(y, x).GetAwaiter().GetResult();
            return result;
        }
    }
}
