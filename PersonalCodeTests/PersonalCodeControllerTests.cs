using DevExpress.Entity.Model.Metadata;
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
        public void GetAllPersonalCodes_FromDb_NotNull()
        {
             
            _context.PersonalCodes.Add(new PersonalCode()
            { Code = "48002010222", Message = "Sisestatud kood on õige" });
            _context.PersonalCodes.Add(new PersonalCode()
            { Code = "48002010245", Message = "Sisestatud kood on vigane" });
            _context.SaveChanges();
            var result = _controller.GetAll();
            Assert.NotNull(result);
              
        }

        [Fact]
        public void Post_PersonalCodeToDb_ValidCode()
        {
       
            PersonalCode persCode = new PersonalCode{ Code="35408200232" };
            var result = _controller.PostCode(persCode);
            Assert.NotNull(result);
            
        }



    }
}