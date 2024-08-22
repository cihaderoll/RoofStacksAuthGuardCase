using Newtonsoft.Json;

namespace RoofStacksAuthGuardCase.EmployeeService.DTOs
{
    public class ApiResult
    {
        /// <summary>
        /// Total Errors
        /// </summary>
        [JsonProperty(PropertyName = "errors", Order = 6)]
        public string[] Errors { get; set; }

        /// <summary>
        /// Response Status Code
        /// </summary>
        [JsonProperty(PropertyName = "statusCode", Order = 4)]
        public int StatusCode { get; set; } = 200;

        /// <summary>
        /// IsError
        /// </summary>
        [JsonProperty(PropertyName = "isError", Order = 3)]
        public bool IsError { get; set; }

        /// <summary>
        /// Generated Error Message
        /// </summary>
        [JsonProperty(PropertyName = "message", Order = 2)]
        public string? Message { get; set; }

        /// <summary>
        /// Generated Result
        /// </summary>
        [JsonProperty(PropertyName = "result", Order = 1)]
        public object Result { get; set; }
    }
}
