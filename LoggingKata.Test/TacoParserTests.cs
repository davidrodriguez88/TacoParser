using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", -85.499655)]
        [InlineData("33.524131, -86.724876, Taco Bell Birmingham...",  -86.724876)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            //Arrange - Write the code we need in order to call the method we're testing.
            var tacoParserLong = new TacoParser();
            //Act
            var actual = tacoParserLong.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Longitude);
        }
        
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        [InlineData("32.571331, -85.499655, Taco Bell Auburn...", 32.571331)]
        [InlineData("33.524131, -86.724876, Taco Bell Birmingham...",  33.524131)]
        public void ShouldParseLatitude(string line, double expected)
        {
            //Arrange
            var tacoParserLat = new TacoParser();
            //Act
            var actual = tacoParserLat.Parse(line);
            //Assert
            Assert.Equal(expected, actual.Location.Latitude);
        }

    }
}
