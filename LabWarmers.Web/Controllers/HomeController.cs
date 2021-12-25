using LabWarmers.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using LabWarmers.DataAccess;
using Newtonsoft.Json;

namespace LabWarmers.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SensorDataRepository _repo;

        public HomeController(
            ILogger<HomeController> logger, 
            SensorDataRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
        
        public async Task<IActionResult> Index([FromRoute]string id = "", [FromQuery] DateTime? from = null)
        {
            var allRoutes = await _repo.GetAllAvailableSensors();

            from ??= DateTime.UtcNow - TimeSpan.FromMinutes(10);

            var selectedChart = allRoutes.FirstOrDefault(x => x == id) ?? allRoutes.FirstOrDefault();

            var result = new ResultDto();

            result.ChartName = selectedChart;
            result.LastUpdateOn = DateTime.Now;
            result.AvailableCharts = allRoutes;
            result.ChartValues = (await _repo.FetchSensorData(selectedChart, from.Value))
                .OrderBy(x => x.Timestamp)
                .Select(x => new ResultDto.CurrentChartValues
                {
                    X = x.Timestamp,
                    Y = bool.TryParse(x.Data, out var res)
                        ? res 
                            ? 1.ToString()
                            : 0.ToString()
                        : x.Data
                })
                .ToList();

            ViewBag.DataPoints = JsonConvert.SerializeObject(result.ChartValues);

            return View(result);
        }

        public class ResultDto
        {
            public List<string> AvailableCharts { get; set; }

            public string ChartName { get; set; }

            public DateTime LastUpdateOn { get; set; }

            public List<CurrentChartValues> ChartValues { get; set; }

            public class CurrentChartValues
            {
                public DateTime X { get; set; }
                public string Y { get; set; }
            }
        }
    }
}
