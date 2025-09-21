using Kaleidoscope.Math.Core.Axiom;
using Kaleidoscope.Math.Set;
using Kaleidoscope.Math.Set.Standard.Abstractions.Integers;
using Kaleidoscope.Math.Set.Standard.AbstractionsNaturalNumbers;
using Kaleidoscope.Math.Set.Standard.Integers;
using Kaleidoscope.Math.Set.Standard.Integers.Kuratowski;
using Kaleidoscope.Math.Set.Standard.NaturalNumbers;
using Kaleidoscope.Math.Set.Standard.Naturals.VonNeumann;
using Kaleidoscope.Math.Set.Standard.Rationals;
using System.Numerics;

var naturalFactories = new IYRNaturalNumberFactory[]
{
    new YRVonNeumannOrdinalFactory(),
};
var integerFactories = new IYRIntegerNumberFactory[]
{
    new YRKuratowskiIntegerNumberFactory(naturalFactories[0]),
};


var axiomaticSystem = new ZFAxiomaticSystem([new YREmptyAxiomSet(), new YRVonNeumannInfiniteAxiomSet()]);
YRSet.AxiomaticSystem = axiomaticSystem;

foreach(var factory in integerFactories)
{
    var naturalNumbers = new YRRationalNumberSet(factory, naturalFactories[0]);
    int emitted = 0;
    await foreach (var n in naturalNumbers.Enumerate())
    {
        Console.WriteLine(n);
        if (++emitted >= 999) 
            break;
    }
}