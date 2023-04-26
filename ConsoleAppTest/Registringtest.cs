using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;
using Moq;

namespace ConsoleAppTest
{
    [TestClass]
    public class Registringtest
    {
        [TestMethod]
        public void Registring_RegistringName_NullorewhiteSpaceTest()
        {

            //arrange
            var consolHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            Registring registring = new Registring(consolHelperMock.Object);
            var sequence = new MockSequence();
            consolHelperMock.InSequence(sequence).Setup(o =>o.ReadInput()).Returns(" ");
            consolHelperMock.InSequence(sequence).Setup(o => o.ReadInput()).Returns("name");

            //act
            var result = registring.RegistryName();

            //assert
            Assert.AreEqual("name",result);
        }
        [TestMethod]
        public void Registring_RegistringName_TryparseTest()
        {

            //arrange
            var consolHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            Registring registring = new Registring(consolHelperMock.Object);
            var sequence = new MockSequence();
            consolHelperMock.InSequence(sequence).Setup(o => o.ReadInput()).Returns("1");
            consolHelperMock.InSequence(sequence).Setup(o => o.ReadInput()).Returns("name");

            //act
            var result = registring.RegistryName();

            //assert
            Assert.AreEqual("name", result);
        }
        [TestMethod]
        public void Registring_RegistringPassword_PassswordisNotNUllTest()
        {

            //arrange
            var consolHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            Registring registring = new Registring(consolHelperMock.Object);
            var sequence = new MockSequence();
            consolHelperMock.InSequence(sequence).Setup(o => o.ReadInput()).Returns(" ");
            consolHelperMock.InSequence(sequence).Setup(o => o.ReadInput()).Returns("12");

            //act
            var result = registring.RegistryPassword();

            //assert
            Assert.IsNotNull(result);
        }
    }
}
