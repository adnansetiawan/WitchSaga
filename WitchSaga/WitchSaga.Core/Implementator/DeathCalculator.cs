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
            if (year <= 0)
                return 0;

            int[] fibo = new int[year + 1];
            fibo[0] = 0; fibo[1] = 1;

            int sum = fibo[0] + fibo[1];

            for (int i = 2; i <= year; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
                sum += fibo[i];
            }

            return sum;
        }
    }
}
