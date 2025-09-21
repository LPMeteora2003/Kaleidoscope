using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaleidoscope.Prompt.Scenarios
{
    public static class PromptInstructionsScenario
    {
        public static async Task<string> Generate()
        {
            List<string> paths =
            [
            ];
            List<string> exceptions =
            [
            ];
            List<string> resources =
            [

                @"Kaleidoscope.Prompt.EmbeddedResources.styleguide.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.namingconvention.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.abstractReasoning.prompt",
                @"Kaleidoscope.Prompt.EmbeddedResources.multithreaded.prompt",
            ];
            List<Func<FileInfo, bool>> filters =
            [
            ];

            return await PromptGenerator.Generate(paths, exceptions, filters, resources);
        }
    }
}
