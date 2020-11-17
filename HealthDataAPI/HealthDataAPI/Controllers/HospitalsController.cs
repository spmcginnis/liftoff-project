using HealthDataAPI.Models;
using HealthDataAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace HealthDataAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class HospitalsController : ControllerBase
    {
        private readonly HospitalService _hospitalService;

        public HospitalsController(HospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet]
        public ActionResult<List<Hospitals>> Get() =>
            _hospitalService.Get();

        [HttpGet("{id:length(24)}", Name = "GetHospital")]
        public ActionResult<Hospitals> Get(string id)
        {
            var hospital = _hospitalService.Get(id);

            if (hospital == null)
            {
                return NotFound();
            }

            return hospital;
        }

        [HttpPost]
        public ActionResult<Hospitals> Create(Hospitals hospital)
        {
            _hospitalService.Create(hospital);

            return CreatedAtRoute("GetHospital", new { id = hospital.Id.ToString() }, hospital);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Hospitals hospitalIn)
        {
            var hospital = _hospitalService.Get(id);

            if (hospital == null)
            {
                return NotFound();
            }

            _hospitalService.Update(id, hospitalIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var book = _hospitalService.Get(id);
            if (book == null)
            {
                return NotFound();
            }

            _hospitalService.Remove(book.Id);

            return NoContent();
        }



    }
}
