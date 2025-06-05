using Microsoft.EntityFrameworkCore;
using Shopping.DAL;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;

namespace Shopping.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContext _context;

        public StateService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> GetStatesByIdCountryAsync(Guid countryId)
        {
            try
            {
                return await _context.States.Where(s => s.CountryId == countryId).ToListAsync();

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                return await _context.States.FirstOrDefaultAsync(c => c.Id == id);
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _context.States.Add(state);
                await _context.SaveChangesAsync();

                return state;

            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _context.States.Update(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);

                if (state == null)
                {
                    return null;
                }
                _context.States.Remove(state);
                await _context.SaveChangesAsync();

                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {
                throw new Exception(dbUpdateException.InnerException?.Message ??
                    dbUpdateException.Message);
            }

        }
    }
}
