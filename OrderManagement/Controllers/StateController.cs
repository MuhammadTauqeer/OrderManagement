using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderManagement.Controllers
{
    [Route("api/state")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        public StateController(ILoggerManager logger, IRepositoryManager repository)
        {
            _logger = logger;
            _repository = repository;
        }
        [HttpGet]
        public IActionResult GetAllStates()
        {
            try

            {
                var states = _repository.State.GetAllStates();
                _logger.LogInfo($"Returned all states from database.");
                return Ok(states);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllStates action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetStateById(Guid Id)
        {
            return Ok(_repository.State.GetStateById(Id));
        }
    }
}
