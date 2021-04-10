using System;
namespace WitchSaga.Core.Contracts
{
    public interface IValidator
    {
        bool IsValid(Models.KilledPerson person);
    }
}
