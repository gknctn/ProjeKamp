using BlogApi.DataAccessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BlogApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public IActionResult EmployeeList()
        {
            using var c = new Context();
            var values = c.Employees.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult EmployeeAdd(Employee employee)
        {
            using var context = new Context();
            context.Employees.Add(employee);
            context.SaveChanges();
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult EmployeeGet(int id) 
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employee);
            }
        }
        [HttpDelete("{id}")]
        public IActionResult EmployeeDelete(int id) 
        {
            using var context = new Context();
            var employee = context.Employees.Find(id);
            if (employee == null) 
            {
                return NotFound(id);
            }
            else
            {
                context.Remove(employee);
                context.SaveChanges();
                return Ok();
            }
        }
        [HttpPut]
        public IActionResult EmployeeUpdate(Employee employee)
        {
            using var context = new Context();

            var emp = context.Find<Employee>(employee.ID);
            if (emp == null)
            {
                return NotFound(employee.ID);
            }
            else
            {
                emp.Name=employee.Name;
                context.Update(emp);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
