using System;
using WitchSaga.Core.Contracts;
using WitchSaga.Core.Models;

namespace WitchSaga.Core.Implementator
{
    public class DeathCalculator : IDeathCalculator
    {
        private readonly IValidator _validator;
        public DeathCalculator(IValidator validator)
        {
            _validator = validator;
        }
        public double GetAverage(KilledPerson personA, KilledPerson personB)
        {
            if (!_validator.IsValid(personA) || !_validator.IsValid(personB))
                return -1;
            var numberOfPersonKilledOnYearA = GetNumberOfKilledByYear(personA.YearOfDeath - personA.AgeOfDeath);
            var numberOfPersonKilledOnYearB = GetNumberOfKilledByYear(personB.YearOfDeath - personB.AgeOfDeath);
            double result =  ((double)numberOfPersonKilledOnYearA + (double) numberOfPersonKilledOnYearB) / 2;
            return result;

        }

        private int GetNumberOfKilledByYear(int year)
        {
            if (year == 0)
                return 1;
            if (year == 1)
                return 1;
            int numberOfKilled = 1;
            for (int i = 1; i < year; i++)
            {
                numberOfKilled += i;
            }
            return numberOfKilled;
        }
    }
}
