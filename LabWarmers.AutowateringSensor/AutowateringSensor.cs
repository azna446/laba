using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWarmers.SensorBase;

namespace LabWarmers.AutowateringSensor
{
    // This sensor only has boolean value: true or false.
    // It turns autowatering on or off depending on the time of the day
    class AutowateringSensor : SensorBase<bool>
    {
        protected override bool GetResult()
        {
            var timeOfDay = DateTime.Now.TimeOfDay;
            var hours = timeOfDay.Hours;

            switch (hours)
            {
                case >= 12 and <= 14:
                case >= 4 and <= 6:
                case >= 18 and <= 20:
                    return true;
                default:
                    return false;
            }
        }

        protected override string SensorName => "AutowateringSensor";
        public override TimeSpan TimeBetweenFetches => TimeSpan.FromMinutes(1);
    }
}
