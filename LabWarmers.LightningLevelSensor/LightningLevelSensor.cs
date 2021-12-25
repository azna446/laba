using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWarmers.SensorBase;

namespace LabWarmers.LightningLevelSensor
{
    class LightningLevelSensor : SensorBase<double>
    {
        private readonly Random _random = new(DateTime.UtcNow.Millisecond);
        protected override double GetResult()
        {
            return 0.7 + (_random.NextDouble() / 10) - 0.5;
        }

        protected override string SensorName => "LightningLevelSensor";

        public override TimeSpan TimeBetweenFetches => TimeSpan.FromSeconds(1);
    }
}
