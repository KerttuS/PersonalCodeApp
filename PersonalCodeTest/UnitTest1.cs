using PersonalCodeApi.Controllers;
using System.Collections.Generic;
using Xunit;


namespace PersonalCodeTest
{
    public class UnitTest1
    {
        [Fact]
        public void ValidCheckSum()
        {
            //Arrange

            
            PersonalCode personCode = new PersonalCode();
            personCode.Code = "35408200232";

            //Act
            
            //Assert
            Assert.True(isValid, $"The password {password} is not valid");

        }
    }
}