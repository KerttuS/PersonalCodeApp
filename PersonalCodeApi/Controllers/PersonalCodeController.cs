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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<PersonalCode>>> ValidateCode(string personCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            PersonalCode checkedCode = CheckCodeValidity(personCode);
            
            if (checkedCode == null)
            {
                return BadRequest();
            }
            else
            {
                _context.PersonalCodes.Add(checkedCode);
                await _context.SaveChangesAsync();

                return Ok(await _context.PersonalCodes.ToListAsync());
            }


        }
        private static PersonalCode CheckCodeValidity(string inputCode)
        {
            var codeErrorResult = new PersonalCode();

            if (string.IsNullOrEmpty(inputCode))
            {
                throw new ArgumentNullException("Code");
            }
            else
            {
                char[]? codeToCheck = inputCode.ToCharArray();
                var sex = Convert.ToInt32(inputCode.Substring(0, 1));
                var month = Convert.ToInt32(inputCode.Substring(3, 2));
                var day = Convert.ToInt32(inputCode.Substring(5, 2));
                var checkSum = Convert.ToInt32(inputCode.Substring(10, 1));

                if (sex >= 3 && sex <= 6 && month >= 1 && month <= 12 && day >= 1 && day <= 31 && checkSum == getCheckSum(codeToCheck))
                {  
                    codeErrorResult.ErrorMessage = "Kood on õige";
                    codeErrorResult.Code = inputCode;
                }
                else
                {     
                    codeErrorResult.ErrorMessage = "Sellist isikukoodi ei eksisteeri";
                    codeErrorResult.Code = inputCode;
                }
            }
            return codeErrorResult;   
            
        }

        private static int getCheckSum(char[] code)
        {
            List<int> weight = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            
            int[] codeSequence = code.Select(c => Convert.ToInt32(c.ToString())).ToArray();

            IEnumerable<int>? calculateWeight = (weight.Select((x, index) => x * codeSequence[index]));
            
            int controlSum = calculateWeight.Sum();
   
            int sum = controlSum % 11;

            return sum;
        }
    }
}