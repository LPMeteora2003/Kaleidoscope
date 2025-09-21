using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kaleidoscope.Prompt
{
    public static class PromptGenerator
    {
        public static async Task<string> Generate(
            List<string> paths,
            List<string> exceptions,
            List<Func<FileInfo, bool>> mandatoryFilters,
            List<string> embeddedResources)
        {
            paths ??= new List<string>();
            exceptions ??= new List<string>();
            mandatoryFilters ??= new List<Func<FileInfo, bool>>();
            embeddedResources ??= new List<string>();

            var uniqueFilePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var directoryStack = new Stack<string>();

            var fileExceptionSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var directoryExceptionPrefixes = new List<string>();
            var wildcardExceptionPatterns = new List<Regex>();

            static string NormalizeSeparators(string value) => value.Replace('\\', '/');

            static Regex CreateWildcardRegex(string wildcardPath)
            {
                var normalized = NormalizeSeparators(wildcardPath);
                var escaped = Regex.Escape(normalized).Replace(@"\*", ".*").Replace(@"\?", ".");
                return new Regex("^" + escaped, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
            }

            foreach (var exceptionPath in exceptions.Where(x => !string.IsNullOrWhiteSpace(x)))
            {
                var containsWildcards = exceptionPath.IndexOfAny(new[] { '*', '?' }) >= 0;
                if (containsWildcards)
                {
                    try { wildcardExceptionPatterns.Add(CreateWildcardRegex(exceptionPath)); } catch { }
                    continue;
                }

                try
                {
                    var fullExceptionPath = Path.GetFullPath(exceptionPath);
                    if (Directory.Exists(fullExceptionPath))
                    {
                        var prefix = fullExceptionPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ? fullExceptionPath : fullExceptionPath + Path.DirectorySeparatorChar;
                        directoryExceptionPrefixes.Add(prefix);
                    }
                    else if (File.Exists(fullExceptionPath))
                    {
                        fileExceptionSet.Add(fullExceptionPath);
                    }
                    else
                    {
                        var prefix = fullExceptionPath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ? fullExceptionPath : fullExceptionPath + Path.DirectorySeparatorChar;
                        directoryExceptionPrefixes.Add(prefix);
                    }
                }
                catch { }
            }

            bool IsExcluded(string absoluteFilePath)
            {
                if (fileExceptionSet.Contains(absoluteFilePath)) return true;
                foreach (var prefix in directoryExceptionPrefixes)
                    if (absoluteFilePath.StartsWith(prefix, StringComparison.OrdinalIgnoreCase)) return true;
                var normalized = NormalizeSeparators(absoluteFilePath);
                foreach (var pattern in wildcardExceptionPatterns)
                    if (pattern.IsMatch(normalized)) return true;
                return false;
            }

            foreach (var candidatePath in paths)
            {
                if (string.IsNullOrWhiteSpace(candidatePath)) continue;
                try
                {
                    if (File.Exists(candidatePath))
                    {
                        var full = Path.GetFullPath(candidatePath);
                        if (!IsExcluded(full)) uniqueFilePaths.Add(full);
                        continue;
                    }
                    if (Directory.Exists(candidatePath))
                    {
                        var rootFull = Path.GetFullPath(candidatePath);
                        var rootPrefix = rootFull.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ? rootFull : rootFull + Path.DirectorySeparatorChar;
                        var rootPrefixNormalized = NormalizeSeparators(rootPrefix);
                        if (directoryExceptionPrefixes.Any(p => rootPrefix.StartsWith(p, StringComparison.OrdinalIgnoreCase))) continue;
                        if (wildcardExceptionPatterns.Any(r => r.IsMatch(rootPrefixNormalized))) continue;

                        directoryStack.Push(candidatePath);
                        while (directoryStack.Count > 0)
                        {
                            var directoryToProcess = directoryStack.Pop();

                            string[] filesInDirectory = Array.Empty<string>();
                            try { filesInDirectory = Directory.GetFiles(directoryToProcess); } catch { }
                            foreach (var fileInDirectory in filesInDirectory)
                            {
                                try
                                {
                                    var full = Path.GetFullPath(fileInDirectory);
                                    if (!IsExcluded(full)) uniqueFilePaths.Add(full);
                                }
                                catch { }
                            }

                            string[] subdirectoryList = Array.Empty<string>();
                            try { subdirectoryList = Directory.GetDirectories(directoryToProcess); } catch { }
                            foreach (var subdirectory in subdirectoryList)
                            {
                                try
                                {
                                    var subFull = Path.GetFullPath(subdirectory);
                                    var subPrefix = subFull.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal) ? subFull : subFull + Path.DirectorySeparatorChar;
                                    var subPrefixNormalized = NormalizeSeparators(subPrefix);
                                    if (directoryExceptionPrefixes.Any(p => subPrefix.StartsWith(p, StringComparison.OrdinalIgnoreCase))) continue;
                                    if (wildcardExceptionPatterns.Any(r => r.IsMatch(subPrefixNormalized))) continue;
                                    directoryStack.Push(subdirectory);
                                }
                                catch { }
                            }
                        }
                    }
                }
                catch { }
            }

            bool PassesMandatoryFilters(FileInfo fileInformation)
            {
                foreach (var filter in mandatoryFilters)
                {
                    try { if (filter != null && !filter(fileInformation)) return false; } catch { return false; }
                }
                return true;
            }

            var outputBuilder = new StringBuilder();

            outputBuilder.AppendLine($"Have a look at my current code: ");

            foreach (var filePath in uniqueFilePaths.OrderBy(p => p, StringComparer.OrdinalIgnoreCase))
            {
                FileInfo fileInformation;
                try { fileInformation = new FileInfo(filePath); } catch { continue; }
                if (!fileInformation.Exists) continue;
                if (!PassesMandatoryFilters(fileInformation)) continue;
                string fileText;
                try
                {
                    using var reader = new StreamReader(filePath, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
                    fileText = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
                catch { continue; }
                outputBuilder.AppendLine($"=== START FILE: {filePath} ===");
                outputBuilder.AppendLine(fileText);
                outputBuilder.AppendLine($"=== END FILE: {filePath} ===");
            }

            var assembly = typeof(PromptGenerator).Assembly;
            var availableResourceNames = assembly.GetManifestResourceNames();

            outputBuilder.AppendLine($"Please follow these requirements and instructions when writing code: ");
            foreach (var embeddedResourceIdentifier in embeddedResources)
            {
                if (string.IsNullOrWhiteSpace(embeddedResourceIdentifier)) continue;
                var matchedResourceName = availableResourceNames
                    .FirstOrDefault(n => string.Equals(n, embeddedResourceIdentifier, StringComparison.Ordinal)
                                         || n.EndsWith("." + embeddedResourceIdentifier, StringComparison.OrdinalIgnoreCase)
                                         || n.EndsWith("/" + embeddedResourceIdentifier, StringComparison.OrdinalIgnoreCase));
                if (matchedResourceName == null) continue;
                using var resourceStream = assembly.GetManifestResourceStream(matchedResourceName);
                if (resourceStream == null) continue;
                string resourceText;
                try
                {
                    using var reader = new StreamReader(resourceStream, Encoding.UTF8, detectEncodingFromByteOrderMarks: true);
                    resourceText = await reader.ReadToEndAsync().ConfigureAwait(false);
                }
                catch { continue; }
                outputBuilder.AppendLine(resourceText);
            }

            return outputBuilder.ToString();
        }
    }
}
