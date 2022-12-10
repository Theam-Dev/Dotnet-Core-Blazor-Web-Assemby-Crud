using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorCrud.Server.Data;
using BlazorCrud.Shared.Models;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/Posts
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var dev = await _context.Posts.ToListAsync();
            return Ok(dev);
        }
        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            return Ok(post);
        }
        // PUT: api/Posts/5
        [HttpPut]
        public async Task<IActionResult> Put(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }
        // POST: api/Posts
        [HttpPost]
        public async Task<IActionResult> Post(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return Ok(post.Id);
        }
        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dev = new Post { Id = id };
            _context.Remove(dev);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
