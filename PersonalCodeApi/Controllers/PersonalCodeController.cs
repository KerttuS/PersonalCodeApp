using Microsoft.AspNetCore.Mvc;

namespace PersonalCodeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonalCodeController : ControllerBase
    {
        public PersonalCodeController(DataContext context)
        {
            _context = context;
        }
        private readonly DataContext _context;

        [RequireHttps]
        [HttpGet]
        public async Task<ActionResult<List<PersonalCode>>> Get()
        {
            
            try
            {
                return Ok(await _context.PersonalCodes.ToListAsync());
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPost]
        public async Task<ActionResult<PersonalCode>> PostCode(PersonalCode personalCode)
        {
            try
            {
                if (personalCode == null)
                {
                    return NotFound();
                }

                PersonalCode? checkCodeIsValid = CheckCodeValidity(personalCode);

                 _context.PersonalCodes.Add(checkCodeIsValid);
                 await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Get), new { personalCode = checkCodeIsValid}, personalCode);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving data");
            }
            
        }


        private static PersonalCode CheckCodeValidity(PersonalCode inputCode)
        {
            inputCode.ErrorMessage = "";
            string? code = inputCode.Code;

            if (string.IsNullOrEmpty(code))
            {
                throw new ArgumentNullException(inputCode.ErrorMessage = "Kood on puudu või vale");
                
            }
            else
            {
                char[]? codeToCheck = code.ToCharArray();
                int sex = Convert.ToInt32(code.Substring(0, 1));
                int month = Convert.ToInt32(code.Substring(3, 2));
                int day = Convert.ToInt32(code.Substring(5, 2));
                int lastNum = Convert.ToInt32(code.Substring(10, 1));


                int checkSum = getCheckSum(codeToCheck);


                if (sex >= 3 && sex <= 6 && month >= 1 && month <= 12 && day >= 1 && day <= 31 && lastNum == checkSum)
                {
                    inputCode.ErrorMessage = "Kood on õige";
                
                }
                else
                {
                    inputCode.ErrorMessage = "Sellist isikukoodi ei eksisteeri";
                    
                }
            }
            return inputCode;

        }

        private static int getCheckSum(char[] code)
        {
            List<int> weight = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            List<int> weight2 = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            int[] codeSequence = code.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            IEnumerable<int>? calculatedWeight1 = (weight.Select((x, index) => x * codeSequence[index]));
            int controlSum1 = calculatedWeight1.Sum();
            int sum1 = controlSum1 % 11;
            
            if (sum1 == 10)
            {
                IEnumerable<int>? calculatedWeight2 = (weight2.Select((x, index) => x * codeSequence[index]));
                int controlSum2 = calculatedWeight2.Sum();
                int sum2 = controlSum2 % 11;
            
                
                if (sum2 == 10)
                {
                    sum2 = 0;
                }
                return sum2;
            }
            else
            {
                return sum1;
            }
           

        }
    }
}