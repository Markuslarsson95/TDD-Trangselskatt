using Trängselskatt_Gbg;

namespace TrängselskattTest
{
    [TestClass]
    public class SkattKalkylatorTests
    {
        [TestMethod]
        public void When_GivenX_Then_DoesY()
        {
            // Arrange
            // Act
            // Assert
        }

        //[TestMethod]
        //[ExpectedException(typeof(NotImplementedException))]
        //public void När_RäknaTotalBelopp_EjImplementerad_Then_ShouldThrow_NotImplementedException()
        //{
        //    // Arrange
        //    string tullStationPasseringarList = "exempelTest";

        //    // Act
        //    SkattKalkylator.RäknaTotalBelopp(tullStationPasseringarList);

        //    // Testet kommer att bli grönt då ett NotImplementedException kastas
        //}

        [TestMethod]
        [DynamicData(nameof(MyDates))]
        public void När_PasseringMellanIntervall(IEnumerable<string> tullStationPasseringarList, string förväntadAvgift)
        {
            //Arrange
            //string tullStationPasseringar = "2023-11-15 06:10:27";

            //Act
            string kostnad = SkattKalkylator.RäknaTotalBelopp(tullStationPasseringarList);

            //Assert
            Assert.AreEqual(förväntadAvgift, kostnad);
        }

        public static IEnumerable<object[]> MyDates => new[]
        {
              new object[] { new List<string> { "2023-11-15 06:10:27" }, "Den totala avgiften är 8kr" },
              new object[] { new List<string> { "2023-11-15 10:10:27" }, "Den totala avgiften är 8kr" },
              new object[] { new List<string> { "2023-11-15 06:10:27", "2023-11-15 10:10:27", "2023-11-15 07:17:13" }, "Den totala avgiften är 34kr" },
              new object[] { new List<string> { "2023-05-31 07:00", "2023-05-31 07:10", "2023-05-31 07:20", "2023-05-31 07:30" }, "Den totala avgiften är 60kr" },
              new object[] { new List<string> { "2023-06-03" }, "Den totala avgiften är 0kr(lördag)" },
              new object[] { new List<string> { "2023-06-04" }, "Den totala avgiften är 0kr(söndag)" },
              new object[] { new List<string> { "2023-07-01" }, "Den totala avgiften är 0kr(juli månad)" },
        };
    }
}