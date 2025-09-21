using Kaleidoscope.Logic.Beaver.Abstractions;
using Kaleidoscope.Logic.Beaver.Oracle;
using Kaleidoscope.Logic.Beaver.SimpleBeaver;
using Kaleidoscope.Logic.Complete.Simple.Magic;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements;
using Kaleidoscope.Logic.Complete.Simple.PureEqualityExactlyNElements.Contexts;
using Kaleidoscope.Logic.Core.Abstractions.Evaluation;

var beaverMagic = new YRPureEqualityExactlyNElementsBeaverOracleMagic();

var simpleBeaver = new YRSimpleBeaver();
var oracleBeaver = new YRSimpleOracleBeaver(new YRSimpleEqualityBeaverOracle(beaverMagic));
List<IYRLogicEvaluator> beavers = [simpleBeaver, oracleBeaver];
foreach (var beaver in beavers)
{
    var beaverEvaluation = beaver.Evaluate(YRPureEqualityExactlyNElementsTheory.Instance, Context2.Instance);
    Console.WriteLine($"{beaver.GetType().Name} evaluation: {beaverEvaluation}");
}