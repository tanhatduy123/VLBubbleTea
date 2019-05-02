using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using ProjectMyself.Controllers;
using System.Web.Mvc;
using ProjectMyself.Models;
using System.Collections.Generic;

namespace ProjectMyself.Tests.Controllers
{
    [TestClass]
    public class BubleTeasControllerTest
    {
        [TestMethod]
        public void TestIndex()
        {
           
            BubleTeasController controller = new BubleTeasController();
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            var model = result.Model as List<BubleTea>;
            var db = new CS4PEEntities();
            Assert.IsNotNull(result);
            Assert.AreEqual(db.BubleTeas.Count(), model.Count());

        }

        [TestMethod]
        public void TestDetails()
        {
            var controller = new BubleTeasController();
            var result0 = controller.Details(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Details(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestCreateGet()
        {
            var controller = new BubleTeasController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestCreatePost()
        {
            var controller = new BubleTeasController();
            var model = new BubleTea
            {
                Name = "Tra Sua Vi Cam",
                Price = 50000,
                Topping = "Tran Chau Cam"
            };

            var db = new CS4PEEntities();
            var item = db.BubleTeas.Find(model.id);
            Assert.IsNotNull(item);

            Assert.AreEqual(model.Name, item.Name);
            Assert.AreEqual(model.Price, item.Price);
            Assert.AreEqual(model.Topping, item.Topping);
            var result = controller.Create(model);
            var redirect = result as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);
        }

        [TestMethod]
        public void TestEditGet()
        {
            var controller = new BubleTeasController();
            var result0 = controller.Edit(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestEditPost()
        {
            var controller = new BubleTeasController();
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Edit(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            var result = controller.Edit(model);
            var redirect = result as RedirectToRouteResult;
            Assert.IsNotNull(redirect);
            Assert.AreEqual("Index", redirect.RouteValues["action"]);

        }

        [TestMethod]
        public void TestDeleteGet()
        {
            var controller = new BubleTeasController();
            var result0 = controller.Delete(0);
            Assert.IsInstanceOfType(result0, typeof(HttpNotFoundResult));
            var db = new CS4PEEntities();
            var item = db.BubleTeas.First();
            var result1 = controller.Delete(item.id) as ViewResult;
            Assert.IsNotNull(result1);
            var model = result1.Model as BubleTea;
            Assert.IsNotNull(model);
            Assert.AreEqual(item.id, model.id);

        }

        [TestMethod]
        public void TestDeletePost()
        {

        }
    }
}
