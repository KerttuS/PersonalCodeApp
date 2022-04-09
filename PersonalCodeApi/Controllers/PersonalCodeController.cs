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

            bool isValid = IsCodeValid(data.Code);

            if (!isValid)
            {
                return BadRequest();
                
            }
            else
            {

                _context.PersonalCodes.Add(personCode);
                await _context.SaveChangesAsync();

                return Ok(await _context.PersonalCodes.ToListAsync());
            }


        }
        private bool IsCodeValid(string inputCode)
        {

            if (string.IsNullOrEmpty(inputCode))
            {
                return false;
               
            }
            else
            {
                char[]? codeToCheck = inputCode.ToCharArray();
                Console.WriteLine("Kood: " + inputCode);
                var sex = Convert.ToInt32(inputCode.Substring(0, 1));
                var month = Convert.ToInt32(inputCode.Substring(3, 2));
                var day = Convert.ToInt32(inputCode.Substring(5, 2));
                var checkSum = Convert.ToInt32(inputCode.Substring(10, 1));

                if (sex >= 3 && sex <= 6 && month >= 1 && month <= 12 && day >= 1 && day <= 31 && checkSum == getCheckSum(Convert.ToInt64(inputCode)))
                {
                    return true;
                    Console.WriteLine("Sugu on õige");
                }

                else
                {
                    return false;
                  
                }
            }
        }

        private static int getCheckSum(Int64 code)
        {
            List<int>? weight1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            List<int> weight2 = new List<int>() { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };

            int controlSum = code.ToString()[0] * 1 +
                code.ToString()[1] * 2 +
                code.ToString()[2] * 3 +
                code.ToString()[3] * 4 +
                code.ToString()[4] * 5 +
                code.ToString()[5] * 6 +
                code.ToString()[6] * 7 +
                code.ToString()[7] * 8 +
                code.ToString()[8] * 9 +
                code.ToString()[9] * 1;  
               
            int sum = controlSum % 11;


            return sum;
        }
    }
}