﻿using ConsoleApp1.Helper;
using ConsoleApp1.LoginApp.Registrie;
using ConsoleApp1.LoginApp.UserMethoden;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace ConsoleAppTest
{
    [TestClass]
    public class UserSurfaceTest
    {

        //[TestMethod]
        //public void UserSurface_InitialzeStart_CheckEnterKeyTest()
        //{
        //    //arrange
        //    var consoleHelperMock = new Mock<IConsoleHelper>();
        //    var userServiceMock = new Mock<IUserService>();
        //    var userOptionsMock = new Mock<IUserOptions>();
        //    var sequence = new MockSequence();
        //    consoleHelperMock.InSequence(sequence).Setup(o => o.ReadKey()).Returns(new ConsoleKeyInfo('\r', ConsoleKey.Enter, false, false, false));
        //    consoleHelperMock.InSequence(sequence).Setup(o => o.ReadKey()).Returns(new ConsoleKeyInfo('N', ConsoleKey.N, false, false, false));
        //    userOptionsMock.Setup(o => o.OptionSelector()).Returns(EnumOptions.Options.NeuerUserRegestrieren);
        //    UserInterfaceAccessor userSurface = new UserInterfaceAccessor(consoleHelperMock.Object, userServiceMock.Object, userOptionsMock.Object);

        //    //act

        //    userSurface.PublicInitializeStart();


        //    //assert
        //   // userServiceMock.Verify(o => o.CreateUser(It.IsAny<List<User>>()), Times.Once);
        //}

        //private class UserInterfaceAccessor : LtExecuter
        //{
        //    public UserInterfaceAccessor(IConsoleHelper consoleHelper, IUserService userService, IUserOptions userOptions) 
        //        : base(consoleHelper, userService, userOptions)
        //    {
        //    }

          
        //    public void PublicInitializeStart()
        //    {
        //        base.InitializeStart();
        //    }
        //}
    }
}
