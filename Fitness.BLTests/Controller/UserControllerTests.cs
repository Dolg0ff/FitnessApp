using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fitness.BL.Model;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var gender = "man";
            var birthDate = DateTime.Now.AddYears(-18);
            var weight = 1;
            var height = 1;
            var controller = new UserController(userName);

            //Act

            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            //Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //Правило трех AAA

            //Arrange (Данные)
            var userName = Guid.NewGuid().ToString();

            //Act (Действие)
            var controller = new UserController(userName);

            //Assert (Проверка) 
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}