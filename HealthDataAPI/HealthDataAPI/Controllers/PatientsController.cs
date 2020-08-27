using HealthDataAPI.Models;
using HealthDataAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HealthDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController: ControllerBase
    {
        private readonly PatientService _patientService;

        public PatientsController(PatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public ActionResult<List<Patients>> Get() =>
            _patientService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPatient")]
        public ActionResult<Patients> Get(string id)
        {
            var patient = _patientService.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            return patient;
        }

        [HttpPost]
        public ActionResult<Patients> Create(Patients patient)
        {
            _patientService.Create(patient);

            return CreatedAtRoute("GetPatient", new { id = patient.Id.ToString() }, patient);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Patients patientIn)
        {
            var patient = _patientService.Get(id);

            if (patient == null)
            {
                return NotFound();
            }

            _patientService.Update(id, patientIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _patientService.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            _patientService.Remove(book.Id);

            return NoContent();
        }



    }
}
