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
        public void CodeValidationReturnRightCodeMessage()
        {
            string code = "50809087054";
            var rightCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.NotNull(rightCodeMessage);
            Assert.Equal("Sisestatud isikukood on õige", rightCodeMessage);
        }

        [Fact]
        public void CodeValidationReturnWrongCodeMessage()
        {
            string code = "50809087055";
            string wrongCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Sisestatud isikukood on vigane!", wrongCodeMessage);

        }
        [Fact]
        public void CodeValidationReturnCodeNotPresentMessage()
        {
            string code = "";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Kood on puudu", checkedCodeMessage);

        }

        [Fact]
        public void CodeValidationCodeHasCorrectLength()
        {
            string code = "50607167024";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.True(code.Length == 11);

        }
        [Fact]
        public void CodeValidationCodeLengthNotValid()
        {
            string code = "5060716702";
            string checkedCodeMessage = PersonalCodeValidationService.ValidationResultMessage(code);
            Assert.Equal("Sisestatud isikukoodi pikkus on vale", checkedCodeMessage);

        }

    }
}
