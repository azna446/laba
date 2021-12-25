using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabWarmers.Common;
using LabWarmers.DataAccess;

namespace LabWarmers.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorsController : ControllerBase
    {
        private readonly SensorDataRepository _repository;

        public SensorsController(SensorDataRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("save")]
        public async Task<IActionResult> Save([FromBody] SensorDataRequest model)
        {
            await _repository.AddSensorData(model);
            return Ok();
        }
    }
}
