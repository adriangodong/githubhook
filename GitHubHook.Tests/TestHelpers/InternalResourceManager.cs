using System;
using System.IO;
using System.Reflection;

namespace GitHubHook.Tests.TestHelpers
{
    internal class InternalResourceManager
    {

        internal readonly Assembly assembly;
        internal readonly string resourceNamespace;

        public InternalResourceManager(Type rootType)
        {
            assembly = rootType.Assembly;
            resourceNamespace = rootType.Namespace;
        }

        public string GetString(string name)
        {
            var resourceName = $"{resourceNamespace}.{name}";
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new ArgumentException($"{resourceName} is not found within the assembly.");
                }

                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }

        }
    }
}
