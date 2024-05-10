using System.Web.Http;
using ApbdTest.Models;
using ApbdTest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApbdTest.Controllers
{
    public class MobileController : ApiController
    {
        private MobileService _mobileService = new MobileService();

        [HttpPost]
        [Route("api/mobile")]
        public IHttpActionResult CreateOrUpdateClient([FromBody] Client clientData)
        {
            var response = _mobileService.CreateOrUpdateClient(clientData);
            return Ok(response);
        }

        [HttpGet]
        [Route("api/mobile")]
        public IHttpActionResult GetClientByMobileNumber(string mobileNumber)
        {
            var response = _mobileService.GetClientByMobileNumber(mobileNumber);
            if (response == null) return NotFound();
            return Ok(response);
        }

        [HttpDelete]
        [Route("api/mobile")]
        public IHttpActionResult DeleteClientByMobileNumber(string mobileNumber)
        {
            var response = _mobileService.DeleteClientByMobileNumber(mobileNumber);
            if (!response) return NotFound();
            return Ok();
        }
    }
}