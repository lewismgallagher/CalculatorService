using FluentAssertions;
using Moq;
using Moq.Protected;
using Services.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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

        [Theory]
        [InlineData("10", "+", "50",60)]
        [InlineData("-25", "+", "50",25)]

        public void ComplexAddCalculation(string value1, string operation, string value2, double expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate(value1, operation, value2);
            //Assert

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("30", "-", "15", 15)]
        [InlineData("-25", "-", "60", -85)]

        public void ComplexSubtracCalculation(string value1, string operation, string value2, double expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate(value1, operation, value2);
            //Assert

            result.Should().Be(expected);
        }

        [Fact]
        public void SubtractingTwoNegativesCalculation()
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate("-10", "-", "-10");
            //Assert

            result.Should().Be(0);
        }

        [Theory]
        [InlineData("7", "*", "9", 63)]
        [InlineData("-95", "*", "60", -5700)]
        public void ComplexMultiplyCalculation(string value1, string operation, string value2, double expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate(value1, operation, value2);
            //Assert

            result.Should().Be(expected);
        }

        [Theory]
        [InlineData("7", "/", "10", 0.7)]
        [InlineData("-1005", "/", "-10", 100.5)]
        public void ComplexDivideCalculation(string value1, string operation, string value2, double expected)
        {
            //Arrange
            var sut = new Calculator();

            //Act
            var result = sut.Calculate(value1, operation, value2);
            //Assert

            result.Should().Be(expected);
        }

        [Fact]
        public void DivideByZeroCalculationShouldThrowException()
        {
            var sut = new Calculator();

            Assert.Throws<DivideByZeroException>(() => {sut.Calculate("10", "/", "0"); });
        }

        [Fact]
        public void InvalidExpressionShouldThrowException()
        {
            var sut = new Calculator();

            Assert.Throws<ArgumentException>(() => { sut.Calculate("//", "/55gj", "/dg"); });
        }

        [Fact]
        public void EmptyExpressionShouldThrowException()
        {
            var sut = new Calculator();

            Assert.Throws<ArgumentException>(() => { sut.Calculate("", "", ""); });
        }
    }
}
