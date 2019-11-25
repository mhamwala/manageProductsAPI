using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using manageProducts.Models;

namespace manageProducts.Controllers
{
    [ApiController]
    public class productsController : ControllerBase
    {
        private readonly productsContext _context;

        public productsController(productsContext context)
        {
            _context = context;
        }

        // GET: api/products
        [HttpGet("api/Products")]
        public async Task<ActionResult<IEnumerable<product>>> Getproduct()
        {
            return await _context.product.ToListAsync();
        }

        // GET: api/products/5
        [HttpGet("api/Products/{id}")]
        public async Task<ActionResult<product>> Getproduct(long id)
        {
            var product = await _context.product.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET: api/products/lowStock
        [HttpGet("api/Products/lowStock")]
        public async Task<ActionResult<IEnumerable<product>>> GetStockLevel()
        {
            var lowStock = await _context.product.Where(p => p.stock <= 5)
                                       .Select(p => new product
                                       {
                                           Id = p.Id,
                                           Name = p.Name,
                                           price = p.price,
                                           stock = p.stock
                                       }).ToListAsync();

            return lowStock;
        }

        // PUT: api/products/5
        [HttpPut("api/Products/{id}")]
        public async Task<IActionResult> Putproduct(long id, product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/products
        [HttpPost("api/Products")]
        public async Task<ActionResult<product>> Postproduct(product product)
        {
            _context.product.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getproduct", new { id = product.Id }, product);
        }

        // DELETE: api/products/5
        [HttpDelete("api/Products/{id}")]
        public async Task<ActionResult<product>> Deleteproduct(long id)
        {
            var product = await _context.product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.product.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool productExists(long id)
        {
            return _context.product.Any(e => e.Id == id);
        }
    }
}
