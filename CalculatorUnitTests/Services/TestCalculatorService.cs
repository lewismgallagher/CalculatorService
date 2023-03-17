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

        //[Theory]
        //[InlineData(10,"+",5)]
        //[InlineData(-5,"+",-5)]
        //[InlineData(double.MaxValue,"+",double.MaxValue)]
        //[InlineData(double.MinValue,"+",-100)]
        //public async Task CheckCalculateMethodCanAdd(double value1, string operation, double value2)
        //{
        //    //Arrange
        //    var expectedResponse = AddCalculationFixture.AddCalculation();
        //    var handlerMock = MockHTTPMessageHandler.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var sut = new Calculator(httpClient);

        //    //Act
        //    await sut.Calculate(value1,operation,value2);

        //    //Assert

        //    handlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
        //         ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
        //         ItExpr.IsAny<CancellationToken>());
        //    //Verify Http Request Was Made
        //}

        //[Theory]
        //[InlineData(10, "+", 5)]
        //[InlineData(-5, "+", -5)]
        //[InlineData(double.MaxValue, "+", double.MaxValue)]
        //[InlineData(double.MinValue, "+", -100)]
        //public async Task CalculateWhenCalledInvokesHTTPGetRequest(double value1, string operation, double value2)
        //{
        //    //Arrange
        //    var expectedResponse = AddCalculationFixture.AddCalculation();
        //    var handlerMock = MockHTTPMessageHandler.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var sut = new Calculator(httpClient);

        //    //Act
        //    await sut.Calculate(value1, operation, value2);

        //    //Assert

        //    handlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
        //         ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
        //         ItExpr.IsAny<CancellationToken>());
        //    //Verify Http Request Was Made
        //}

        //[Theory]
        //[InlineData(10, "+", 5)]
        //[InlineData(-5, "+", -5)]
        //[InlineData(double.MaxValue, "+", double.MaxValue)]
        //[InlineData(double.MinValue, "+", -100)]
        //public async Task CalculateReturnsTypeOfDouble(double value1, string operation, double value2)
        //{
        //    //Arrange
        //    var expectedResponse = AddCalculationFixture.AddCalculation();
        //    var handlerMock = MockHTTPMessageHandler.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var sut = new Calculator(httpClient);

        //    //Act
        //   var result = await sut.Calculate(value1,operation,value2);

        //    //Assert

        //    result.Should().BeOfType(typeof(double));
            
        //}

        //[Theory]
        //[InlineData(10, "+", 5)]
        //[InlineData(-5, "+", -5)]
        //[InlineData(double.MaxValue, "+", double.MaxValue)]
        //[InlineData(double.MinValue, "+", -100)]
        //public async Task CalculateOnFailureReturnss400Response(double value1, string operation, double value2)
        //{
        //    //Arrange
        //    var expectedResponse = AddCalculationFixture.AddCalculation();
        //    var handlerMock = MockHTTPMessageHandler.SetupBasicGetResourceList(expectedResponse);
        //    var httpClient = new HttpClient(handlerMock.Object);
        //    var sut = new Calculator(httpClient);

        //    //Act
        //    var result = await sut.Calculate(value1,operation,value2);

        //    //Assert

        //    result.Should().BeOfType(typeof(double));

        //}
    }
}
