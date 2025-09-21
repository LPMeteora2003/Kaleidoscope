using Kaleidoscope.Core.Abstractions;
using Kaleidoscope.Logic.Core.Abstractions.Predicat.FixedArity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Logic.Core.Abstractions
{
    /// <summary>
    /// Verdicts are definite "Meta" results of Logical Constructs and their Statements
    /// To encode multiple Verdicts, we use the recursion, as the number of verdicts isn't bound by anything
    /// Any Logical Construct has a Judicator, that maps a Context (a finite or infinite number of statements via recursion) to a final verdict
    /// The Logical Construct's final Verdict is it's top verdict, meaning the verdict it obeys to and fullfills
    /// Example for an incomplete Logic and its Verdicts: TrueVerdict, FalseVerdict, UnprovableVerdict, ...
    /// </summary>
    public interface IYRVerdict : IYRSingleton
    {
        IYRVerdict Verdict { get; }
    }
}
