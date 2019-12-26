using GitHubHook.Tests.TestPayloads;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SilverGiggle;
using System.Reflection;

namespace GitHubHook.Tests.Events
{
    public abstract class BaseEventTests
    {
        internal InternalResourceManager resourceManager;

        [TestInitialize]
        public void Init()
        {
            resourceManager = new InternalResourceManager(typeof(TestPayloadsMarker).GetTypeInfo());
        }
    }
}
