using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Prompt.Scenarios
{
    public static class TheoremScenario
    {
        public static async Task<string> Generate()
        {
            List<string> paths =
            [
                @"C:\Users\Worker\source\repos\Kaleidoscope",
            ];
            List<string> exceptions =
            [
                @"C:\Users\Worker\source\repos\Kaleidoscope\Kaleidoscope.Math.*",
                @"C:\Users\Worker\source\repos\Kaleidoscope\Kaleidoscope.Prompt",
                @"C:\Users\Worker\source\repos\Kaleidoscope\Kaleidoscope.Core.Async.Abstractions",
                @"C:\Users\Worker\source\repos\Kaleidoscope\Kaleidoscope.Core.Async.MorseCode",
            ];
            List<string> resources =
            [

                @"Kaleidoscope.Prompt.EmbeddedResources.namingconvention.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.abstractReasoning.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.styleguide.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.multithreaded.prompt",
            ];
            List<Func<FileInfo, bool>> filters =
            [
                file =>
                {
                    var dir = file.DirectoryName ?? string.Empty;
                    var segments = dir.Split(new[] { Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar }, StringSplitOptions.RemoveEmptyEntries);
                    return !segments.Any(s => s.Equals("obj", StringComparison.OrdinalIgnoreCase) || s.Equals("bin", StringComparison.OrdinalIgnoreCase));
                },
                file => file.Extension.Equals(".cs", StringComparison.OrdinalIgnoreCase)
            ];

            return await PromptGenerator.Generate(paths, exceptions, filters, resources);
        }
    }
}
