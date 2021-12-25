using System;

namespace LabWarmers.Common
{
    public class Configuration
    {
        public string GetServerUrl => "http://localhost:48717";
        public string GetSensorsEndpointUrl => GetServerUrl + "/api/sensors/save";
    }
}
