using System;
using Xunit;
using xUnit_test;
using Moq;

namespace xUnitTestProject
{
    public class UnitTest1
    {
        PrimeService primeService = new(new Mocking());
        
        IMock mock1;
        
        private void SetupMocks()
        {
            var mock = new Mock<IMock>();
            mock.Setup(foo => foo.True(1)).Returns(true);
            mock.Setup(foo => foo.True(0)).Returns(false);

            mock1 = mock.Object;
        }

        [Fact]
        public void Test1()
        {
            Assert.False(primeService.True(0));
        }

        [Fact]
        public void Test2()
        {
            SetupMocks();
            primeService = new PrimeService(mock1);
            Assert.True(primeService.True(1));
        }

        [Fact]
        public void Test3()
        {
            SetupMocks();
            primeService = new PrimeService(mock1);
            Assert.False(primeService.True(0));
        }

        [Fact]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            bool result = primeService.IsPrime(1);

            Assert.False(result, "1 should not be prime");
        }

        private readonly PrimeService _primeService = new PrimeService(new Mocking());

        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        public void IsPrime_ValuesLessThan2_ReturnFalse(int value)
        {
            var result = _primeService.IsPrime(value);

            Assert.False(result, $"{value} should not be prime");
        }
    }
}
