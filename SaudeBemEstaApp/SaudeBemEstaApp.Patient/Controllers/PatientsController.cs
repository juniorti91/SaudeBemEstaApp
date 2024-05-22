using Microsoft.AspNetCore.Mvc;
using SaudeBemEstaApp.Domain.Entities;
using SaudeBemEstaApp.Domain.Interfaces;

namespace SaudeBemEstaApp.Patients.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientsController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public async Task<IEnumerable<Patient>> Get() 
        {
            return await _patientService.GetAllPatientsAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            var patient = await _patientService.GetPatientByIdAsync(id);
            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Patient patient)
        {
            await _patientService.AddPatientAsync(patient);
            return CreatedAtAction(nameof(Get), new { id = patient.Id }, patient);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Patient patient)
        {
            if (id != patient.Id) return BadRequest();
            await _patientService.UpdatePatientAsync(patient);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _patientService.DeletePatientAsync(id);
            return NoContent();
        }
    }
}
