using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static PersonalCodeApi.Services.PersonalCodeValidationService;

namespace PersonalCodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalCodeController : ControllerBase
    {

        private readonly IDataContext _context;
        public PersonalCodeController(IDataContext context)
        {
            _context = context;
        }

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<PersonalCode>>> GetAll()
        {
            List<PersonalCode>? result = await _context.PersonalCodes.ToListAsync();

            if (result == null)
            {
                return NotFound();  
            }
            return Ok(result);  

        }

                                                                                    

        [HttpPost]
        public async Task<ActionResult> PostCode( [FromBody] PersonalCode personCode)
        {
           
            string personalCode = personCode.Code.ToString();

            try
            {
                if (personalCode == null)
                {
                    throw new NullReferenceException();
                }
                else
                {
                    string? message = ValidationResultMessage(personalCode);
                    PersonalCode personalCodeDb = new PersonalCode(); 
                    personalCodeDb.Code = personalCode; 
                    personalCodeDb.Message = message;

                    _context.Add(personalCodeDb);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetAll", new { id = personalCodeDb.Code }, message);
                }

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }

        }


    }
}