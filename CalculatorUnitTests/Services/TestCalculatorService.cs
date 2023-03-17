using CalculatorUnitTests.Fixtures;
using CalculatorUnitTests.Helpers;
using FluentAssertions;
using Moq;
using Moq.Protected;
using Services.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorUnitTests.Systems.Services
{
    public class TestCalculatorService
    {

        [Fact]
        public void AddCalculation()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate("1", "+", "1");
            //Assert
            
            result.Should().Be(2);

        }

        [Fact]
        public void SubtractCalculation()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate("2", "-", "1");
            //Assert

            result.Should().Be(1);

        }
        [Fact]
        public void MultiplyCalculation()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate("2", "*", "2");
            //Assert

            result.Should().Be(4);

        }

        [Fact]
        public void DivideCalculation()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate("4", "/", "2");
            //Assert

            result.Should().Be(2);

        }
    }
}
