using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

using PrescriptionEntity = SaudeBemEstaApp.Domain.Entities.Prescription;

namespace SaudeBemEstaApp.Prescriptions.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionsController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        public async Task<IEnumerable<PrescriptionEntity>> GetPrescriptions()
        {
            return await _prescriptionService.GetAllPrescriptionAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrescriptionEntity>> GetPrescription(int id)
        {
            var prescription = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (prescription == null)
            {
                return NotFound();
            }

            return prescription;
        }

        [HttpPost]
        public async Task<IActionResult> AddPresciption([FromBody] PrescriptionEntity prescription)
        {
            await _prescriptionService.AddPrescriptionAsync(prescription);
            return CreatedAtAction(nameof(GetPrescription), new { id = prescription.Id }, prescription);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePrescription(int id, [FromBody] PrescriptionEntity prescription)
        {
            if (id != prescription.Id) return BadRequest();
            await _prescriptionService.UpdatePrescriptionAsync(prescription);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(int id)
        {
            await _prescriptionService.DeletePrescriptionAsync(id);
            return NoContent();
        }
    }
}
