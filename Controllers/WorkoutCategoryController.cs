using FitnessWorkoutMgmnt.Models;
using FitnessWorkoutMgmnt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessWorkoutMgmnt.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutCategoryController : ControllerBase
    {
        private readonly IWorkoutCategoryService _categoryService;

        public WorkoutCategoryController(IWorkoutCategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/WorkoutCategory
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkoutCategory>>> GetAllCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        // GET: api/WorkoutCategory/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkoutCategory>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // POST: api/WorkoutCategory
        [HttpPost]
        public async Task<ActionResult<WorkoutCategory>> CreateCategory(WorkoutCategory category)
        {
            if (category == null || string.IsNullOrEmpty(category.Name))
            {
                return BadRequest("Invalid category data.");
            }

            var createdCategory = await _categoryService.CreateCategoryAsync(category);

            return CreatedAtAction(nameof(GetCategoryById), new { id = createdCategory.Id }, createdCategory);
        }

        // PUT: api/WorkoutCategory/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, WorkoutCategory category)
        {
            if (id != category.Id)
            {
                return BadRequest("Category ID mismatch.");
            }

            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);

            if (updatedCategory == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/WorkoutCategory/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return NoContent();
        }
    }
}
