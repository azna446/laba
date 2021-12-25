using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWarmers.Common
{
    public class SensorDataRequest
    {
        public SensorDataRequest(
            string name, 
            DateTime timeStamp, 
            object data)
        {
            Name = name;
            TimeStamp = timeStamp;
            Data = data;
        }

        public string Name { get; }
        public DateTime TimeStamp { get; }
        public object Data { get; }
    }
}
