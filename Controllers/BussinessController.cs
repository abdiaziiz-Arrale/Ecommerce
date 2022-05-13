namespace Controllers;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using ViewModel;
[Route("[controller]")]

public class BussinessController : ControllerBase
{
      private readonly ECommerceDbContext _context;
      public BussinessController(ECommerceDbContext context)
      {
            _context = context;
      }
      [HttpGet]
      public async Task<IActionResult> GetAll(int page, int size, string Categories)
      {
            // skip = page * size;

            var query = _context.bussinesses
                  .Include(d => d.User)
                  .Skip(page * size)
                  .Take(size);

            if (!string.IsNullOrEmpty(Categories))
            {
                  query = query.Where(d => d.Categories == Categories);
            }

            var bussinesses = await query
                  .OrderBy(d => d.Id)
                  .ToListAsync(HttpContext.RequestAborted);

            return Ok(bussinesses);
      }
      [HttpPost("AddingBussiness")]
      public async Task<IActionResult> AddBussiness(int userId, [FromForm] BussinessViewModel bussinessViewModel)
      {
            var user = await _context.Users.FindAsync(userId);
            if (user is null)
            {
                  return BadRequest("Invalid UserId");
            }
            var bussiness = new Bussiness
            {
                  Licesnce = bussinessViewModel.Licesnce,
                  Categories = bussinessViewModel.Categories,
                  Bio = bussinessViewModel.Bio,
                  IsVerified = true,
                  CreatedAt = DateTime.UtcNow,
                  Picture = bussinessViewModel.Picture,

                  UserId = user.Id,
            };

            _context.bussinesses.Add(bussiness);
            await _context.SaveChangesAsync(HttpContext.RequestAborted);

            return Created(nameof(AddBussiness), bussiness);
      }
      [HttpGet("Categories")]

      public async Task<IActionResult> GetCategories()
      {
            var Categories = await _context.bussinesses
                  .GroupBy(d => d.Categories)
                  .Select(g => new // Projection
                  {  // Anonymous Types.
                        Categories = g.Key,
                        Count = g.Count()
                  })
                  .ToListAsync(HttpContext.RequestAborted);

            return Ok(Categories);
      }
      [HttpPut("{id}")]
      public async Task<IActionResult> UpdateBussiness(int id )
      {
            var targetBussiness = await _context.bussinesses.FindAsync(id);
            if (targetBussiness is null)
            {
                  return BadRequest();
            }
            targetBussiness.IsVerified = false;


            _context.bussinesses.Update(targetBussiness);
            await _context.SaveChangesAsync();
            return Created("", targetBussiness);

      }

}
