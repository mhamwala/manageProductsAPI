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
    public class reviewsController : ControllerBase
    {
        private readonly reviewsContext _context;

        public reviewsController(reviewsContext context)
        {
            _context = context;
        }

        // GET: api/reviews
        [HttpGet("api/reviews")]
        public async Task<ActionResult<IEnumerable<review>>> Getreview()
        {
            return await _context.review.ToListAsync();
        }

        // GET: api/reviews/5
        [HttpGet("api/reviews/{id}")]
        public async Task<ActionResult<review>> Getreview(long id)
        {
            var review = await _context.review.FindAsync(id);

            if (review == null)
            {
                return NotFound();
            }

            return review;
        }

        // PUT: api/reviews/5
        [HttpPut("api/reviews/{id}")]
        public async Task<IActionResult> Putreview(long id, review review)
        {
            if (id != review.Id)
            {
                return BadRequest();
            }

            _context.Entry(review).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!reviewExists(id))
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

        // POST: api/reviews
        [HttpPost("api/reviews")]
        public async Task<ActionResult<review>> Postreview(review review)
        {
            _context.review.Add(review);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getreview", new { id = review.Id }, review);
        }

        // DELETE: api/reviews/5
        [HttpDelete("api/reviews/{id}")]
        public async Task<ActionResult<review>> Deletereview(long id)
        {
            var review = await _context.review.FindAsync(id);
            if (review == null)
            {
                return NotFound();
            }

            _context.review.Remove(review);
            await _context.SaveChangesAsync();

            return review;
        }

        private bool reviewExists(long id)
        {
            return _context.review.Any(e => e.Id == id);
        }

        // GET: api/reviews/CUID
        [HttpGet("api/reviews/CUID/{id}")]
        public async Task<ActionResult<IEnumerable<review>>> GetreviewByCustomerID(int id)
        {
            var customerReviews = await _context.review.Where(r => r.customerID == id)
                                     .Select(r => new review
                                     {
                                         Id = r.Id,
                                         customerID = r.customerID,
                                         productID = r.productID,
                                         Rating = r.Rating,
                                         comments = r.comments,
                                         visible = r.visible
                                     }).ToListAsync();

            return customerReviews;
        }
    }
}
