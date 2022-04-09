using Microsoft.AspNetCore.Mvc;

namespace PersonalCodeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonalCodeController : ControllerBase
    {
        private static readonly string[] ErrorMessages = new[]
        {
        "This", "That", "Too long", "Too much", "noot right", "example", "hiii", "testing"
    };

        private readonly ILogger<PersonalCodeController> _logger;

        public PersonalCodeController(ILogger<PersonalCodeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetCodeWithError")]
        public IEnumerable<PersonalCode> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new PersonalCode
            {
                ErrorMessage = ErrorMessages[Random.Shared.Next(ErrorMessages.Length)]
            })
            .ToArray();
        }
    }
}