using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using manageProducts.Data;
using manageProducts.Models;

namespace manageProducts.Controllers
{
    [ApiController]
    public class productsHistoryController : ControllerBase
    {
        private readonly productsHistoryContext _context;

        public productsHistoryController(productsHistoryContext context)
        {
            _context = context;
        }

        // GET: api/productsHistory
        [HttpGet("api/productsHistory")]
        public async Task<ActionResult<IEnumerable<productHistory>>> GetproductHistory()
        {
            return await _context.productHistory.ToListAsync();
        }

        // GET: api/productsHistory/5
        [HttpGet("api/productsHistory/{id}")]
        public async Task<ActionResult<productHistory>> GetproductHistory(long id)
        {
            var productHistory = await _context.productHistory.FindAsync(id);

            if (productHistory == null)
            {
                return NotFound();
            }

            return productHistory;
        }

        // PUT: api/productsHistory/5
        [HttpPut("api/productsHistory/{id}")]
        public async Task<IActionResult> PutproductHistory(long id, productHistory productHistory)
        {
            if (id != productHistory.id)
            {
                return BadRequest();
            }

            _context.Entry(productHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!productHistoryExists(id))
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

        // POST: api/productsHistory
        [HttpPost]
        public async Task<ActionResult<productHistory>> PostproductHistory(productHistory productHistory)
        {
            _context.productHistory.Add(productHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetproductHistory", new { id = productHistory.id }, productHistory);
        }

        // DELETE: api/productsHistory/5
        [HttpDelete("api/productsHistory/{id}")]
        public async Task<ActionResult<productHistory>> DeleteproductHistory(long id)
        {
            var productHistory = await _context.productHistory.FindAsync(id);
            if (productHistory == null)
            {
                return NotFound();
            }

            _context.productHistory.Remove(productHistory);
            await _context.SaveChangesAsync();

            return productHistory;
        }

        private bool productHistoryExists(long id)
        {
            return _context.productHistory.Any(e => e.id == id);
        }

        // GET: api/productsHistory/
        [HttpGet("api/productsHistory/CUID/{id}")]
        public async Task<ActionResult<IEnumerable<productHistory>>> GetProductHistoryByCustomerID(int id)
        {
            var productHistory = await _context.productHistory.Where(r => r.productId == id)
                                     .Select(r => new productHistory
                                     {
                                         id = r.id,
                                         productId = r.productId,
                                         dateChange = r.dateChange,
                                         price = r.price,
                                        
                                     }).ToListAsync();

            return productHistory;
        }
    }
}
