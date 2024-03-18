using AutoMapper;
using Contracts;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OrderManagment.Controllers
{
    [Route("api/supplier")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private ILoggerManager _logger;
        private IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public SupplierController(ILoggerManager logger, IRepositoryManager repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllSuppliers()
        {
            try

            {
                var suppliers = _repository.Supplier.GetAllSuppliers();
                _logger.LogInfo($"Returned all suppliers from database.");
                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllSuppliers action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetSupplierById(Guid Id)
        {
            return Ok(_repository.Supplier.GetSupplierById(Id));
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Supplier supplier)
        {
            if (supplier == null)
            {
                _logger.LogError("CompanyForCreationDto object sent from client is null.");
                return BadRequest("CompanyForCreationDto object is null");
            }
            _repository.Supplier.CreateSupplier(supplier);
            _repository.Save();

            return CreatedAtRoute("CompanyById",
                new { id = supplier.Id }, supplier);
        }

        [HttpPut]
        public IActionResult UpdateSupplier([FromBody] Supplier supplier)
        {
            try
            {
                if (supplier is null)
                {
                    _logger.LogError("Supplier object sent from client is null.");
                    return BadRequest("Supplier object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid supplier object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var supplierEntity = _repository.Supplier.GetSupplierById(supplier.Id);
                if (supplierEntity is null)
                {
                    _logger.LogError($"Supplier with id: {supplier.Id}, hasn't been found in db.");
                    return NotFound();
                }
                //var companyEntity = _mapper.Map<Supplier>(supplier);
                _repository.Supplier.UpdateSupplier(supplier);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateSupplier action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSupplier(Guid Id)
        {
            try
            {
                var supplier = _repository.Supplier.GetSupplierById(Id);
                if (supplier == null)
                {
                    _logger.LogError($"supplier with id: {Id}, hasn't been found in db.");
                    return NotFound();
                }
                _repository.Supplier.DeleteSupplier(supplier);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteSupplier action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
