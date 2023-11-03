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

        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void När_RäknaTotalBelopp_EjImplementerad_Then_ShouldThrow_NotImplementedException()
        {
            // Arrange
            string tullStationPasseringar = "exempelTest";

            // Act
            SkattKalkylator.RäknaTotalBelopp(tullStationPasseringar);

            // Testet kommer att bli grönt då ett NotImplementedException kastas
        }
    }
}