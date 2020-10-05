using Authentication.Services.Contract;
using Authentication.Settings;
using FluentAssertions;
using Moq;
using System;
using Xunit;

namespace UnitTest
{
    public class UnitTest1
    {


        [Fact]
        public void Test1()
        {
            // Arrange
            var mock = "result";

            // Act
            var result = "actual result";

            // Assert
            result.Should().Contain(mock);
        }

        [Theory]
        [InlineData("1", "2", "1")]
        [InlineData("3", "4", "")]
        public void MockTest(string clientId, string tenantId, string expected)
        {
            var mock = new Mock<ISettingsService>();
            mock.Setup(x => x.GetAzureAdSettings())
                .Returns(new AzureAdSettings { ClientId = clientId, TenantId = tenantId});

            var result = mock.Object.GetAzureAdSettings();

            result.Should()
                .BeOfType<AzureAdSettings>()
                .Which.ClientId.Should().BeEquivalentTo(expected) ;
        }
    }
}
