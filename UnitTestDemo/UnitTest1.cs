using Main;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace UnitTestDemo
{
    [TestClass]
    public class UnitTest1
    {
        private ICustomerService _mockCustomerService;

        [TestInitialize]
        public void Init()
        {
            _mockCustomerService = Substitute.For<ICustomerService>();
        }

        [TestMethod]
        public void GetMemberLevel_WhenConsumptionAmountIs10000_ShouldReturn2()
        {
            // Arrange
            _mockCustomerService.GetConsumptionAmount(Arg.Any<string>()).Returns(10000);
            var memberCalculator = new MemberCalculator(_mockCustomerService);
            
            // Act
            var memberLevel = memberCalculator.GetMemberLevel("test");
            
            // Assert
            Assert.AreEqual(2, memberLevel);
        }

        [TestMethod]
        public void GetMemberLevel_WhenConsumptionAmountIs1000_ShouldReturn1()
        {
            // Arrange
            _mockCustomerService.GetConsumptionAmount(Arg.Any<string>()).Returns(1000);
            var memberCalculator = new MemberCalculator(_mockCustomerService);

            // Act
            var memberLevel = memberCalculator.GetMemberLevel("test");

            // Assert
            Assert.AreEqual(1, memberLevel);
        }
    }
}