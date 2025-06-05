using Microsoft.AspNetCore.Mvc;
using Shopping.DAL.Entities;
using Shopping.Domain.Interfaces;
using System.Linq;

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatesController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetByIdCountry")]

        public async Task<ActionResult<IEnumerable<State>>> GetStatesByCountryIdAsync(Guid countryId)
        {
            var states = await _stateService.GetStatesByIdCountryAsync(countryId);
            if (states == null || !states.Any()) return NotFound();

            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")]

        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null) return NotFound();

            return Ok(state);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]

        public async Task<ActionResult<State>> CreateCountryAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null) return NotFound();
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));
                return Conflict(ex.Message);
            }

        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit")]
        public async Task<ActionResult<State>> EditStateAsync(State state)
        {
            try
            {
                var editedState = await _stateService.EditStateAsync(state);
                if (editedState == null) return NotFound();
                return Ok(editedState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                    return Conflict(String.Format("{0} ya existe", state.Name));
                return Conflict(ex.Message);
            }

        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest();
            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);
        }
    }
}

