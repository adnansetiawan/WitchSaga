using System;
using WitchSaga.Core.Contracts;
using WitchSaga.Core.Implementator;
using Xunit;

namespace WitchSaga.Tests
{
    public class ValidatorTest
    {
        private IValidator _validator;
        [Fact]
        public void GivenNullInputShouldReturnFalse()
        {
            _validator = new Validator();
            var result = _validator.IsValid(null);
            Assert.False(result);
        }

        [Fact]
        public void GivenAgeOfDeathInputIsLessThanZeroShouldReturnFalse()
        {
            _validator = new Validator();
            var result = _validator.IsValid(new Core.Models.KilledPerson(-1, 12));
            Assert.False(result);
        }
        [Fact]
        public void GivenYearOfDeathInputIsLessThanZeroShouldReturnFalse()
        {
            _validator = new Validator();
            var result = _validator.IsValid(new Core.Models.KilledPerson(12, 0));
            Assert.False(result);
        }
        [Fact]
        public void GivenYearOfDeathInputIsLessThanAgeOfYearShouldReturnFalse()
        {
            _validator = new Validator();
            var result = _validator.IsValid(new Core.Models.KilledPerson(12, 11));
            Assert.False(result);
        }

        [Fact]
        public void GivenYearOfDeathInputIsGratherThanAgeOfYearShouldReturnTrue()
        {
            _validator = new Validator();
            var result = _validator.IsValid(new Core.Models.KilledPerson(10, 12));
            Assert.True(result);
        }

        [Fact]
        public void GivenYearOfDeathInputIsEqualAgeOfYearShouldReturnTrue()
        {
            _validator = new Validator();
            var result = _validator.IsValid(new Core.Models.KilledPerson(10, 10));
            Assert.True(result);
        }
    }
}
