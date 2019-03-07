using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Kryptand.ChefMaster.Infrastructure.HousePlan;
using System.Linq;

namespace Kryptand.ChefMaster.Web.HousePlan.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TasksController : ControllerBase
	{
		// GET: api/AmountUnit
		private readonly ITaskRepository _taskRepo;
		public TasksController(ITaskRepository taskRepo) => _taskRepo = taskRepo ?? throw new ArgumentNullException(nameof(taskRepo));
		[HttpGet]
		public async Task<IActionResult> GetAll(Guid? userId, Guid? categoryId)
		{
			if (userId == null && categoryId == null)
			{
				var disposalLocations = await _taskRepo.GetAll();
				return Ok(disposalLocations);
			}
			var taskQueryable = _taskRepo.GetAllAsQueryable();
			if (userId != null)
			{
				taskQueryable.Where(x => x.Users.Any(y => y.Id == userId));
			}
			if (categoryId != null)
			{
				taskQueryable.Where(x => x.CategoryId == categoryId);
			}
			return Ok(taskQueryable.ToAsyncEnumerable());
		}
		[HttpGet]
		public IActionResult GetAllForToday(Guid? userId)
		{
			var taskQueryable = _taskRepo.GetAllAsQueryable().Where(x=>x.DueAt.ToShortDateString()==DateTime.Now.ToShortDateString());
			if (userId != null)
			{
				taskQueryable.Where(x => x.Users.Any(y => y.Id == userId));
			}
			return Ok(taskQueryable.ToAsyncEnumerable());
		}
	
		// GET: api/AmountUnit/5
		[HttpGet("{id}", Name = "GetTask")]
		public async Task<IActionResult> GetById(Guid id)
		{
			if (id == null)
			{
				return BadRequest();
			}
			var item = await _taskRepo.FindById(id);
			if (item == null)
			{
				return NotFound();
			}
			return Ok(item);
		}

		// POST: api/AmountUnit
		[HttpPost]
		public async Task<IActionResult> Create([FromBody] Core.HousePlan.Task item)
		{
			if (item == null)
			{
				return BadRequest();
			}
			await _taskRepo.Add(item);
			return CreatedAtRoute("GetTask", new { Controller = "Tasks", id = item.Id }, item);
		}

		// PUT: api/AmountUnit/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] Core.HousePlan.Task item)
		{
			if (item == null || id == null)
			{
				return BadRequest();
			}
			var contactObj = await _taskRepo.FindById(id);
			if (contactObj == null)
			{
				return NotFound();
			}
			await _taskRepo.Update(item);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			await _taskRepo.Remove(id);
			return NoContent();
		}
	}
}
