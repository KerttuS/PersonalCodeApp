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

            return Ok(await _context.PersonalCodes.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<PersonalCode>>> ValidateCode(PersonalCode personCode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = new PersonalCode();
            data.Code = personCode.Code;
            data.ErrorMessage = personCode.ErrorMessage;

            var checkedCode = CheckCodeValidity(data.Code);
            
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
               codeErrorResult.ErrorMessage = "Kood on puudu";

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
                    codeErrorResult.ErrorMessage = "Vale number isikukoodi jaoks" + inputCode;
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