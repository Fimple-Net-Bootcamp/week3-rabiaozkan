using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using VirtualPetCareAPI.Data;
using VirtualPetCareAPI.Models;

namespace VirtualPetCareAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthStatusesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HealthStatusesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Belirli bir evcil hayvanın sağlık durumunu getirir
        [HttpGet("{petId}")]
        public async Task<ActionResult<HealthStatus>> GetHealthStatus(int petId)
        {
            var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.PetId == petId);
            if (healthStatus == null)
            {
                return NotFound();
            }

            return healthStatus;
        }

        // Belirli bir evcil hayvanın sağlık durumunu günceller
        [HttpPatch("{petId}")]
        public async Task<IActionResult> UpdateHealthStatus(int petId, HealthStatus healthStatusUpdate)
        {
            var healthStatus = await _context.HealthStatuses.FirstOrDefaultAsync(h => h.PetId == petId);
            if (healthStatus == null)
            {
                return NotFound();
            }

            healthStatus.Status = healthStatusUpdate.Status;

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
