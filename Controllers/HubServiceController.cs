using Microsoft.AspNetCore.Mvc;
using SignalRPro.HubServices;
namespace SignalRPro.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class HubServiceController(HubService hubService): ControllerBase
    {
        [HttpGet("GetMembers/{groupName}")]
        public IActionResult GetMember(string groupName) => Ok(hubService.GetMembers(groupName));

        [HttpGet("availableGroups")]
        public IActionResult GetAvailableGroups() => Ok(hubService.GetAvailableGroups());

        [HttpGet("GetUserGroupName/{connectionId}")]
        public IActionResult GetUserGroupName(string connectionId) => Ok(hubService.GetUserGroupName(connectionId));
    }
}
