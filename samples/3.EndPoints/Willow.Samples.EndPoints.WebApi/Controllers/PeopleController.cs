using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Willow.Samples.Core.Domain.People.ValueObjects;

namespace Willow.Samples.EndPoints.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        [HttpGet("CheckValueObject")]
        public IActionResult CheckFirstNameValueObject(string firstName)
        {
            FirstName fname1 = new(firstName);
            FirstName fname2 = new(firstName);
            return Ok(fname1 == fname2);
        }

        [HttpGet("ExceptionCheck")]
        public IActionResult CheckFirstNameException()
        {
            try
            {
                FirstName fname = new("a");
            }
            catch (InvalidValueObjectStateException ex)
            {
                return Ok(ex.ToString());
            }
            return BadRequest();
        }
    }
}
