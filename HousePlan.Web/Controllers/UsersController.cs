using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.HousePlan;
using Kryptand.ChefMaster.Core.HousePlan;

namespace Kryptand.ChefMaster.Web.HousePlan.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly IUserRepository _usersRepo;
		public UsersController(IUserRepository usersRepo) => _usersRepo = usersRepo ?? throw new ArgumentNullException(nameof(usersRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var disposalLocations = await _usersRepo.GetAll();
			return Ok(disposalLocations);
		}

		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetUser")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _usersRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] User item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _usersRepo.Add(item);
			return CreatedAtRoute("GetUser", new { Controller = "Users", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] User item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _usersRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _usersRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _usersRepo.Remove(id);
			return NoContent();
		}
	}
}
