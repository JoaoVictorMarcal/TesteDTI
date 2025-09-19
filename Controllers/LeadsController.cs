using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> AddLeads(Lead lead)
        {
            _appDbContext.BancoLeads.Add(lead);
            await _appDbContext.SaveChangesAsync();

            return Ok(lead);
        }

    }
}