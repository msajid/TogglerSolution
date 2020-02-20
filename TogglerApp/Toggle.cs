using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;

namespace TogglerApp
{
    [JsonObject(MemberSerialization.OptIn)]
    public partial class Toggle
    {
        [JsonProperty("state")]
        public bool State { get; set; }

        public void ToggleState()
        {
            State = !State;
        }
        
    }

    public partial class Toggle
    {
        [FunctionName(nameof(Toggle))]
        public Task Run([EntityTrigger] IDurableEntityContext ctx)
            => ctx.DispatchAsync<Toggle>();
    }
}
