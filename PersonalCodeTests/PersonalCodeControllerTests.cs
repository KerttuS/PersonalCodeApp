using DevExpress.Entity.Model.Metadata;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IDataContext _context;
        private readonly PersonalCodeController _controller;


        public PersonalCodeControllerTests()
        {
            
            var options = new DbContextOptionsBuilder<IDataContext>().UseInMemoryDatabase(databaseName: "TestDb").Options;
            _context = new IDataContext(options);
           
            _controller = new PersonalCodeController(_context);
    
        }

        [Fact]
        public async Task GetAllPersonalCodes_FromDb_NotNull()
        {
             
            _context.PersonalCodes.Add(new PersonalCode()
            { Code = "48002010222", Message = "Sisestatud kood on õige" });
            _context.PersonalCodes.Add(new PersonalCode()
            { Code = "48002010245", Message = "Sisestatud kood on vigane" });
            _context.SaveChanges();

            ActionResult<List<PersonalCode>>? actionResult = await _controller.GetAll();
            ObjectResult? result = (ObjectResult)actionResult.Result;
            
            Assert.NotNull(result.Value);
        }

        [Fact]
        public async Task GetAllPersonalCodes_FromDb_Null()
        {
           ActionResult<List<PersonalCode>>? actionResult = await _controller.GetAll();
           var result = (ObjectResult)actionResult.Result;

           Assert.Empty((System.Collections.IEnumerable)result.Value);
           Assert.Equal(200, result.StatusCode.GetValueOrDefault());
        }

        [Fact]
        public async Task Post_PersonalCodeToDb_ValidCode()
        {
       
            PersonalCode persCode = new PersonalCode{ Code="35408200232" };
            ActionResult? actionResult = await _controller.PostCode(persCode);
            var result = (ObjectResult)actionResult;
            
            Assert.NotNull(result.Value);
            Assert.Equal("Sisestatud isikukood on õige", result.Value);
                       
        }



    }
}