using System;
using WitchSaga.Core.Models;

namespace WitchSaga.Core.Contracts
{
    public interface IDeathCalculator
    {
        double GetAverage(KilledPerson personA, KilledPerson personB);
    }
}
