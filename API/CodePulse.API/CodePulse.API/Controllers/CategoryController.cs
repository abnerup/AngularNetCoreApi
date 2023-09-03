using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CodePulse.API.Models.Context;
using CodePulse.API.Models.Domain;
using CodePulse.API.Models.Dto;
using CodePulse.API.Repositories.Implementation;
using CodePulse.API.Repositories.Interface;

namespace CodePulse.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

     
       [HttpGet]
        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetAllCategories();
        }

        //// GET: api/Category/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Category>> GetCategory(Guid id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Categories.FindAsync(id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    return category;
        //}

        // PUT: api/Category/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutCategory(Guid id, CategoryDto category)
        //{
        //    if (id != category.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(category).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!CategoryExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Category>> PostCategory(Category Category)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return Problem("Entity set 'ApplicationDbContext.Categories'  is null.");
        //    }
        //    _context.Categories.Add(Category);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetCategory", new { id = Category.Id }, Category);
        //}


        // POST: api/Category
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryRequestDto categoryRequest)
        {
            var category = new Category
            {
                Name = categoryRequest.Name,
                UrlHandle = categoryRequest.UrlHandle,
            };
                      
            await _categoryRepository.CreateAsync(category);

            var response = new CategoryDto
            {
                Id = category.Id,
                Name = category.Name,
                UrlHandle = category.UrlHandle,
            };

            return Ok(response);
        }

        // DELETE: api/Category/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteCategory(Guid id)
        //{
        //    if (_context.Categories == null)
        //    {
        //        return NotFound();
        //    }
        //    var category = await _context.Categories.FindAsync(id);
        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Categories.Remove(category);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool CategoryExists(Guid id)
        //{
        //    return (_context.Categories?.Any(e => e.Id == id)).GetValueOrDefault();
        //}
    }
}
