using Microsoft.AspNetCore.Mvc;
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
        public async Task<ActionResult> PostCode(string personalCode)
        {

            try
            {
                if (personalCode == null)
                {
                    return NotFound();
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