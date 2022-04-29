using Microsoft.EntityFrameworkCore;
using Moq;
using PersonalCodeApi;
using PersonalCodeApi.Controllers;
using PersonalCodeApi.Data;
using PersonalCodeApi.Services;
using System;
using Xunit;

namespace PersonalCodeTests
{
    public class PersonalCodeControllerTests
    {
        
     
        //[Fact]
        //public async void GetAll_PersonalCodesFromDb_NotEmpty()
        //{

        //    var newCont = new PersonalCodeController();
        //    Assert.NotNull(newCont);

        //    Microsoft.AspNetCore.Mvc.ActionResult<List<PersonalCode>>? result = await newCont.GetAll();
        //    Assert.NotEmpty(result.Value);
        //}
        //[Fact]
        //public void Post_PersonalCodeToDb_RightCode()
        //{
        //    var newCont = new PersonalCodeController();
        //    string persCode = "48002010222";


        //    var result = newCont.PostCode(persCode);

        //    Assert.NotNull(result);
        //}

        [Fact]
        public void CodeValidation_ValidationService_RightCodeMessage()
        {
            string code = "50809087054";
            var rightCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.NotNull(rightCodeMessage);   
            Assert.Equal("Sisestatud isikukood on õige", rightCodeMessage);
        }

        [Fact]
        public void CodeValidation_ValidationService_WrongCodeMessage()
        {
            string code = "50809087055";
            string rightCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Sisestatud isikukood on vigane!", rightCodeMessage);  

        }
        [Fact]
        public void CodeValidation_ValidationService_CodeNotPresentMessage()
        {
            string code = "";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Kood on puudu", checkedCodeMessage);

        }

        [Fact]
        public void CodeValidationLength_ValidationService_CodeCorrectLength()
        {
            string code = "50607167024";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.True(code.Length == 11);

        }
        [Fact]
        public void CodeValidationLength_ValidationService_CodeLengthNotValid()
        {
            string code = "5060716702";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Sisestatud isikukoodi pikkus on vale", checkedCodeMessage);
            
        }
        

    }
}