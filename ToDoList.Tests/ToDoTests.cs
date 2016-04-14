using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ToDoList.Controllers;
using ToDoList.Domain;
using ToDoList.Domain.Entities;
using ToDoList.Models;

namespace ToDoList.Tests
{
    [TestClass]
    public class ToDoTests
    {
        [TestMethod]
        public void Can_AddToDo()
        {
            // Организация (arrange)
            Mock<IToDoRepository> mock = new Mock<IToDoRepository>();
            mock.Setup(m => m.Records).Returns(new List<ToDoRecord>
            {
                new ToDoRecord { Id = new Guid(), Subject = "Task 1", Author = "Test"},
                new ToDoRecord { Id = new Guid(), Subject = "Task 2", Author = "Test"},
                new ToDoRecord { Id = new Guid(), Subject = "Task 3", Author = "Test"},
                new ToDoRecord { Id = new Guid(), Subject = "Task 4", Author = "Test"},
                new ToDoRecord { Id = new Guid(), Subject = "Task 5", Author = "Test"}
            });
            ToDoController controller = new ToDoController(mock.Object);
            //controller.pageSize = 3;

            // Действие (act)
            UserModel user = new UserModel() {Username = "Test"};
            controller.Add(user, "Task 6");

            // Утверждение (assert)
            List<ToDoRecord> records = (List<ToDoRecord>)controller.GetAllRecords(user).Model;
            Assert.IsTrue(records.Count == 6);
            Assert.AreEqual(records[0].Subject, "Task 1");
            Assert.AreEqual(records[5].Subject, "Task 5");
        }

        [TestMethod]
        public void DoneToDo()
        {
        }

        [TestMethod]
        public void DeleteToDo()
        {
        }

        [TestMethod]
        public void GetAllToDo()
        {
        }

        [TestMethod]
        public void GetOnlyDoneToDo()
        {
        }

        [TestMethod]
        public void GetOnlyUnfinishedToDo()
        {
        }
    }
}
