using CalculatorService.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json.Linq;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.Systems.Controllers
{
    public class TestCalculatorController
    {
        [Theory]
        [InlineData("10", "+", "10")]
        public async Task CalculateOnSuccessReturnsStatusCode200(string value1, string operation, string value2)
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            mockCalculatorService
            .Setup(service => service.Calculate(value1, operation, value2))
            .ReturnsAsync(12);

            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act

            var result = (OkObjectResult)await sut.Calculate(value1,operation,value2);

            // Assert

            result.StatusCode.Should().Be(200);
        }

        [Theory]
        [InlineData(10, "+", 5)]
        public async Task CalculateOnSuccessInvokeCalcServiceOnce(double value1, string operation, double value2)
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            mockCalculatorService
            .Setup(service => service.Calculate(value1, operation, value2))
            .ReturnsAsync(12);

            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = await sut.Calculate(value1, operation, value2);

            //Assert
            mockCalculatorService.Verify(
                service => service.Calculate(value1, operation, value2), Times.Once());
        }

        [Theory]
        [InlineData(10, "+", 5)]
        public async Task CalculateOnSuccessReturnsDouble(double value1, string operation, double value2)
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            mockCalculatorService
            .Setup(service => service.Calculate(value1, operation, value2))
            .ReturnsAsync(12);

            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = await sut.Calculate(value1, operation, value2);

            //Assert
            result.Should().BeOfType <OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<double>();
        }

        // to do add if bad request
        [Fact]
        public async Task CalculateOnFailureReturns400Response()
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            mockCalculatorService
            .Setup(service => service.Calculate(1, "", 6))
            .ReturnsAsync(12);

            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result = await sut.Calculate(1, "", 6);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
            var objectResult = (BadRequestObjectResult)result;
            objectResult.Value.Should().BeOfType<List<string>>();
        }

    }
}
