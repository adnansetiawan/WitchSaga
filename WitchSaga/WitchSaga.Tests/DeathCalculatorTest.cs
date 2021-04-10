using System;
using Moq;
using WitchSaga.Core.Contracts;
using WitchSaga.Core.Implementator;
using WitchSaga.Core.Models;
using Xunit;

namespace WitchSaga.Tests
{
    public class DeathCalculatorTest
    {
        private Mock<IValidator> _validatorMock;
        private IDeathCalculator _deathCalculator;

        
        [Fact]
        public void GivenExampleValidInputShouldBePassed()
        {
            //arrange
            _validatorMock = new Mock<IValidator>();
            _validatorMock.Setup(x => x.IsValid(It.IsAny<KilledPerson>())).Returns(true);

            //act
            _deathCalculator = new DeathCalculator(_validatorMock.Object);
            var result = _deathCalculator.GetAverage(new KilledPerson(10, 12), new KilledPerson(13, 17));

            //assert
            Assert.Equal(4.5, result);


        }

        [Fact]
        public void GivenInValidInputShouldBeEqualMinus1()
        {
            //arrange
            _validatorMock = new Mock<IValidator>();
            _validatorMock.Setup(x => x.IsValid(It.IsAny<KilledPerson>())).Returns(false);

            //act
            _deathCalculator = new DeathCalculator(_validatorMock.Object);
            var result = _deathCalculator.GetAverage(new KilledPerson(-1, 12), new KilledPerson(-1, 17));

            //assert
            Assert.Equal(-1, result, 0);
        }

      
    }
}
