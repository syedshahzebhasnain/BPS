using BPSTakeHome.Domain.Models;
using Newtonsoft.Json;
using System;

namespace BPSTakeHome.Application.ViewModel
{
    public class EmployeeViewModel
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("fullName")]
        public string FullName { get; set; }
        [JsonProperty("address")]
        public string Address { get; set; }
        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }
        [JsonProperty("positionId")]
        public int PositionId { get; set; }
    }
}
