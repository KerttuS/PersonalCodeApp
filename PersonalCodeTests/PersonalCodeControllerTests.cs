using Moq;
using PersonalCodeApi;
using PersonalCodeApi.Controllers;
using PersonalCodeApi.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PersonalCodeTests
{
    public class PersonalCodeControllerTests
    {
        
        private readonly PersonalCodeController _controller;
        
        private readonly IDataContext _context;
       
        
        [Fact]
        public void GetAll_PersonalCodesFromDb_NotNull()
        {
            var newCont = new PersonalCodeController(_context);
            Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<PersonalCode>>>? result = newCont.GetAll();
            Assert.NotNull(result); 
     
        }
        [Fact]
        public async Task Post_PersonalCodeToDb_RightCode()
        {
            var newCont = new PersonalCodeController(_context);
            string persCode = "48002010222";
           

            var result = await newCont.PostCode(persCode);

            Assert.NotNull(result);



        }


    }
}