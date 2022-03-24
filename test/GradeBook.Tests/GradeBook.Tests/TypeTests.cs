using System;
using Xunit;

namespace GradeBook.Tests
{
    public delegate string WriteLogDelegate(string logMessage);

    public class TypeTests
    {
        int count = 0;

        [Fact]
        public void WrtiteLogDelegateCanPointToMethod()
        {
            //WriteLogDelegate log;
            //log = ReturnMessage;

            var log = new WriteLogDelegate(ReturnMessage);
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        private string ReturnMessage(string message)
        {
            count++;
            return message;
        }


        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Scott";
            string upper = MakeUpperCase(name);

            Assert.Equal("Scott", name);
            Assert.Equal("SCOTT", upper);
        }

        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }


        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int x)
        {
            x = 42;
        }

        private int GetInt()
        {
            return 3;
        }


        [Fact]
        public void CSharpCanPassByRef()
        {
            //Arrange:
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New name");

            //Assert:
            Assert.Equal("New name", book1.Name);
        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CSharpIsPassByValue()
        {
            //Arrange:
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New name");

            //Assert:
            Assert.Equal("Book 1", book1.Name);
        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {
            //Arrange:
            var book1 = GetBook("Book 1");
            SetName(book1, "New name");

            //Assert:
            Assert.Equal("New name", book1.Name);
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }


        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            //Arrange:
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            //Assert:
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);

            Assert.NotSame(book1, book2);
        }


        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            //Arrange:
            var book1 = GetBook("Book 1");
            var book2 = book1;

            //Assert:
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}