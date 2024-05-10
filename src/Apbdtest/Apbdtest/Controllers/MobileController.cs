using Microsoft.AspNetCore.Mvc;
using ApbdTest.Models;
using ApbdTest.Services;

namespace ApbdTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MobileController : ControllerBase
    {
        private readonly MobileService _mobileService;

        public MobileController(MobileService mobileService)
        {
            _mobileService = mobileService; // Dependency injection
        }

        [HttpPost]
        public IActionResult CreateOrUpdateClient([FromBody] Client clientData)
        {
            var response = _mobileService.CreateOrUpdateClient(clientData);
            return Ok(response);
        }

        [HttpGet("{mobileNumber}")]
        public IActionResult GetClientByMobileNumber(string mobileNumber)
        {
            var response = _mobileService.GetClientByMobileNumber(mobileNumber);
            if (response == null)
                return NotFound();
            return Ok(response);
        }

        [HttpDelete("{mobileNumber}")]
        public IActionResult DeleteClientByMobileNumber(string mobileNumber)
        {
            var response = _mobileService.DeleteClientByMobileNumber(mobileNumber);
            if (!response)
                return NotFound();
            return Ok();
        }
    }
}