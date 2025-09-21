using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Kaleidoscope.Prompt.Scenarios;
using System.Diagnostics;

var outputFilePath = @"C:\Users\Worker\source\repos\Kaleidoscope\Kaleidoscope.Prompt\Prompt.txt";
var result = await TheoremScenario.Generate();

Console.WriteLine(result);
File.WriteAllText(outputFilePath, result);
var startInfo = new ProcessStartInfo("clip")
{
    RedirectStandardInput = true,
    UseShellExecute = false
};
using var clip = Process.Start(startInfo);
if (clip != null)
{
    await clip.StandardInput.WriteAsync(result).ConfigureAwait(false);
    clip.StandardInput.Close();
    clip.WaitForExit();
}