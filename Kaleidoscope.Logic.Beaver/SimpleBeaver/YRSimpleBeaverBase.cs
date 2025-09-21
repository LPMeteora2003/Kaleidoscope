using Kaleidoscope.Logic.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Evaluation;

namespace Kaleidoscope.Logic.Beaver.SimpleBeaver
{
    public abstract class YRSimpleBeaverBase : IYRLogicEvaluator
    {
        public object Evaluate(IYRLogicConstruct logicConstruct, IYRContext conclusion)
        {
            if (ViolatingJudgement(logicConstruct, conclusion))
                return false;

            if (ComfirmingJudgement(logicConstruct, conclusion))
                return true;

            return null;
        }
        private bool ComfirmingJudgement(IYRLogicConstruct logicConstruct, IYRContext conclusion)
        {
            var judgement = logicConstruct.Judgement;

            if (CompareContext(judgement.Premise, conclusion) && logicConstruct.Verdict == judgement.Verdict)
                return true;

            while (judgement != judgement.Judgement)
            {
                var premise = judgement.Premise;
                var comparisonResult = CompareContext(premise, conclusion);

                if (comparisonResult && logicConstruct.Verdict == judgement.Verdict)
                    return true;
                judgement = judgement.Judgement;
            }

            return false;
        }

        private bool ViolatingJudgement(IYRLogicConstruct logicConstruct, IYRContext conclusion)
        {
            var judgement = logicConstruct.Judgement;

            if (!(CompareContext(judgement.Premise, conclusion) ^ logicConstruct.Verdict != judgement.Verdict))
                return true;

            while (judgement != judgement.Judgement)
            {
                var premise = judgement.Premise;
                var comparisonResult = CompareContext(premise, conclusion);

                if (!(comparisonResult ^ logicConstruct.Verdict != judgement.Verdict))
                    return true;
                judgement = judgement.Judgement;
            }

            return false;
        }


        public abstract bool CompareContext(IYRContext premise, IYRContext conclusion);
    }
}