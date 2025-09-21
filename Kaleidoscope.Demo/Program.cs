using Kaleidoscope.Logic.Complete.Simple.Outside;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Contexts;
using Kaleidoscope.Logic.Core.Abstractions.Evaluation;


var simpleBeaver = new SimpleBeaver();
var oracleBeaver = new OracleBeaver();
List<IYRLogicEvaluator> beavers = [simpleBeaver, oracleBeaver];
foreach (var beaver in beavers)
{
    var beaverEvaluation = beaver.Evaluate(YRPureEqualityExactlyNElementsTheory.Instance, Context2.Instance);
    Console.WriteLine($"{beaver.GetType().Name} evaluation: {beaverEvaluation}");
}