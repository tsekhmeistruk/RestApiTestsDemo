using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestApiAutomation.Models;
using System;
using System.Net;

namespace RestApiAutomation.Tests
{
    [TestFixture]
    [AllureSuite("Planets")]
    [AllureNUnit]
    public class PlanetsAPITests : BaseAPITests
    {
        [Test]
        public void TestGetPlanetsPositive()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = RestAdapter.Get<Planets>();
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestGetPlanetPositive()
        {
            var count = ((ResponseDataModel<Planets>)RestAdapter.Get<Planets>().Results).Count;
            var randomId = new Random().Next(1, Convert.ToInt32(count));
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = RestAdapter.Get<Planets>(randomId);
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestGetPersonNegative()
        {
            var count = ((ResponseDataModel<Planets>)RestAdapter.Get<Planets>().Results).Count;
            Assert.Throws<WebException>(() => RestAdapter.Get<Planets>(Convert.ToInt32(count + 2)));
        }
    }
}
