using Newtonsoft.Json;
using RoofStacksAuthGuardCase.EmployeeService.Common;

namespace RoofStacksAuthGuardCase.EmployeeService.DTOs
{
    public class EmployeeDto
    {
        [JsonProperty(PropertyName = "id", Order = 6)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "firstName", Order = 6)]
        public string FirstName { get; set; }

        [JsonProperty(PropertyName = "lastName", Order = 6)]
        public string LastName { get; set; }

        [JsonProperty(PropertyName = "gender", Order = 6)]
        public Gender Gender { get; set; }
    }
}
