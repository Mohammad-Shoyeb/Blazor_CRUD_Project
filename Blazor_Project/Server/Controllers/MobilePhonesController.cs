using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blazor_Project.Shared.Models;
using Blazor_Project.Shared.DTO;

namespace Blazor_Project.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MobilePhonesController : ControllerBase
    {
        private readonly MobilePhoneDbContext _context;
        private readonly IWebHostEnvironment env;
        public MobilePhonesController(MobilePhoneDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: api/MobilePhones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MobilePhone>>> GetMobilePhones()
        {
          if (_context.MobilePhones == null)
          {
              return NotFound();
          }
            return await _context.MobilePhones.ToListAsync();
        }

        // GET: api/MobilePhones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MobilePhone>> GetMobilePhone(int id)
        {
          if (_context.MobilePhones == null)
          {
              return NotFound();
          }
            var mobilePhone = await _context.MobilePhones.FindAsync(id);

            if (mobilePhone == null)
            {
                return NotFound();
            }

            return mobilePhone;
        }

        // PUT: api/MobilePhones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobilePhone(int id, MobilePhone mobilePhone)
        {
            if (id != mobilePhone.MobilePhoneID)
            {
                return BadRequest();
            }

            _context.Entry(mobilePhone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobilePhoneExists(id))
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

        // POST: api/MobilePhones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MobilePhone>> PostMobilePhone(MobilePhone mobilePhone)
        {
          if (_context.MobilePhones == null)
          {
              return Problem("Entity set 'MobilePhoneDbContext.MobilePhones'  is null.");
          }
            _context.MobilePhones.Add(mobilePhone);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobilePhone", new { id = mobilePhone.MobilePhoneID }, mobilePhone);
        }
        [HttpPost("Upload")]
        public async Task<ImageUploadResponse> Upload(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName);
            var randomFileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
            var storedFileName = randomFileName + ext;
            using FileStream fs = new FileStream(Path.Combine(env.WebRootPath, "Uploads", storedFileName), FileMode.Create);
            await file.CopyToAsync(fs);
            fs.Close();
            return new ImageUploadResponse { FileName = file.FileName, StoredFileName = storedFileName };
        }


        // DELETE: api/MobilePhones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMobilePhone(int id)
        {
            if (_context.MobilePhones == null)
            {
                return NotFound();
            }
            var mobilePhone = await _context.MobilePhones.FindAsync(id);
            if (_context.OrderItems.Any(x => x.MobilePhoneID == id)) return BadRequest("Entity has child data");

            if (mobilePhone == null)
            {
                return NotFound();
            }

            _context.MobilePhones.Remove(mobilePhone);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MobilePhoneExists(int id)
        {
            return (_context.MobilePhones?.Any(e => e.MobilePhoneID == id)).GetValueOrDefault();
        }
    }
}
