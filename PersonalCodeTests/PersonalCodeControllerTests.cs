using Microsoft.EntityFrameworkCore;
using Moq;
using PersonalCodeApi;
using PersonalCodeApi.Controllers;
using PersonalCodeApi.Data;
using PersonalCodeApi.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PersonalCodeTests
{
    public class PersonalCodeControllerTests
    {
        private readonly PersonalCodeController _controller;    
        private readonly Mock<IDataContext> _contextTest = new Mock<IDataContext>();
        
        public PersonalCodeControllerTests(IDataContext context) 
        {

            _controller = new PersonalCodeController(context);
        }


        //[Fact]
        //public async void GetAllPersonalCodes_FromDb_NotNull()
        //{
        //    //Arrange
        //    var personalCode = new List<PersonalCode> 
        //    {
        //        new PersonalCode
        //        {
        //            Code = "45896235651",
        //            Message = "Sisestatud kood on vigane",
        //        },
        //        new PersonalCode
        //        {
        //            Code = "35896235651",
        //            Message = "Sisestatud kood on vigane",
        //        }

        //    };
        //    // Act

        //    Microsoft.AspNetCore.Mvc.ActionResult<List<PersonalCode>>? result = await _controller.GetAll();

        //    //Assert
        //    Assert.Equal(personalCode, result);
        //}
        //[Fact]
        //public void Post_PersonalCodeToDb_ValidCode()
        //{
          
        //    string persCode = "48002010222";

        //    var result = _controller.PostCode(persCode);

        //    Assert.NotNull(result);
        //}

       

    }
}