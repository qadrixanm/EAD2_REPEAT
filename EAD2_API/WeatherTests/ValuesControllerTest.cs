//Kadrieh Mohamadzadeh - X00114185
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EAD2_Repeat.Controllers;
using EAD2_Repeat;
using EAD2_Repeat.Models;
using System.Net.Http;
using System.Web.Mvc;

namespace WeatherTests
{
    [TestClass]
    public class ValuesControllerTest
    {
        
        [TestMethod]
        public void GetValueById()
        {
            ValuesController con = new ValuesController();

            string result = con.Get(5);
            //should pass
            Assert.AreEqual("value", result);
            //should fail
            //Assert.AreEqual("Value", result);
        }

        [TestMethod]
        public void Post()
        {
            ValuesController con = new ValuesController();

            con.Post("value");

        }

        [TestMethod]
        public void Put()
        {
            ValuesController con = new ValuesController();

            con.Put(5, "value");

        }

        [TestMethod]
        public void Delete()
        {
            ValuesController con = new ValuesController();

            con.Delete(5);

        }
    }
}
