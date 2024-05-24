using Microsoft.AspNetCore.Mvc;
using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Activities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivityController : ControllerBase
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        [HttpGet]
        public async Task<IEnumerable<Activity>> GetActivities()
        {
            return await _activityService.GetAllActivityAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Activity>> GetActivity(int id)
        {
            var activity = await _activityService.GetActivityByIdAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return activity;
        }

        [HttpPost]
        public async Task<IActionResult> AddActivity([FromBody] Activity activity)
        {
            await _activityService.AddActivityAsync(activity);
            return CreatedAtAction(nameof(AddActivity), new { id = activity.Id }, activity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateActivity(int id, [FromBody] Activity activity)
        {
            if (id != activity.Id) return BadRequest();
            await _activityService.UpdateActivityAsync(activity);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(int id)
        {
            await _activityService.DeleteActivityAsync(id);
            return NoContent();
        }
    }
}
