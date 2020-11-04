using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestApiAutomation.Models;
using System.Net;

namespace RestApiAutomation.Tests
{
    [TestFixture]
    [AllureSuite("People")]
    [AllureNUnit]
    public class PeopleAPITests : BaseAPITests
    {
        [Test]
        public void TestGetPeoplePositive()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = Rest.Get<People>();
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestGetPersonPositive()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = Rest.Get<People>(3);
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }
    }
}
