using BexApiCrud.Data;
using BexApiCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BexApiCrud.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class EmployeesController : Controller
	{
		private readonly BexdbContext _bexdb;

		public EmployeesController(BexdbContext bexdb)
		{
			_bexdb = bexdb;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllEmployees()
		{
			var employees = await _bexdb.Employees.ToListAsync();
			return Ok(employees);
		}

		[HttpPost]
		public async Task<IActionResult> AddEmployee([FromBody] Employee employeeRequest)
		{
			employeeRequest.Id = Guid.NewGuid();

			await _bexdb.Employees.AddAsync(employeeRequest);
			await _bexdb.SaveChangesAsync();

			return Ok(employeeRequest);
		}

		[HttpGet]
		[Route("{id:Guid}")]
		public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
		{
			var employee = await _bexdb.Employees.FirstOrDefaultAsync(x => x.Id == id);
			if (employee == null)
			{
				return NotFound();
			}

			return Ok(employee);
		}

		[HttpPut]
		[Route("{id:Guid}")]
		public async Task<IActionResult> updateEmployee([FromRoute] Guid id, Employee updateEmployee)
		{
			var employee = await _bexdb.Employees.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}
			employee.FirstName = updateEmployee.FirstName;
			employee.LastName = updateEmployee.LastName;
			employee.Email = updateEmployee.Email;
			employee.Phone = updateEmployee.Phone;
			employee.Position = updateEmployee.Position;
			employee.Department = updateEmployee.Department;

			await _bexdb.SaveChangesAsync();
			return Ok(employee);
		}

		[HttpDelete]
		[Route("{id:Guid}")]
		public async Task<IActionResult> DeleteEmployee([FromRoute] Guid id)
		{
			var employee = await _bexdb.Employees.FindAsync(id);
			if (employee == null)
			{
				return NotFound();
			}
			_bexdb.Employees.Remove(employee);
			await _bexdb.SaveChangesAsync();
			return Ok(employee);
		}
	}
}
