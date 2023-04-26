using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;
using ConsoleApp1.LoginApp.UserMethoden.UserInformation;
using Moq;

namespace ConsoleAppTest
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateUser_Test()
        {
            //arrange
            List<User> userList = new List<User>();
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            registringMock.Setup(o => o.RegistryName()).Returns("bla");
            registringMock.Setup(o => o.RegistryPassword()).Returns(124);

            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);

            //act
            userService.CreateUser(userList);

            //assert
            Assert.AreEqual(1, userList.Count);
            Assert.AreEqual("bla", userList[0].GetUserName());
            Assert.AreEqual(124, userList[0].GetPassword());

            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Sie haben sich erfolgreich registriert")));


        }
        [TestMethod]
        public void CreateUser_CreateUser_ConsolerHelperTest()
        {
            //arrange
            List<User> userList = new List<User>();
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            registringMock.Setup(o => o.RegistryName()).Returns("bla");
            registringMock.Setup(o => o.RegistryPassword()).Returns(124);
            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);

            //act
            userService.LoginUser(userList);

            //assert
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben Sie ihren Username ein")));

        }
        [TestMethod]
        public void FindUser_UserNotFound_Test()
        {
            //arrange
            List<User> userList = new List<User>()
            {
                new User(new UserProperties("test1", 123))
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            registringMock.Setup(o => o.RegistryName()).Returns("bla");
            registringMock.Setup(o => o.RegistryPassword()).Returns(124);
            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);
            //UserService.F

            //act
            var result = userService.FindUser(userList);

            //assert
            Assert.IsNull(result);
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Dieser User exestiert nicht")));
        }

        [TestMethod]
        public void FindUser_UserFound_Test()
        {
            //arrange
            List<User> userList = new List<User>()
            {
                new User(new UserProperties("test1", 123))
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);
            consoleHelperMock.Setup(o => o.ReadInput()).Returns("test1");

            //act
            var result = userService.FindUser(userList);

            //assert
            Assert.AreEqual(result.GetUserName(), consoleHelperMock.Object.ReadInput());
        }

        [TestMethod]
        public void LoginUser_IsUserNUll_Test()
        {
            //arrange
            List<User> userList = new List<User>();
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);

            //act
            var result = userService.LoginUser(userList);

            //assert
            Assert.IsFalse(result);
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben Sie ihren Username ein")), Times.Once);
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche")), Times.Never);
        }
        [TestMethod]
        public void LoginUser_CheckPassword_Test()
        {
            //arrange
            List<User> userlist = new List<User>()
            {
                new User(new UserProperties("test1", 123))
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            UserService userService = new UserService(registringMock.Object, consoleHelperMock.Object);
            consoleHelperMock.Setup(o => o.ReadInput()).Returns("test1");
            consoleHelperMock.Setup(o => o.IntConvertor_String(It.IsAny<string>())).Returns(123);
            

            //act
            bool result = userService.LoginUser(userlist);

            //assert
            Assert.IsTrue(result);
            
        }
    }
}