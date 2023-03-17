using CalculatorAPI.Dtos;
using CalculatorService.Controllers;
using CalculatorUnitTests.Fixtures;
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
        [Fact]
        public void CalculateOnSuccessReturnsStatusCode200()
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act

            var result = (OkObjectResult) sut.Calculate(SuccessfulDtoCalculationsFixture.GetAddCalculationDto());

            // Assert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public void CalculateOnSuccessReturnsDouble()
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act
            var result =  sut.Calculate(SuccessfulDtoCalculationsFixture.GetAddCalculationDto());

            //Assert
            result.Should().BeOfType <OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<double>();
        }

        [Fact]
        public void CalculateOnFailureWithinControllerReturns400Response()
        {
            // Arrange
            var mockCalculatorService = new Mock<ICalculator>();
            var sut = new CalculatorController(mockCalculatorService.Object);

            // Act
            
            var result =  sut.Calculate(null);

            //Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

    }
}
