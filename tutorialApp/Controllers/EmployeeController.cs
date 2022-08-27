using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tutorialApp.Models;
using tutorialApp.Services;

namespace tutorialApp.Controllers
{
    [Route("go/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Employee>> GetAll() => EmployeeService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var emp = EmployeeService.Get(id);
            if (emp is null) return NotFound();
            return emp;
        }

        [HttpPost]
        public ActionResult<Employee> Create(Employee emp)
        {
            EmployeeService.Add(emp);
            return CreatedAtAction(nameof(Create), emp);
        }
    }
}
