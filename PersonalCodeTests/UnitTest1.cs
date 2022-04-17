using Moq;
using PersonalCodeApi;
using PersonalCodeApi.Controllers;
using PersonalCodeApi.Data;
using System.Collections.Generic;
using Xunit;

namespace PersonalCodeTests
{
    public class PersonalCodeControllerTests
    {

        private readonly Mock<DataContext> _dataContextMock;
        private readonly PersonalCodeController _controller;


        public PersonalCodeControllerTests()
        {
            _dataContextMock = new Mock<DataContext>();
            _controller = new PersonalCodeController(_dataContextMock.Object);
        }

        [Fact]
        public void PersonalCodeFromDbNotNull()
        {
            PersonalCode personalCode = new PersonalCode()
            {
                Code = "12345678912",
                ErrorMessage = "Kood on vale"
            };

            _dataContextMock.Setup(repo => repo.Set<PersonalCode>());

            var result = _controller.GetAll();
            Assert.NotNull(result);

        }

        [Fact]
        public void PesonalCodeCheckReturnsOk()
        {
            PersonalCode personalCode = new PersonalCode()
            {
                Code = "35408200232",
            };


            _dataContextMock.Setup(repo => repo.Set<PersonalCode>());
            new Mock<DataContext>(new Mock<PersonalCode>().Object);

            var result = _controller.PostCode(personalCode.Code);
            Assert.NotNull(result);
            Assert.Equal(personalCode.ErrorMessage = "Kood on õige", (IEnumerable<char>)result);
        }
        [Fact]
        public void PesonalCodeNull_ReturnBadRequest()
        {
            string code = "";

            var result = _controller.PostCode(code);

            Assert.NotNull(result);

        }

    }
}