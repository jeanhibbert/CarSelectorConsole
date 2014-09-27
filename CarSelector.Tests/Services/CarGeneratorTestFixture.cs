namespace CarSelector.Tests.Services
{
    using CarSelector.Tests.Utils;

    using Microsoft.VisualStudio.TestTools.UnitTesting;


    using CarSelector.Model;

    [TestClass]
    public class CarGeneratorTestFixture
    {
        [TestMethod]
        public void CanGenerateCarConfigurations()
        {
            CarGenerator carGenerator = new CarGenerator();
            CarConfiguration[] carConfigurations = carGenerator.GenerateCarConfigurations(10000);

            Assert.AreEqual(carConfigurations.Length, 10000);
        }
    }
}
