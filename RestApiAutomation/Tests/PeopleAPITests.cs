using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using RestApiAutomation.Models;
using System;
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
            var response = RestAdapter.Get<People>();
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestGetPersonPositive()
        {
            var count = ((ResponseDataModel<People>)RestAdapter.Get<People>().Results).Count;
            var randomId = new Random().Next(1, Convert.ToInt32(count));
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = RestAdapter.Get<People>(randomId);
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestGetPersonNegative()
        {
            var count = ((ResponseDataModel<People>)RestAdapter.Get<People>().Results).Count;
            Assert.Throws<System.Net.WebException>(()=> RestAdapter.Get<People>(Convert.ToInt32(count + 2)));
        }
    }
}
