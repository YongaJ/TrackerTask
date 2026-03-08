using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using TaskTracker.Api.Data;
using TrackerTask.Model;

namespace TrackerTask.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : ControllerBase
    {
        private readonly DatabaseContext _db;

        public TasksController(DatabaseContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks(string? searchString, string? sorting)
        {
            try
            {
                var query = _db.Tasks.AsQueryable();

                if (!string.IsNullOrWhiteSpace(searchString))
                {
                    query = query.Where(t =>
                        t.Title.ToLower().Contains(searchString.ToLower()) ||
                        (t.Description ?? "").ToLower().Contains(searchString.ToLower()));
                }

                query = sorting == "dueDate:desc"
                    ? query.OrderByDescending(t => t.DueDate)
                    : query.OrderBy(t => t.DueDate);

                return Ok(await query.ToListAsync());
            }
            catch (Exception ex)
            {
                return Problem(detail: ex.Message + ex?.InnerException);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var task = await _db.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            return Ok(task);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var task = await _db.Tasks.FindAsync(id);

            if (task == null)
                return NotFound();

            _db.Tasks.Remove(task);

            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAllTasks), null, task);
        }
    }
}