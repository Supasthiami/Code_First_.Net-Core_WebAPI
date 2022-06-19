using CodeFirstApproach.Models;
using CodeFirstApproach.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeFirstApproach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IDataRepository<Employee> _dataRepository;

        public EmployeeController(IDataRepository<Employee> dataRepository)
        {
            _dataRepository = dataRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            IEnumerable<Employee> employees = _dataRepository.GetAll();
                return Ok(employees);
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            Employee employee = _dataRepository.GetEmployee(id);
            if(employee == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }


        [HttpPost]
        public IActionResult SaveEmployee([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee is null.");
            }
            else
            {
                _dataRepository.SaveEmployee(employee);
                return Ok(employee);

            }
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            Employee em = _dataRepository.GetEmployee(id);
            if(em == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.DeleteEmployee(em);
                return Ok("Deleted Successfully");
            }
        }
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id,[FromBody] Employee employee)
        {
            Employee em = _dataRepository.GetEmployee(id);
            if (em == null)
            {
                return NotFound();
            }
            else
            {
                _dataRepository.UpdateEmployee(em, employee);

                return Ok(em);
            }
        }
    }
}
