using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CarSelector.Tests.Services
{
    using CarSelector.Tests.Utils;

    [TestClass]
    public class SimpleRNGTestFixture
    {
        [TestMethod]
        public void CanGenerateRandomNumber()
        {
            SimpleRNG.SetSeedFromSystemTime();
            double randomValue1 = SimpleRNG.GetUniform();

            SimpleRNG.SetSeedFromSystemTime();
            double randomValue2 = SimpleRNG.GetUniform();

            Assert.AreNotEqual(randomValue1, randomValue2);
        }
    }
}
