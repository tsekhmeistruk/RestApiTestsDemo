using System;
using System.Net;
using NUnit.Framework;
using RestApiAutomation.Models;

namespace RestApiAutomation.Tests
{
    [TestFixture]
    public class BookTests
    {
        private string Url;
        private RestController rest;

        [OneTimeSetUp]
        public void OneSetUp()
        {
            Url = "http://some-test-endpoint.com/";
            rest = new RestController(Url);
        }

        #region Positive Tests

        [Test]
        public void TestGetBooksPositive()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            var response = rest.Get<Book>();
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestCreateBookPositive()
        {
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            Book newBook = new Book() { Name = "Book name", Author = "John Smith" };

            var response = rest.Post<Book>(newBook);

            var newBookId = Int32.Parse((string)response.ResponseData);
            var createdBook = rest.Get<Book>(newBookId);
            Assert.AreEqual(expected: newBook, actual: createdBook);
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);

            //Cleanup Test
            rest.Delete<Book>(newBookId);
        }

        [Test]
        public void TestUpdateExistingBookPositive()
        {
            //Arrange
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            Book initialBook = new Book() { Name = "Book name initial", Author = "John Smith 2" };
            Book updatedBook = new Book() { Name = "Book name updated", Author = "John Smith 2 updated" };
            int bookId = Int32.Parse((string) rest.Post<Book>(initialBook).ResponseData);

            //Act
            var response = rest.Put<Book>(updatedBook, bookId);
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);

            //Assert
            var responseAfterUpdating = rest.Get<Book>(bookId);
            Assert.AreEqual(expected: updatedBook, actual: (Book)responseAfterUpdating.ResponseData);
            Assert.AreEqual(expected: expectedCode, actual: responseAfterUpdating.HttpStatusCode);

            //CleanUp Test
            rest.Delete<Book>(bookId);
        }

        [Test]
        public void TestRemoveExistingBookPositive()
        {
            //Arrange
            HttpStatusCode expectedCode = HttpStatusCode.NotFound;
            Book book = new Book() { Name = "Book name 3", Author = "John Smith 3" };
            var bookId = Int32.Parse((string)rest.Post<Book>(book).ResponseData);

            //Act
            var response = rest.Delete<Book>(bookId);

            //Assert
            Assert.AreEqual(expected: expectedCode, actual: response.HttpStatusCode);
        }

        [Test]
        public void TestCreateBookWithTheSameNameAndAuthorPositive()
        {
            //Arrange
            HttpStatusCode expectedCode = HttpStatusCode.OK;
            Book book = new Book() { Name = "Book name 4", Author = "John Smith 4" };

            //Act
            var response = rest.Post<Book>(book);
            var response2 = rest.Post<Book>(book);

            //Assert
            Assert.AreEqual(expectedCode, response.HttpStatusCode);
            Assert.AreEqual(expectedCode, response2.HttpStatusCode);
            Assert.AreNotEqual(Int32.Parse((string)response.ResponseData), Int32.Parse((string)response2.ResponseData));
        }

        #endregion

        #region Negative Tests Invalid Resource or Id

        [Test]
        public void TestGetBooksInvalidResourceNegative()
        {

        }

        [Test]
        public void TestCreateBookInvalidResourceNegative()
        {

        }

        [Test]
        public void TestUpdateBookInvalidIdNegative()
        {

        }

        [Test]
        public void TestRemoveBookInvalidIdNegative()
        {

        }

        #endregion

        #region Negative Tests Autorization

        [Test]
        public void TestGetBooksWithInvalidAuthorizationTokenNegative()
        {

        }

        [Test]
        public void TestCreateBookWithoutAuthorizationHeaderNegative()
        {

        }

        [Test]
        public void TestUpdateBookWithEmptyAuthorizationHeaderNegative()
        {

        }

        #endregion

        #region Negative Tests Invalid Model Format (data validation)

        [Test]
        public void TestCreateBookWithoutAuthorNegative()
        {

        }

        [Test]
        public void TestCreateBookWithoutNameNegative()
        {

        }

        [Test]
        public void TestCreateBookWithoutAuthorAndNameNegative()
        {

        }

        [Test]
        public void TestCreateBookWithExtraFieldNegative()
        {

        }

        [Test]
        public void TestUpdateBookWithoutAuthorNegative()
        {

        }

        [Test]
        public void TestUpdateBookWithoutNameNegative()
        {

        }

        [Test]
        public void TestUpdateBookWithoutAuthorAndNameNegative()
        {

        }

        #endregion

        #region Negative Tests Symbols and Length validation

        [Test]
        public void TestCreateBookNonEnglishSymbolsNegative()
        {

        }

        [Test]
        public void TestCreateBookTooLongNameNegative()
        {

        }

        [Test]
        public void TestCreateBookTooLongAuthorNegative()
        {

        }

        [Test]
        public void TestCreateBookSpecialSymbolsNegative()
        {

        }

        #endregion
    }
}
