using System;
namespace WitchSaga.Core.Models
{
    public class KilledPerson
    {
        public KilledPerson(int ageOfDeath, int yearOfDeath)
        {
            this.AgeOfDeath = ageOfDeath;
            this.YearOfDeath = yearOfDeath;
        }
        public int AgeOfDeath { get; private set; }
        public int YearOfDeath { get; private set; }
    }
}
