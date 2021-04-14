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
            var result1 = _deathCalculator.GetAverage(new KilledPerson(10, 12), new KilledPerson(13, 17));

            //assert
            Assert.Equal(4.5, result1);

            var result2 = _deathCalculator.GetAverage(new KilledPerson(10, 12), new KilledPerson(13, 16));

            //assert
            Assert.Equal(3, result2);

            var result3 = _deathCalculator.GetAverage(new KilledPerson(10, 12), new KilledPerson(13, 18));

            //assert
            Assert.Equal(7, result3);



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
