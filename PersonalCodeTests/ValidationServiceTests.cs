using PersonalCodeApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PersonalCodeTests
{
    public class ValidationServiceTests
    {
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
            string wrongCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Sisestatud isikukood on vigane!", wrongCodeMessage);

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
