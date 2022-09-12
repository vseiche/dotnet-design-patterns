using DesignPatterns.Tests.Singleton.Implementations;

namespace DesignPatterns.Tests.Singleton
{
    [TestClass]
    public class SingletonTests
    {
        [TestMethod]
        public void ThreadSafeSingleton_TwoInstanceInvoke_InstancesAreEqual()
        {
            var instance1 = ThreadSafeSingletonImplementation.Instance;
            var instance2 = ThreadSafeSingletonImplementation.Instance;

            Assert.AreEqual(instance1, instance2);
        }
        
        [TestMethod]
        public void LazySingleton_TwoInstanceInvoke_InstancesAreEqual()
        {
            var instance1 = LazySingletonImplementation.Instance;
            var instance2 = LazySingletonImplementation.Instance;

            Assert.AreEqual(instance1, instance2);
        }
    }
}
