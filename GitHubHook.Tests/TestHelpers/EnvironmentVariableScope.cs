using System;
using System.Collections.Generic;

namespace GitHubHook.Tests.TestHelpers
{
    internal class EnvironmentVariableScope : IDisposable
    {
        private readonly Dictionary<string, string> originalValues;

        public EnvironmentVariableScope(params string[] environmentVariableNames)
        {
            originalValues = new Dictionary<string, string>();
            foreach (var environmentVariableName in environmentVariableNames)
            {
                originalValues.Add(
                    environmentVariableName,
                    Environment.GetEnvironmentVariable(environmentVariableName));
            }
        }

        public void Dispose()
        {
            foreach (var kvp in originalValues)
            {
                Environment.SetEnvironmentVariable(kvp.Key, kvp.Value);
            }
        }
    }
}
