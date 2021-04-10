using System;
using WitchSaga.Core.Contracts;
using WitchSaga.Core.Models;

namespace WitchSaga.Core.Implementator
{
    public class Validator : IValidator
    {
        public bool IsValid(KilledPerson person)
        {
            if (person == null)
                return false;
            if (person.AgeOfDeath < 0)
                return false;
            if (person.YearOfDeath < 0)
                return false;
            if (person.YearOfDeath < person.AgeOfDeath)
                return false;
            return true;

        }
    }
}
