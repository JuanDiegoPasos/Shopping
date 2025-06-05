using Shopping.DAL.Entities;

namespace Shopping.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesByIdCountryAsync(Guid id);

        Task<State> CreateStateAsync(State state);

        Task<State> GetStateByIdAsync(Guid id);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid id);

    }
}

