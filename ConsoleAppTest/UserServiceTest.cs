using ConsoleApp1.Config;
using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.Services.To_doListService;
using ConsoleApp1.LoginApp.Services.Weatherservices;
using ConsoleApp1.LoginApp.UserMethoden;
using LoginAppData;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SharedLibary;
using Dasync.Collections;

namespace ConsoleAppTest
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public async Task CreateUser_Test()
        {
            //arrange
            List<Account> userList = new ();
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            var weatherClientMock = new Mock<IWeatherClient>();
            var fileHelperMock = new Mock<IFileHelper>();
            var loginContextMock = new Mock<ILoginDataContext>();
            var toDoListMock = new Mock<IToDoList>();
            var config = new AppSettings();
            config.UsersFolderPath = "dfsdf";
            var userOptions =  UsersOptions.Admin;
            consoleHelperMock.Setup(o => o.ReadKey()).Returns(new ConsoleKeyInfo('J',ConsoleKey.J,false,false,false));
            fileHelperMock.Setup(o => o.WriteUserEntry(It.IsAny<Account>(),It.IsAny<string>())).Callback<Account, string>((account , path) => userList.Add(account));
            registringMock.Setup(o => o.RegistryName()).Returns("bla");
            registringMock.Setup(o => o.RegistryPassword()).Returns(124);

            UserService userService = new(registringMock.Object, consoleHelperMock.Object, weatherClientMock.Object, fileHelperMock.Object,config,loginContextMock.Object,toDoListMock.Object);

            //act
             await userService.CreateUser(userOptions);

            //assert
            Assert.AreEqual(1, userList.Count);
            Assert.AreEqual("bla", userList[0].Name);
            Assert.AreEqual(124, userList[0].Password);

            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "You have registring successfully")));
        }

        [TestMethod]
        public void CreateUser_CreateUser_ConsolerHelperTest()
        {
            //arrange
            List<Account> userList = new List<Account>()
            {
                new Account () {Name="hafa"},
                new Account () {Name="udhf"}
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            var weatherClientMock = new Mock<IWeatherClient>();
            var fileHelperMock = new Mock<IFileHelper>();
            var loginContextMock = new Mock<ILoginDataContext>();
            var toDoListMock = new Mock<IToDoList>();
            var config = new AppSettings();
            var path =  config.UsersFolderPath = "dsfd";
            registringMock.Setup(o => o.RegistryName()).Returns("bla");
            registringMock.Setup(o => o.RegistryPassword()).Returns(124);
            UserService userService = new (registringMock.Object, consoleHelperMock.Object, weatherClientMock.Object, fileHelperMock.Object,config,loginContextMock.Object,toDoListMock.Object);

            //act
            userService.LoginUser();

            //assert
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben Sie ihren Username ein")));
        }


        [TestMethod]
        public async Task FindUser_UserFound_Test()
        {
            //arrange
            List<Account> userList = new ()
            {
                new Account(){Name="name"}
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            var weatherClientMock = new Mock<IWeatherClient>();
            var fileHelperMock = new Mock<IFileHelper>();
            var loginContextMock = new Mock<ILoginDataContext>();
            var toDoListMock = new Mock<IToDoList>();
            var config = new AppSettings();
            var path = config.UsersFolderPath = "dsfd";
            UserService userService = new (registringMock.Object, consoleHelperMock.Object, weatherClientMock.Object, fileHelperMock.Object,config,loginContextMock.Object,toDoListMock.Object);
            consoleHelperMock.Setup(o => o.ReadInput()).Returns("name");

            //act
            var result = await userService.FindUser();

            //assert
            Assert.AreEqual("name", result?.Name);
        }

        [TestMethod]
        public async Task LoginUser_IsUserNUll_Test()
        {
            //arrange
            List<Account> userList = new List<Account>();
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            var weatherClientMock = new Mock<IWeatherClient>();
            var fileHelperMock = new Mock<IFileHelper>();
            var loginContextMock = new Mock<ILoginDataContext>();
            var toDoListMock = new Mock<IToDoList>();
            var config = new AppSettings();
            var path = config.UsersFolderPath = "dsfd";
            UserService userService = new (registringMock.Object, consoleHelperMock.Object, weatherClientMock.Object, fileHelperMock.Object,config,loginContextMock.Object,toDoListMock.Object);

            //act
            var result = await userService.LoginUser();

            //assert
            Assert.IsFalse(result);
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben Sie ihren Username ein")), Times.Once);
            consoleHelperMock.Verify(o => o.Printer(It.Is<string>(str => str == "Bitte geben sie Jetz ihr passwort ein\n Sie haben 3 versuche")), Times.Never);
        }
        [TestMethod]
        public async Task LoginUser_CheckPassword_Test()
        {
            //arrange
            List<Account> userlist = new List<Account>()
            {
                new Account () {Name="test1"}
            };
            var consoleHelperMock = new Mock<IConsoleHelper>();
            var registringMock = new Mock<IRegistring>();
            var weatherClientMock = new Mock<IWeatherClient>();
            var fileHelperMock = new Mock<IFileHelper>();
            var loginContextMock = new Mock<ILoginDataContext>();
            var toDoListMock = new Mock<IToDoList>();
            var config = new AppSettings();
            var path = config.UsersFolderPath = "dsfd";
            UserService userService = new (registringMock.Object, consoleHelperMock.Object, weatherClientMock.Object, fileHelperMock.Object, config, loginContextMock.Object, toDoListMock.Object);
            consoleHelperMock.Setup(o => o.ReadInput()).Returns("test1");
            consoleHelperMock.Setup(o => o.IntConvertor_String(It.IsAny<string>())).Returns(123);
            

            //act
            bool result = await userService.LoginUser();

            //assert
            Assert.IsTrue(result);
        }

    }
}