using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestApiAutomation.Models;
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
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = RestAdapter.Get<Planets>();
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }
    }
}
