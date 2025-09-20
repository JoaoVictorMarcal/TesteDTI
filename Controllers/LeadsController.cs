using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using testeDTI.Data;
using testeDTI.Models; 

namespace testeDTI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeadsController : ControllerBase
    {
        private readonly AppDbContext _appDbContext;

        public LeadsController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddLeads([FromBody] Lead lead)
        {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            
            _appDbContext.BancoLeads.Add(lead);
            await _appDbContext.SaveChangesAsync();

            return Created("Lead adicionado",lead);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
        {
            var leads = await _appDbContext.BancoLeads.ToListAsync();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Lead>> GetLead(int id)
        {
            var lead = await _appDbContext.BancoLeads.FindAsync(id);
            if (lead == null)
            {
                return NotFound("Lead não encontrado");
            }
            return Ok(lead);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutLead(int id, [FromBody] Lead leadModificado)
        {
            var leadExiste = await _appDbContext.BancoLeads.FindAsync(id);
            if (leadExiste == null)
            {
                return NotFound("Lead não encontrado");
            }
            _appDbContext.Entry(leadExiste).CurrentValues.SetValues(leadModificado);
            await _appDbContext.SaveChangesAsync();

            return StatusCode(201, leadExiste);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLead(int id)
        {
            var lead = await _appDbContext.BancoLeads.FindAsync(id);
            if (lead == null)
            {
                return NotFound("Lead não encontrado");
            }
            _appDbContext.BancoLeads.Remove(lead);
            await _appDbContext.SaveChangesAsync();

            return Ok("Lead deletado");
        }


    }
}