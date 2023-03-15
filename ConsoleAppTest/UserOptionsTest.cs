using Moq;
using ConsoleApp1.LoginApp.UserMethoden;
using ConsoleApp1.LoginApp.Registrie;

namespace ConsoleAppTest
{
    [TestClass]
    public class UserOptionsTest
    {
       

        [TestMethod]
        public void OptionsSelector_Switchoptions_Test1()
        {
           //arrange
            var useroptionsMock = new Mock<IUserOptions>();
            var consolerHelperMock = new Mock<IConsoleHelper>();
            UserOptions userOptions = new UserOptions(consolerHelperMock.Object);
            consolerHelperMock.Setup(o => o.IntConvertor_String(It.IsAny<string>())).Returns(0);
            var enumoptions = Options.ProgrammVerlassen;

            //act
            var result = userOptions.OptionSelector();
           
            //assert
            Assert.AreEqual(enumoptions, result);
        }
        [TestMethod]
        public void OptionsSelector_Switchoptions_Tes2t()
        {
            //arrange
            var useroptionsMock = new Mock<IUserOptions>();
            var consolerHelperMock = new Mock<IConsoleHelper>();
            UserOptions userOptions = new UserOptions(consolerHelperMock.Object);
            consolerHelperMock.Setup(o => o.IntConvertor_String(It.IsAny<string>())).Returns(2);
            var enumoptions = Options.Login;

            //act
            var result = userOptions.OptionSelector();

            //assert
            Assert.AreEqual(enumoptions, result);
        }
    }
}
